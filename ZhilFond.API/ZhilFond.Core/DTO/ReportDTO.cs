namespace ZhilFond.Application.DTO
{
    public class ReportDTO
    {
        public string Period { get; set; } = string.Empty;
        public decimal InBalance { get; set; }
        public decimal Calculation { get; set; }
        public decimal Paid { get; set; }
        public decimal OutBalance { get; set; }
    }
}
