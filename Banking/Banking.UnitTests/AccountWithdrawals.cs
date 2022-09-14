using Banking.Domain;

namespace Banking.UnitTests;
public class AccountWithdrawals
{
    private readonly BankAccount _account;
    private readonly decimal _openingBalance;

    public AccountWithdrawals()
    {
        _account = new BankAccount(new DummyBonusCalculator());
        _openingBalance = _account.GetBalance();
    }

    [Fact]
    public void WithdawingMoneyDecreasesBalance()
    {
        
        var amountToWithdraw = 10M;

        _account.Withdraw(amountToWithdraw);

        Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
    }

    [Fact]
    public void UsersCanWithdrawFullBalance()
    {

        _account.Withdraw(_openingBalance);

        Assert.Equal(0, _account.GetBalance());
    }

    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var amountToWithdraw = _openingBalance + 0.01M;
        
        try
        {
            _account.Withdraw(amountToWithdraw);
        }
        catch (OverdraftException)
        {
            //Swallow!
        }
        finally
        {
            Assert.Equal(_openingBalance, _account.GetBalance());
        }
    }

    [Fact]
    public void OverdraftThrowsAnException()
    {

        Assert.Throws<OverdraftException>(() =>
            _account.Withdraw(_openingBalance + 1)
        );
    }
}
