namespace CSharpSyntaxStuff;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Given (Arrange)
        int a = 10, b = 20, answer;
        // When (Act)
        answer = a + b;
        // Then (Assert)
        Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 5, 15)]
    public void Addition(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }
}