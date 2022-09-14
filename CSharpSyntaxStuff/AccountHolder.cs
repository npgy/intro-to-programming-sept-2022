namespace CSharpSyntaxStuff;
public record AccountHolder
{
    private AccountHolder() { }

    public string Name { get; private init; } = string.Empty;

    public string Email { get; private init; } = string.Empty;

    public string AccountNumber { get; private init; } = string.Empty;

    public string GetInfo()
    {
        return $"This Account Holder is {Name}";
    }

    public static AccountHolder Create(string name, string accountNumber)
    {
        if (name == "Jeff") throw new ArgumentException("That dude sucks!");
        return new AccountHolder { Name = name.ToUpper(), AccountNumber = accountNumber };
    }

    public static AccountHolder ChangeName(AccountHolder account, string newName)
    {
        return account with { Name = newName.ToUpper() };
    }
}
