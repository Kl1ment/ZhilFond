using Microsoft.AspNetCore.Mvc;
using ZhilFond.API.Contracts;
using ZhilFond.Application;

namespace ZhilFond.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController(IBalanceService balanceService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ReportResponse>>> GetBalances(int accountId, string periodType)
        {
            var table = await balanceService.GetBalance(accountId, periodType);

            var reportResponse = table.Select(r => new ReportResponse
            {
                Period = r.Period,
                InBalance = r.InBalance,
                Calculation = r.Calculation,
                Paid = r.Paid,
                OutBalance = r.OutBalance
            }).ToList();

            return Ok(reportResponse);
        }

        [HttpGet("Debt")]
        public async Task<ActionResult> GetCurrentDebt(int accountId)
        {
            return Ok(await balanceService.GetCurrentDebt(accountId));
        }
    }
}
