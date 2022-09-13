
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Fact]
    public void SingleNumberReturnsItself()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("5");

        Assert.Equal(5, result);
    }

    [Fact]
    public void TwoNumbersReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("5,8");

        Assert.Equal(13, result);
    }

    [Fact]
    public void ThreeNumbersReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("15,23,91");

        Assert.Equal(129, result);
    }

    [Fact]
    public void FourNumbersReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("15,23,91,2");

        Assert.Equal(131, result);
    }

    [Fact]
    public void FiveNumbersReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("69,15,23,91,2");

        Assert.Equal(200, result);
    }

    [Fact]
    public void SixNumbersReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("200,69,15,23,91,2");

        Assert.Equal(400, result);
    }

    [Fact]
    public void TwoNumbersWithNewLinesReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("4\n7");

        Assert.Equal(11, result);
    }

    [Fact]
    public void ThreeNumbersWithNewLinesReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("15\n23\n91");

        Assert.Equal(129, result);
    }

    [Fact]
    public void FourNumbersWithNewLinesReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("15\n23\n91\n2");

        Assert.Equal(131, result);
    }

    [Fact]
    public void FiveNumbersWithNewLinesReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("69\n15\n23\n91\n2");

        Assert.Equal(200, result);
    }

    [Fact]
    public void SixNumbersWithNewLinesReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("200\n69\n15\n23\n91\n2");

        Assert.Equal(400, result);
    }

    [Fact]
    public void FourNumbersWithMixedDelimsReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("15\n23,91\n2");

        Assert.Equal(131, result);
    }

    [Fact]
    public void FiveNumbersWithMixedDelimsReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("25,15\n23,91\n2");

        Assert.Equal(156, result);
    }

    [Fact]
    public void CustomerDelimiterIsSet()
    {
        var calculator = new StringCalculator();

        char[] result = calculator.GetDelimeters("//;4;7");

        Assert.Equal(';', result[0]);
    }

    [Fact]
    public void TwoNumbersWithSemicolonDelimReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("//;4;7");

        Assert.Equal(11, result);
    }

    [Fact]
    public void FiveNumbersWithPlusDelimReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("//+25+15+23+91+2");

        Assert.Equal(156, result);
    }

    [Fact]
    public void FiveNumbersWithStarDelimReturnTheirSum()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("//*25*15*23*91*2");

        Assert.Equal(156, result);
    }
}
