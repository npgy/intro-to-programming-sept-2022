
namespace StringCalculator;

public class StringCalculator
{
    private char[] Delimeters = { ',', '\n' };
    public int Add(string numbers)
    {
        string readDelimOpts = "";
        int numStart = 0;
        int sum = 0;
        List<int> negatives = new List<int>();
        try
        {
            readDelimOpts = numbers[..3];
        }
        catch (ArgumentOutOfRangeException)
        {
            //Swallow!
        }
        finally
        {
            if (readDelimOpts.StartsWith("//"))
            {
                numStart = 2;
                Delimeters = new char[] { readDelimOpts[2] };
            }
        }
        string[] numberList = numbers.Substring(numStart,numbers.Length-numStart).Split(Delimeters);
        foreach (string number in numberList)
        {
            if (!number.Equals(""))
            {
                sum += int.Parse(number);
            }
        }
        return sum;
    }

    public char[] GetDelimeters(string query)
    {
        string readDelimOpts = "";

        try
        {
            readDelimOpts = query[..3];
        }
        catch (ArgumentOutOfRangeException)
        {
            //Swallow!
        }
        finally
        {
            if (readDelimOpts.StartsWith("//"))
            {
                Delimeters = new char[] { readDelimOpts[2] };
            }
        }

        return Delimeters;
    }


}