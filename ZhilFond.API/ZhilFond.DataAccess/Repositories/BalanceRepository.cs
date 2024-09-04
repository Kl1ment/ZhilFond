using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ZhilFond.Core.Models;
using ZhilFond.DataAccess.Entities;

namespace ZhilFond.DataAccess.Repositories
{
    public class BalanceRepository(ZhilFondDbContext context, IDapperDbContext dapperDbContext) : IBalanceRepository
    {
        public async Task<List<Report>> GetBalance(int accountId, string periodType)
        {
            var firstInBalance = await context.Accruals
                .AsNoTracking()
                .Where(a => a.AccountID == accountId)
                .OrderBy(a => a.Period)
                .Select(a => a.InBalance)
                .FirstOrDefaultAsync();

            string sql = "SELECT CASE WHEN t1.Period IS NULL THEN t2.Period ELSE t1.Period END," +
                " t1.Calculation, t2.Paid" +
                " FROM (" +
                    " SELECT a1.Key AS Period, SUM(a1.\"Calculation\") AS Calculation" +
                    $" FROM (SELECT date_trunc('{periodType.ToLower()}', a.\"Period\" AT TIME ZONE 'UTC') as Key, a.\"Calculation\"" +
                         " FROM \"Accruals\" AS a" +
                         $" WHERE a.\"AccountID\" = {accountId}) AS a1" +
                    " GROUP BY a1.Key" +
                    " ORDER BY a1.Key" +
                ") AS t1" +
                " FULL OUTER JOIN (" +
                    " SELECT p1.Key AS Period, SUM(p1.\"Sum\") AS Paid" +
                    $" FROM (SELECT date_trunc('{periodType.ToLower()}', p.\"Date\" AT TIME ZONE 'UTC') as Key, p.\"Sum\"" +
                        " FROM \"Payments\" AS p" +
                        $" WHERE p.\"AccountId\" = {accountId}) AS p1" +
                    " GROUP BY p1.Key" +
                ") AS t2" +
                " ON t1.Period = t2.Period " +
                "ORDER BY t1.Period DESC;";

            using (IDbConnection db = dapperDbContext.Connection)
            {
                var query = await db.QueryAsync<ReportEntity>(sql);

                return query.Select(r => Report.Create(
                    r.Period,
                    firstInBalance,
                    r.Calculation,
                    r.Paid,
                    r.OutBalance)).ToList();
            }
        }

        public async Task<decimal?> GetCurrentDebt(int accountId)
        {
            var firstAccrual = await context.Accruals
                .Where(a => a.AccountID == accountId)
                .OrderBy(b => b.Period)
                .FirstOrDefaultAsync();

            var firstInBalance = firstAccrual?.InBalance;

            var accrualSum = await context.Accruals
                .Where(a => a.AccountID == accountId)
                .SumAsync(a => a.Calculation);

            var paymentSum = await context.Payments
                .Where(p => p.AccountId == accountId)
                .SumAsync(p => p.Sum);

            Console.WriteLine($"{firstInBalance} + {accrualSum} - {paymentSum};");

            return firstInBalance + accrualSum - paymentSum;
        }
    }
}
