using Banking.Domain;

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void HaveCorrectOpeningBalance()
    {
        var account = new BankAccount();
                   
        decimal balance = account.GetBalance();

        Assert.Equal(5000, balance);
    }
}
