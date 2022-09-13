// See https://aka.ms/new-console-template for more information

internal class SaveSystem
{
    public void append(string filePath, string text)
    {
        if(!File.Exists(filePath))
        {
            File.WriteAllText(filePath, text);
        }
        else
        {
            File.AppendAllText(filePath, text);
        }
    }
}