namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M;
    public string AccountType { get; set; } = "standard";

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = GetBonusForDeposit(amountToDeposit);
        _balance += amountToDeposit + bonus;
    }

    private decimal GetBonusForDeposit(decimal amountToDeposit)
    {
        decimal bonus = 0;
        if (AccountType == "gold")
        {
            bonus = amountToDeposit * .10M;
        }

        return bonus;
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