using CSharpFunctionalExtensions;
using ZhilFond.Core.Models;
using ZhilFond.DataAccess.Repositories;

namespace ZhilFond.Application.Services
{
    public class PaymentService(IPaymentRepository paymentRepository, ITimeService timeService) : IPaymentService
    {
        public async Task<List<Payment>> GetAllPayments(int accountId)
        {
            return await paymentRepository.GetByAccountId(accountId);
        }

        public async Task<Result> AddPayment(int accountId, string date, decimal sum, Guid? paymentId)
        {
            var payment = Payment.Create(
                paymentId ?? Guid.NewGuid(),
                accountId,
                timeService.ParsToDate(date, "yyyy-MM-dd HH:mm:ss"),
                sum);

            return await paymentRepository.Add(payment);
        }
    }
}
