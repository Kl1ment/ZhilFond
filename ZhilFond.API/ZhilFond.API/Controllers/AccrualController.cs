using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZhilFond.API.Contracts;
using ZhilFond.Application;
using ZhilFond.Application.Services;
using ZhilFond.DataAccess.Json;

namespace ZhilFond.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccrualController(IAccrualService accrualService, ITimeService timeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AccrualResponse>>> GetAllAccruals([FromQuery] int accountId)
        {
            var accruals = await accrualService.GetAllAccruals(accountId);

            return accruals.Select(a => new AccrualResponse 
            {
                AccountId = a.AccountId,
                Period = timeService.ParsToInt(a.Period),
                InBalance = a.InBalance,
                Calculation = a.Calculation
            }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> AddAccrual(AccrualRequest accrual)
        {
            var result = await accrualService.AddAccrual(
                accrual.AccountId,
                accrual.Period,
                accrual.InBalance,
                accrual.Calculation);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpPost("UploadFile")]
        public async Task<ActionResult> AddAccrualRange(IFormFile uploadedFile)
        {
            var balance = JsonSerializer.Deserialize<BalanceJsonList>(uploadedFile.OpenReadStream());

            if (balance == null || balance.Accruals == null)
                return BadRequest();

            foreach (var accrual in balance.Accruals)
            {
                var result = await accrualService.AddAccrual(
                    accrual.AccountId,
                    accrual.Period,
                    accrual.InBalance,
                    accrual.Calculation);

                if (result.IsFailure)
                    return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
