
namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {

        if (numbers == "")
        {
            return 0;
        }

        var response = numbers.Split(',', '\n').Select(int.Parse).Sum();
        try
        {
            _logger.Write(response.ToString());
        }
        catch (LoggingFailureException)
        {

            //gulp!
        _webService.Notify($"Logger Failed, Result was {response}");
        }
        return response;
    }
}

public interface IWebService
{
    void Notify(string message);
}

public interface ILogger
{
    void Write(string message);
}

public class LoggingFailureException : Exception
{
    
}