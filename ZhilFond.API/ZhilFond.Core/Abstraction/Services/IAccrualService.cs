using CSharpFunctionalExtensions;
using ZhilFond.Core.Models;

namespace ZhilFond.Application.Services
{
    public interface IAccrualService
    {
        Task<Result> AddAccrual(int accountId, int period, decimal inBalance, decimal calculation);
        Task<List<Accrual>> GetAllAccruals(int accountId);
    }
}