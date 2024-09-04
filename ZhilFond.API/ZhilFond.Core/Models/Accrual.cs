namespace ZhilFond.Core.Models
{
    public class Accrual
    {
        public Guid Id { get; }
        public int AccountId { get; }
        public DateTime Period { get; }
        public decimal InBalance { get; }
        public decimal Calculation { get; }

        private Accrual(Guid Id, int accountId, DateTime period, decimal inBalance, decimal calculation)
        {
            this.Id = Id;
            AccountId = accountId;
            Period = period;
            InBalance = inBalance;
            Calculation = calculation;
        }

        public static Accrual Create(Guid Id, int accountId, DateTime period, decimal inBalance, decimal calculation)
        {
            var validator = new Validator();

            if (!validator.IsEarlierCurrentDate(period).IsPositive(calculation).IsValid)
                throw new ArgumentException(validator.Error);

            return new Accrual(
                Id,
                accountId,
                period,
                inBalance,
                calculation);
        }
    }
}
