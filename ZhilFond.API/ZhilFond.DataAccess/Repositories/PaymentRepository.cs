using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ZhilFond.Core.Models;
using ZhilFond.DataAccess.Entities;

namespace ZhilFond.DataAccess.Repositories
{
    public class PaymentRepository(ZhilFondDbContext context) : IPaymentRepository
    {
        public async Task<List<Payment>> GetByAccountId(int accountId)
        {
            var paymentEntities = await context.Payments
                .AsNoTracking()
                .Where(p => p.AccountId == accountId)
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return paymentEntities.Select(p => Payment.Create(
                p.Id,
                p.AccountId,
                p.Date,
                p.Sum)).ToList();
        }

        public async Task<Result> Add(Payment payment)
        {
            try
            {
                var paymentEntity = new PaymentEntity
                {
                    Id = payment.Id,
                    AccountId = payment.AccountId,
                    Date = payment.Date,
                    Sum = payment.Sum
                };

                await context.Payments.AddAsync(paymentEntity);
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
