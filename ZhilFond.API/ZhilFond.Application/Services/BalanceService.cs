using CSharpFunctionalExtensions;
using ZhilFond.Application.DTO;
using ZhilFond.Core.Models;
using ZhilFond.DataAccess.Repositories;

namespace ZhilFond.Application.Services
{
    public class BalanceService(IBalanceRepository balanceRepository, ITimeService timeService) : IBalanceService
    {
        public async Task<List<ReportDTO>> GetBalance(int accountId, string periodType)
        {
            var table = await balanceRepository.GetBalance(accountId, periodType);

            return TableCalculation(table, periodType);
        }

        public async Task<decimal> GetCurrentDebt(int accountId)
        {
            var currentDebt = await balanceRepository.GetCurrentDebt(accountId) ??
                throw new Exception("Account was not found");

            return currentDebt;
        }

        private List<ReportDTO> TableCalculation(List<Report> table, string periodType)
        {
            var tableResponse = table
                .Select(r => new ReportDTO
                {
                    Period = timeService.ParsToString(r.Period, periodType),
                    InBalance = r.InBalance,
                    Calculation = r.Calculation,
                    Paid = r.Paid,
                    OutBalance = r.OutBalance,
                })
                .ToList();

            for (int i = tableResponse.Count - 1; i >= 0; i--)
            {
                var row = tableResponse[i];

                if (i != tableResponse.Count - 1)
                    row.InBalance = tableResponse[i + 1].OutBalance;
                else
                    row.InBalance = row.InBalance;

                row.OutBalance = row.InBalance + row.Calculation - row.Paid;
            }

            return tableResponse;
        }
    }
}
