// See https://aka.ms/new-console-template for more information

// #4 Check for contrabands coming in (Cigarette, Drugs, Gun, Weed)
void CheckContrabands(List<string> userItems)
{
    bool drugFound = false;
    List<string> contrabandsFound = new List<string>();
    int numberOfContrabands = 0;

    for (int i = 0; i < userItems.Count; i++)
    {
        if(userItems[i] == "Cigarrette" || userItems[i] == "Drugs" || userItems[i] == "Gun" || userItems[i] == "Weed")
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
        Console.WriteLine("No contrabrands where found in your items.");
        Console.WriteLine(numberOfContrabands + " where confiscated from you.");
    }
    else
    {
        Console.WriteLine("Contraband Found:");
        foreach (string item in contrabandsFound)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(numberOfContrabands + " where confiscated from you.");
    }
}

List<string> 
