// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter your goal for today:");
Console.WriteLine("--------------------------");
string? goalUnprocessed = Console.ReadLine();
string goalFinal = "";

try
{
	goalFinal = goalUnprocessed?.Substring(0, 255);
}
catch (ArgumentOutOfRangeException)
{
	goalFinal = goalUnprocessed;
}

Console.WriteLine($"\n[For {DateTime.Now:D} Your Goal Is:]\n");
Console.WriteLine($"\"{goalFinal}\"");

/*using System.Windows.Forms.Application;

Console.WriteLine(Application.LocalUserAppDataPath);*/