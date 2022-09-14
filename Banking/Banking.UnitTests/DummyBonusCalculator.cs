using Banking.Domain;

namespace Banking.UnitTests;
public class DummyBonusCalculator : ICalculateAccountBonuses
{
    public decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit)
    {
        return 0;
    }
}
