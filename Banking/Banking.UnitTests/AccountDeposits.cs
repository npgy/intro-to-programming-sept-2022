using Banking.Domain;

namespace Banking.UnitTests;
public class AccountDeposits
{
    [Fact]
    public void MakingADepositIncreasesTheBalance()
    {
        //Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 10.15M;

        //When
        account.Deposit(amountToDeposit);

        //Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
