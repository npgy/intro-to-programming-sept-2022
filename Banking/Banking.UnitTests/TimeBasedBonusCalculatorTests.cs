using Banking.Domain;
using Moq;

namespace Banking.UnitTests;
public class TimeBasedBonusCalculatorTests
{

    [Fact]
    public void AccountsThatMeetCriteriaGetBonusDuringBusinessHours()
    {
        var stubbedBusinessClock = new Mock<IProvideTheBusinessClock>();
        stubbedBusinessClock.Setup(c => c.DuringBusinessHours()).Returns(true);
        ICalculateAccountBonuses calculator = new TimeBasedBonusCalculator(stubbedBusinessClock.Object);

        var bonus = calculator.GetBonusForDepositOnAccount(5000, 100);

        Assert.Equal(10M, bonus);
    }

    [Fact]
    public void AccountsThatMeetCriteriaGetBonusOutsideBusinessHours()
    {
        var stubbedBusinessClock = new Mock<IProvideTheBusinessClock>();
        stubbedBusinessClock.Setup(c => c.DuringBusinessHours()).Returns(false);
        ICalculateAccountBonuses calculator = new TimeBasedBonusCalculator(stubbedBusinessClock.Object);

        var bonus = calculator.GetBonusForDepositOnAccount(5000, 100);

        Assert.Equal(0, bonus);
    }

    [Fact]
    public void AccountsThatDontMeetCriteriaDoNotGetBonus()
    {
        ICalculateAccountBonuses calculator = new TimeBasedBonusCalculator();

        var bonus = calculator.GetBonusForDepositOnAccount(4999.99M, 100);

        Assert.Equal(0, bonus);
    }
}