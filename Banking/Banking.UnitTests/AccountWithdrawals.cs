using Banking.Domain;

namespace Banking.UnitTests;
public class AccountWithdrawals
{
    [Fact]
    public void WithdawingMoneyDecreasesBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 10M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void UsersCanWithdrawFullBalance()
    {
        var account = new BankAccount();

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }

    

    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 0.01M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
