using Banking.Domain;

namespace Banking.UnitTests;
public class GoldAccountsGetBonus
{
    [Fact]
    public void GoldAccountsGetbBonusOnDeposit()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}
