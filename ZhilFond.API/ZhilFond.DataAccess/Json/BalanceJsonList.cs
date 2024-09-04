using System.Text.Json.Serialization;

namespace ZhilFond.DataAccess.Json
{
    public class BalanceJsonList
    {
        [JsonPropertyName("balance")]
        public List<AccrualJson>? Accruals { get; set; }
    }
}
