// See https://aka.ms/new-console-template for more information

internal class Answer
{
    private string UserResponse;

    public Answer(string userResponse)
    {
        UserResponse = userResponse;
    }

    public bool Affirmative()
    {
        if (UserResponse.Trim().ToUpper().Equals("Y") || UserResponse.Equals(""))
        {
            return true;
        }
        return false;
    }
}