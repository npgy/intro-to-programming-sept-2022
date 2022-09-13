// See https://aka.ms/new-console-template for more information

internal class Asker
{
    public Answer Ask(string question)
    {
        string formatted = $"\n[{question} (Y / n)] ";
        Console.Write(formatted);
        string? userReply = Console.ReadLine();
        return new Answer(userReply);
    }
}