namespace ZhilFond.Core.Models
{
    public class Report
    {
        public DateTime Period { get; }
        public decimal InBalance { get; }
        public decimal Calculation { get; }
        public decimal Paid { get; }
        public decimal OutBalance { get; }

        private Report(DateTime period, decimal inBalance, decimal calculation, decimal paid, decimal outBalance)
        {
            Period = period;
            InBalance = inBalance;
            Calculation = calculation;
            Paid = paid;
            OutBalance = outBalance;
        }

        public static Report Create(DateTime period, decimal inBalance, decimal calculation, decimal paid, decimal outBalance)
        {
            return new Report(
                period,
                inBalance,
                calculation,
                paid,
                outBalance);
        }
    }
}
