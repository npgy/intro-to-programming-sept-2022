namespace Banking.Api.Models;

public record AccountSummaryResponse
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}

public record AccountCreateRequest
{
    public string Name { get; set; } = string.Empty;
}

public record AccountBalanceResponse
{
    public decimal Balance { get; set; }
}

public record AccountTransactionRequest
{
    public decimal Amount { get; set; }
}

public record AccountTransactionResponse
{
    public string TransactionId { get; set; } = string.Empty;
    public DateTime PostedAt { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
}