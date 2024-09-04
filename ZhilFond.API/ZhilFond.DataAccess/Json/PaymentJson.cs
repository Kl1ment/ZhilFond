using System.Text.Json.Serialization;

namespace ZhilFond.DataAccess.Json
{
    public class PaymentJson
    {
        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("date")]
        public string DateString { get; set; } = string.Empty;

        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }

        [JsonPropertyName("payment_guid")]
        public Guid PaymentId { get; set; }

        public DateTime Date
        {
            get
            {
                return DateTime.ParseExact(DateString, "yyyy-MM-dd HH:mm:ss", AccrualJson.CultureInfo);
            }
        }
    }
}
