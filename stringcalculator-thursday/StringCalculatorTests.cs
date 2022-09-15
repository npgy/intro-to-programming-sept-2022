using Moq;

namespace StringCalculator;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator;

    public StringCalculatorTests()
    {
        _calculator = new StringCalculator(
            new Mock<ILogger>().Object,
            new Mock<IWebService>().Object);
    }

    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("968", 968)]
    public void SingleDigitReturnsThatNumber(string nums, int expected)
    {
        var result = _calculator.Add(nums);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("120,8", 128)]
    public void TwoCommaSeparatedValues(string nums, int expected)
    {
        var result = _calculator.Add(nums);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("10,20,1", 31)]
    public void ArbitraryCommaSeparated(string nums, int expected)
    {
        var result = _calculator.Add(nums);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("10,20\n1", 31)]

    public void MixedDelimeters(string nums, int expected)
    {
        var result = _calculator.Add(nums);

        Assert.Equal(expected, result);
    }
}
