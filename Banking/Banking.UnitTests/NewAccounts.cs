using Banking.Domain;
using Moq;

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void HaveCorrectOpeningBalance()
    {
        var account = new BankAccount(new Mock<ICalculateAccountBonuses>().Object);
                   
        decimal balance = account.GetBalance();

        Assert.Equal(5000, balance);
    }
}
