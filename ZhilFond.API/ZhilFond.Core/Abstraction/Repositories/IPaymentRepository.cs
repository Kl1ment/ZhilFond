using CSharpFunctionalExtensions;
using ZhilFond.Core.Models;

namespace ZhilFond.DataAccess.Repositories
{
    public interface IPaymentRepository
    {
        Task<Result> Add(Payment payment);
        Task<List<Payment>> GetByAccountId(int accountId);
    }
}