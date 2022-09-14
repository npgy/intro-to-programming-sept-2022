namespace Banking.Domain;

public class TimeBasedBonusCalculator : ICalculateAccountBonuses
{
    private readonly IProvideTheBusinessClock _businessClock;

    public TimeBasedBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit)
    {
        if (_businessClock.DuringBusinessHours() && balance >= 5000)
        {
            return amountToDeposit * 0.10M;
        }
        else
        {
            return 0;
        }
;
    }

    protected virtual bool DuringBusinessHours()
    {
        return DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 17;
    }
}