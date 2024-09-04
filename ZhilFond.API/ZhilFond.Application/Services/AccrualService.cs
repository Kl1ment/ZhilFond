using CSharpFunctionalExtensions;
using ZhilFond.Core.Models;
using ZhilFond.DataAccess.Repositories;

namespace ZhilFond.Application.Services
{
    public class AccrualService(IAccrualRepository accrualRepository, ITimeService timeService) : IAccrualService
    {
        public async Task<List<Accrual>> GetAllAccruals(int accountId)
        {
            return await accrualRepository.GetByAccountId(accountId);
        }

        public async Task<Result> AddAccrual(int accountId, int period, decimal inBalance, decimal calculation)
        {
            var accrual = Accrual.Create(
                Guid.NewGuid(), accountId,
                timeService.ParsToDate(period, "yyyyMM"),
                inBalance,
                calculation);

            return await accrualRepository.Add(accrual);
        }
    }
}
