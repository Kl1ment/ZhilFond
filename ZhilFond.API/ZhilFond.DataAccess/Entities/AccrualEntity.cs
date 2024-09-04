namespace ZhilFond.DataAccess.Entities
{
    public class AccrualEntity
    {
        public Guid Id { get; set; }
        public int AccountID { get; set; }
        public DateTime Period { get; set; }
        public decimal InBalance { get; set; }
        public decimal Calculation { get; set; }
    }
}
