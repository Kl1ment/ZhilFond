namespace ZhilFond.API.Contracts
{
    public record PaymentRequest(
        int AccountId,
        string Date,
        decimal Sum,
        Guid PaymentId);
}
