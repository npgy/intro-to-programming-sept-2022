namespace Banking.Domain;
public interface ICalculateAccountBonuses
{
    decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit);
}
