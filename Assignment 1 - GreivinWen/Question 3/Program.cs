// See https://aka.ms/new-console-template for more information

// #3 Remove guest function, remove the long names
void RemoveGuest(List<string> guestNames)
{
    List<string> filteredNames = guestNames.Where(guestNames => guestNames.Length <= 10).ToList(); //.Where is a LINQ method that filters the list based on a condition, in this case it checks for the lenght of a string
    Console.WriteLine("\nUpdated List:");
    for (int i = 0; i < filteredNames.Count; i++)
    {
        Console.WriteLine(filteredNames[i]);
    }
}

List<string> guestNames = new List<string>();
Console.WriteLine(@"Please enter the guests names (""done"" to exit and names over 10 characters will be deleted): ");

while (true)
{
    string userInput = Console.ReadLine();
    if (userInput == "done")
    {
        break;
    }
    else
    {
        guestNames.Add(userInput);
    }
}

Console.WriteLine("\nOriginal List:");
for(int i = 0; i < guestNames.Count; i++)
{
    Console.WriteLine(guestNames[i]);
}

RemoveGuest(guestNames);
