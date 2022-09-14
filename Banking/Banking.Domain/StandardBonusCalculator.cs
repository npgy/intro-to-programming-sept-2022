namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateAccountBonuses
{
    public decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit)
    {
        if(balance >= 5000M)
        {
            return amountToDeposit * 0.10M;
        }
        else
        {
            return 0;
        }
    }
}