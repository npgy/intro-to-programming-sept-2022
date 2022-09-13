// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string goalsPath = Path.Combine(appDataPath, "goals.txt");

SaveSystem saver = new SaveSystem();
Asker asker = new Asker();

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

Answer saveDecision = asker.Ask("Save Changes?");

if(saveDecision.Affirmative())
{ saver.append(goalsPath, goalFinal + "\n"); }

Answer viewRecentsDecision = asker.Ask("Would you like to view previous entries?");

if(viewRecentsDecision.Affirmative())
{
	Console.WriteLine("\n");
	string[] prevEntries = File.ReadAllLines(goalsPath);
	foreach (string entry in prevEntries)
	{
        Console.WriteLine(entry);
    }
	
}