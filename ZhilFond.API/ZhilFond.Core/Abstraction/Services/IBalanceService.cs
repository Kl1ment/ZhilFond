using ZhilFond.Application.DTO;

namespace ZhilFond.Application
{
    public interface IBalanceService
    {
        Task<List<ReportDTO>> GetBalance(int accountId, string periodType);
        Task<decimal> GetCurrentDebt(int accountId);
    }
}