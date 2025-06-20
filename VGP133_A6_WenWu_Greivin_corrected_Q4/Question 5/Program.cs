// See https://aka.ms/new-console-template for more information
using Question_5;

Console.WriteLine("Question 5\n");

List<Players> listOfPlayers = new List<Players>
{
    new Players("Greivin", 55),
    new Players("Alfred", 22),
    new Players("JP", 35),
    new Players("Jose", 47),
    new Players("Emily", 99),
    new Players("Jasmin", 12),
    new Players("Arthur", 29),
    new Players("Santi", 78),
    new Players("Charles", 27),
    new Players("Maria", 62)
};

string GetGeneration(int age)
{
    if (age <= 24) return "Gen Z";
    if (age <= 39) return "Millennials";
    if (age <= 54) return "Gen X";
    if (age <= 74) return "Boomers";
    return "Silent Generation";
}

void PrintList(List<Players> listOfPllayers)
{
    Console.WriteLine("Players in the list currently:");
    foreach(var player in listOfPllayers)
    {
        Console.WriteLine($"{player.Name} (Age: {player.Age})");
    }
}

PrintList(listOfPlayers);
Console.WriteLine();

//group the players
Console.WriteLine("Players grouped by generation:");
var groupedByGeneration = from player in listOfPlayers
                          group player by GetGeneration(player.Age) into generationGroup
                          select generationGroup;

foreach (var group in groupedByGeneration)
{
    Console.WriteLine($"{group.Key}:");
    foreach (var player in group)
    {
        Console.WriteLine($"  - {player.Name} ({player.Age})");
    }
}