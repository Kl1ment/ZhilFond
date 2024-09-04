namespace ZhilFond.DataAccess.Entities
{
    public class PaymentEntity
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
    }
}
