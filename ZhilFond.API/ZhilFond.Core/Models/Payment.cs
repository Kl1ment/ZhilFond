namespace ZhilFond.Core.Models
{
    public class Payment
    {
        public Guid Id { get; }
        public int AccountId { get; }
        public DateTime Date { get; }
        public decimal Sum { get; }

        private Payment(Guid id, int accountId, DateTime date, decimal sum)
        {
            Id = id;
            AccountId = accountId;
            Date = date;
            Sum = sum;
        }

        public static Payment Create(Guid id, int accountId, DateTime date, decimal sum)
        {
            var validator = new Validator();

            if (!validator.IsEarlierCurrentDate(date).IsPositive(sum).IsValid)
                throw new ArgumentException(validator.Error);

            return new Payment(
                id,
                accountId,
                date,
                sum);
        }
    }
}
