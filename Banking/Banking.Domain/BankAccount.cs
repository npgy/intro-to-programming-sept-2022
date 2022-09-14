namespace Banking.Domain;

public class BankAccount
{
    private readonly ICalculateAccountBonuses _bonusCalculator;
    private decimal _balance = 5000M;

    public BankAccount(ICalculateAccountBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = _bonusCalculator.GetBonusForDepositOnAccount(_balance, amountToDeposit);
        _balance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if(amountToWithdraw <= _balance)
        {
            _balance -= amountToWithdraw;
        }
        else
        {
            throw new OverdraftException();
        }
    }
}