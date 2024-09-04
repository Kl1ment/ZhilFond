using System.Runtime.Serialization;

namespace ZhilFond.API.Contracts
{
    [DataContract]
    public class ReportResponse
    {
        [DataMember]
        public string Period { get; set; } = string.Empty;

        [DataMember]
        public decimal InBalance { get; set; }

        [DataMember]
        public decimal Calculation { get; set; }

        [DataMember]
        public decimal Paid { get; set; }

        [DataMember]
        public decimal OutBalance { get; set; }
    }
}
