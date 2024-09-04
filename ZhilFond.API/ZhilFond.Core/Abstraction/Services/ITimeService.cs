namespace ZhilFond.Application
{
    public interface ITimeService
    {
        DateTime ParsToDate(string date, string format);
        DateTime ParsToDate(int date, string format);
        string ParsToString(DateTime period, string periodType);
        int ParsToInt(DateTime date);
    }
}