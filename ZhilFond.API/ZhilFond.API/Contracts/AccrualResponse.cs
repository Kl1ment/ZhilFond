using System.Runtime.Serialization;

namespace ZhilFond.API.Contracts
{
    [DataContract]
    public class AccrualResponse
    {
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public decimal InBalance { get; set; }

        [DataMember]
        public decimal Calculation { get; set; }
    }
}
