namespace ZhilFond.DataAccess.Entities
{
    public class ReportEntity
    {
        public DateTime Period { get; set; }
        public decimal InBalance { get; set; }
        public decimal Calculation { get; set; }
        public decimal Paid { get; set; }
        public decimal OutBalance { get; set; }
    }
}
