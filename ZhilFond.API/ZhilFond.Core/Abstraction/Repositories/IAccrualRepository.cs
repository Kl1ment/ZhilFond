using CSharpFunctionalExtensions;
using ZhilFond.Core.Models;

namespace ZhilFond.DataAccess.Repositories
{
    public interface IAccrualRepository
    {
        Task<Result> Add(Accrual accrual);
        Task<List<Accrual>> GetByAccountId(int accountId);
    }
}