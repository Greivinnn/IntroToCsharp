// See https://aka.ms/new-console-template for more information

// #4 Check for contrabands coming in (Cigarette, Drugs, Gun, Weed)
void CheckContrabands(List<string> userItems)
{
    bool drugFound = false;
    List<string> contrabandsFound = new List<string>();
    int numberOfContrabands = 0;

    for (int i = 0; i < userItems.Count; i++)
    {
        string item = userItems[i].ToLower();   // this sets the first letter to lower case, in case the first letter is capital letter
        if(item == "cigarette" || item == "drugs" || item == "gun" || item == "weed")
        {
            drugFound = true;
            if(drugFound)
            {
                contrabandsFound.Add(userItems[i]);
                numberOfContrabands++;
            }
        }
    }
    
    if (!drugFound)
    {
        Console.WriteLine("\nNo contrabrands were found in your items.");
        Console.WriteLine(numberOfContrabands + " were confiscated from you.");
    }
    else
    {
        Console.WriteLine("\nContraband Found:");
        foreach (string item in contrabandsFound)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(numberOfContrabands + " were confiscated from you.");
    }
}

List<string> contrabandsFound = new List<string>();

Console.WriteLine("Welcome, to Vancouver International Airport\n");
Console.WriteLine(@"Illegal items such as: ""cigarette"", ""drugs"", ""gun"", and ""weed"". Thank you for complying with the rules." + "\n");
Console.WriteLine(@"Please input the items you are bringing into the country (press ""done"" when finished): ");

while (true)
{
    string userInput = Console.ReadLine();
    if (userInput == "done")
    {
        break;
    }
    else
    {
        contrabandsFound.Add(userInput);
    }
}

CheckContrabands(contrabandsFound);

