// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using VGP133_Final_WenWu_Greivin;

void LocationName()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("╔════════════════════════════════════╗");
    Console.WriteLine("║     Current World: Main Central    ║");
    Console.WriteLine("╚════════════════════════════════════╝");
    Console.ResetColor();
}

void PrintSaveArt()
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(@"
 _______  _______           _______    _______  _______  _______  _______ 
(  ____ \(  ___  )|\     /|(  ____ \  (  ____ \(  ___  )(       )(  ____ \
| (    \/| (   ) || )   ( || (    \/  | (    \/| (   ) || () () || (    \/
| (_____ | (___) || |   | || (__      | |      | (___) || || || || (__    
(_____  )|  ___  |( (   ) )|  __)     | | ____ |  ___  || |(_)| ||  __)   
      ) || (   ) | \ \_/ / | (        | | \_  )| (   ) || |   | || (      
/\____) || )   ( |  \   /  | (____/\  | (___) || )   ( || )   ( || (____/\
\_______)|/     \|   \_/   (_______/  (_______)|/     \||/     \|(_______/                                                             
");
    Console.ResetColor();
}
void PrintLoadArt()
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(@"
 _        _______  _______  ______     _______  _______  _______  _______ 
( \      (  ___  )(  ___  )(  __  \   (  ____ \(  ___  )(       )(  ____ \
| (      | (   ) || (   ) || (  \  )  | (    \/| (   ) || () () || (    \/
| |      | |   | || (___) || |   ) |  | |      | (___) || || || || (__    
| |      | |   | ||  ___  || |   | |  | | ____ |  ___  || |(_)| ||  __)   
| |      | |   | || (   ) || |   ) |  | | \_  )| (   ) || |   | || (      
| (____/\| (___) || )   ( || (__/  )  | (___) || )   ( || )   ( || (____/\
(_______/(_______)|/     \|(______/   (_______)|/     \||/     \|(_______/                                                                                                                          
");
    Console.ResetColor();
}

Character CreateCharacter()
{
    while (true)
    {
        Console.Clear();
        Console.Write("Please create your character:");
        Console.Write("\n\nWhat is your name? ");
        string name = Console.ReadLine();
        Console.Write("\nWhat hair color would you like? ");
        string hairColor = Console.ReadLine();
        char gender;

        while (true)
        {
            Console.Write("\nWhat gender are you? (M, F, X) ");
            string genderInput = Console.ReadLine();

            // Validate input
            if (!string.IsNullOrEmpty(genderInput) && genderInput.Length == 1)
            {
                gender = char.ToUpper(genderInput[0]); // Convert to uppercase for consistency
                if (gender == 'M' || gender == 'F' || gender == 'X')
                {
                    break; // Valid input, exit the loop
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nInvalid input. Please enter 'M', 'F', or 'X'.");
            Console.ResetColor();
        }
        Console.Write("\nHow old are you? ");
        string ageInput = Console.ReadLine();
        if (!int.TryParse(ageInput, out int age))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error, please input a valid age number\n");
            Console.WriteLine("(Press any key to continue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }

        Character newPlayer = new Character(name, hairColor, gender, age);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nCharacter successfully created! Welcome and have fun {name}");

        Console.WriteLine("(Press any key to continue)");
        Console.ResetColor();
        Console.ReadKey();

        return newPlayer;
    }
}


LocationManager locationManager = new LocationManager();
Character player = CreateCharacter();
while (true)
{
    Console.Clear();
    locationManager.PrintGameTitle();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    LocationName();
    Console.ResetColor();

    locationManager.PrintBanner(ref player);
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    locationManager.PrintWeaponBox(ref player);
    Console.ResetColor();

    Console.WriteLine("\nPlease choose your next destination:");
    Console.WriteLine("1. (Safe Town) - Refill HP to max & buy items in store");
    Console.WriteLine("2. (Wicked Forest) - Gamble your luck, 50% monster fight or 50% loot crate");
    Console.WriteLine("3. (Rocky Mountains) - Gamble your luck, 50% stronger monsters or 50% better loot crate");
    Console.WriteLine("4. (Boss Cave) - Rumors of 3 very strong monsters in this cave, one of them is the king of the monsters");
    Console.WriteLine("5. (Inventory) - Check whats in your inventory");
    Console.WriteLine("6. (Save Game) - Save all your progress");
    Console.WriteLine("7. (Load Game) - Load previous progress");

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(@"""q"" to exit");
    Console.ResetColor();
    Console.Write("\nChoice: ");

    string choice = Console.ReadLine();

    if (choice == "m")
    {
        locationManager.EquipmentInventory(ref player);
    }

    if (choice == "q")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nExiting game...");
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ResetColor();
        Console.ReadKey();
        return;
    }

    if (!int.TryParse(choice, out int outChoice) && choice != "q" && choice != "m")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nError, please input a valid number\n");
        Console.WriteLine("(Press any key to coninue)");
        Console.ResetColor();
        Console.ReadKey();
        continue;
    }

    if (outChoice == 1)
    {
        Console.Clear();
        locationManager.PrintGameTitle();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Heading to Safe Town...");
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ResetColor();
        Console.ReadKey();
        locationManager.GoToTown(ref player);
    }
    else if(outChoice == 2)
    {
        Console.Clear();
        locationManager.PrintGameTitle();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Heading to Wicked Forest...");
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ResetColor();
        Console.ReadKey();
        locationManager.GoToForest(ref player);
    }
    else if (outChoice == 3)
    {
        Console.Clear();
        locationManager.PrintGameTitle();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Heading to Rocky Mountains...");
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ResetColor();
        Console.ReadKey();
        locationManager.GoToMountains(ref player);
    }
    else if(outChoice == 4)
    {
        Console.Clear();
        locationManager.PrintGameTitle();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Heading to Inferno's Castle...");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nGet ready, the boss is no joke...");
        Console.WriteLine("Legends say the boss is always guarded by 2 monsters!");
        Console.WriteLine("Good luck!");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ResetColor();
        Console.ReadKey();
        locationManager.GoToBossCastle(ref player);
    }
    else if (outChoice == 5)
    {
        Console.Clear();
        if (player.Items.Count == 0)
        {
            locationManager.PrintGameTitle();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Looks like you have nothing in your inventory yet...");
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }
        else
        {
            locationManager.PrintGameTitle();
            locationManager.PrintInventory(ref player);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }
    }
    else if (outChoice == 6)
    {
        Console.Clear();
        PrintSaveArt();
        Console.WriteLine("Save all your progress here");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n(\"q\" to exit)\n");
        Console.ResetColor();
        SaveManager.ShowSaveSlots();
        Console.Write("\nSelect a slot (1-3): ");
        string slot = Console.ReadLine();

        if (slot == "q")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nExiting save menu...");
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }

        if (!int.TryParse(slot, out int outChoice2) && slot != "q")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError, please input a valid number\n");
            Console.WriteLine("(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }

        if (outChoice2 == 1 || outChoice2 == 2 || outChoice2 == 3 && slot != "q")
        {
            SaveManager.SaveGame(player, outChoice2);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError, please input a valid number\n");
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ReadKey();
    }
    else if(outChoice == 7)
    {
        Console.Clear();
        PrintLoadArt();
        Console.WriteLine("Load your progress here");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n(\"q\" to exit)\n");
        Console.ResetColor();
        SaveManager.ShowSaveSlots();
        Console.Write("\nSelect slot (1-3): ");

        string slot2 = Console.ReadLine();
        Console.WriteLine();
        if (slot2 == "q")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nExiting load menu...");
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }

        if (!int.TryParse(slot2, out int outChoice3) && slot2 != "q")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError, please input a valid number\n");
            Console.WriteLine("(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
            continue;
        }

        Character loaded = SaveManager.LoadGame(outChoice3);

        if (loaded != null)
        {
            player = loaded;
            Console.WriteLine($"Game loaded for player {player.Name}.");
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n(Press any key to coninue)");
        Console.ReadKey();
    }
}

