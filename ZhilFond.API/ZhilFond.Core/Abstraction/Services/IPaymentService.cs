using CSharpFunctionalExtensions;
using ZhilFond.Core.Models;

namespace ZhilFond.Application.Services
{
    public interface IPaymentService
    {
        Task<Result> AddPayment(int accountId, string date, decimal sum, Guid? paymentId);
        Task<List<Payment>> GetAllPayments(int accountId);
    }
}