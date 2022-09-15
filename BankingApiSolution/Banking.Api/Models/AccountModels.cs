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