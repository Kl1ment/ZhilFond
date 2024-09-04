namespace ZhilFond.API.Contracts
{
    public record AccrualRequest(
        int AccountId,
        int Period,
        decimal InBalance,
        decimal Calculation);
}
