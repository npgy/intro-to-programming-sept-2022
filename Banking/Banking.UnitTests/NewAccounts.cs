using Banking.Domain;

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void HaveCorrectOpeningBalance()
    {
        var account = new BankAccount(new DummyBonusCalculator());
                   
        decimal balance = account.GetBalance();

        Assert.Equal(5000, balance);
    }
}
