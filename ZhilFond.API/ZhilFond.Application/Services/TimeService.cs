using System.Globalization;

namespace ZhilFond.Application.Services
{
    public class TimeService : ITimeService
    {
        private CultureInfo _culture = new CultureInfo("ru-RU");

        public DateTime ParsToDate(string date, string format) =>
            DateTime.ParseExact(date, format, _culture)
            .ToUniversalTime()
            .AddHours(3);

        public DateTime ParsToDate(int date, string format) =>
            DateTime.ParseExact(date.ToString(), format, _culture)
            .ToUniversalTime()
            .AddHours(3);

        public int ParsToInt(DateTime date) =>
            Convert.ToInt32(date.ToString("yyyyMM"));

        public string ParsToString(DateTime period, string periodType)
        {
            switch (periodType.ToLower())
            {
                case "year":
                    return period.ToString("yyyy год");

                case "quarter":
                    return $"{period.Month / 3 + 1} квартал, {period.Year} год";

                case "month":
                    return period.ToString("Y");

                default:
                    return string.Empty;
            }
        }
    }
}
