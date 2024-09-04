using ZhilFond.Core.Models;

namespace ZhilFond.DataAccess.Repositories
{
    public interface IBalanceRepository
    {
        Task<List<Report>> GetBalance(int accountId, string periodType);
        Task<decimal?> GetCurrentDebt(int accountId);
    }
}