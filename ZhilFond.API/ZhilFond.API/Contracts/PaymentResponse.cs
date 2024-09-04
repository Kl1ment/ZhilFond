using System.Runtime.Serialization;

namespace ZhilFond.API.Contracts
{
    [DataContract]
    public class PaymentResponse
    {
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}
