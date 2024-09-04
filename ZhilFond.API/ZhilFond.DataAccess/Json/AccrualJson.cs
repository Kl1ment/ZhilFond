using System.Globalization;
using System.Text.Json.Serialization;

namespace ZhilFond.DataAccess.Json
{
    public class AccrualJson
    {
        public static CultureInfo CultureInfo
        {
            get
            {
                return new CultureInfo("ru-RU");
            }
        }

        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("period")]
        public int Period { get; set; }

        [JsonPropertyName("in_balance")]
        public decimal InBalance { get; set; }

        [JsonPropertyName("calculation")]
        public decimal Calculation { get; set; }

        public DateTime Date
        {
            get
            {
                return DateTime.ParseExact(Period.ToString(), "yyyyMM", CultureInfo);
            }
        }
    }
}
