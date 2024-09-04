using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZhilFond.API.Contracts;
using ZhilFond.Application.Services;
using ZhilFond.DataAccess.Json;

namespace ZhilFond.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PaymentResponse>>> GetAllPayments([FromQuery] int accountId)
        {
            var payments = await paymentService.GetAllPayments(accountId);

            return payments.Select(p => new PaymentResponse
            {
                AccountId = p.AccountId,
                Date = p.Date,
                Sum = p.Sum
            }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> AddPayment(PaymentRequest payment)
        {
            var result = await paymentService.AddPayment(
                payment.AccountId,
                payment.Date,
                payment.Sum,
                payment.PaymentId);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpPost("UploadFile")]
        public async Task<ActionResult> AddPaymentRange(IFormFile uploadedFile)
        {
            var payments = JsonSerializer.Deserialize<List<PaymentJson>>(uploadedFile.OpenReadStream());

            if (payments == null)
                return BadRequest();

            foreach (var payment in payments)
            {
                var result = await paymentService.AddPayment(
                    payment.AccountId,
                    payment.DateString,
                    payment.Sum,
                    payment.PaymentId);

                if (result.IsFailure)
                    return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
