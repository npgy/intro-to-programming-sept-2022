namespace Banking.Domain;
public class SuperBonusCalculator : ICalculateAccountBonuses
{
    public decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit)
    {
        return balance >= 5000 ? amountToDeposit * .10M : 0;
    }
}
