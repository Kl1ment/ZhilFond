using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ZhilFond.Core.Models;
using ZhilFond.DataAccess.Entities;

namespace ZhilFond.DataAccess.Repositories
{
    public class AccrualRepository(ZhilFondDbContext context) : IAccrualRepository
    {
        public async Task<List<Accrual>> GetByAccountId(int accountId)
        {
            var accrualEntities = await context.Accruals
                .AsNoTracking()
                .Where(a => a.AccountID == accountId)
                .OrderByDescending(a => a.Period)
                .ToListAsync();

            return accrualEntities.Select(a => Accrual.Create(
                a.Id,
                a.AccountID,
                a.Period,
                a.InBalance,
                a.Calculation)).ToList();
        }

        public async Task<Result> Add(Accrual accrual)
        {
            try
            {
                var accrualEntity = new AccrualEntity
                {
                    Id = accrual.Id,
                    AccountID = accrual.AccountId,
                    Period = accrual.Period,
                    InBalance = accrual.InBalance,
                    Calculation = accrual.Calculation,
                };

                await context.Accruals.AddAsync(accrualEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.ToString());
            }
        }
    }
}
