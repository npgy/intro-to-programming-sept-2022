using Moq;

namespace StringCalculator;

public class StringCalculatorInteractionTests
{

    [Theory]
    [InlineData("1", "1")]
    [InlineData("1,2,3", "6")]
    public void CalculatorWritesAnswerToTheLogger(string numbers, string expectedLogMessage)
    {
        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object,
            new Mock<IWebService>().Object);

        var answer = calculator.Add(numbers);

        mockedLogger.Verify(logger => logger.Write(expectedLogMessage));
    }

    [Fact]
    public void WhenLoggerThrowsExceptionWebServiceIsCalled()
    {
        var stubbedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);
        stubbedLogger.Setup(s => s.Write(It.IsAny<String>()))
            .Throws(new LoggingFailureException());

        calculator.Add("99");

        //web svc called
        mockedWebService.Verify(m => m.Notify("Logger Failed, Result was 99"));
    }

    [Fact]
    public void WebServiceOnlyCalledOnLoggerException()
    {
        var stubbedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

        calculator.Add("99");

        //web svc called
        mockedWebService.Verify(m => m.Notify(It.IsAny<String>()), Times.Never);
    }
}
