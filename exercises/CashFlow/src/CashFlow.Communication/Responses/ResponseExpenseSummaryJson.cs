namespace CashFlow.Communication.Responses;

public class ResponseExpenseSummaryJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
