// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using Question_3;

string dir = System.AppDomain.CurrentDomain.BaseDirectory;
string path = dir + "Weapons.xml";
List<Weapon> weapons = new List<Weapon>();

Console.Write("How many weapons do you want to add? ");
string input = Console.ReadLine();
if(int.TryParse(input, out int numberOfWeapons))
{
    Console.WriteLine($"Adding {numberOfWeapons} to Weapons.xml"); 
    for (int i = 0; i < numberOfWeapons; i++)
    {
        Console.WriteLine($"Enter details for weapon {1 + i}");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Attack Power: ");
        int damage = int.TryParse(Console.ReadLine(), out int dmg) ? dmg : 0;

        Console.Write("Strenght Required To Operate: ");
        int stgPower = int.TryParse(Console.ReadLine(),out int stg) ? stg : 0;

        Console.Write("Owner Name: ");
        string ownerName = Console.ReadLine();

        weapons.Add(new Weapon
        {
            Name = name,
            AtkPower = damage,
            StrenghtRequirement = stgPower,
            OwnerName = ownerName
        });
    }
    SaveWeaponsToXml(weapons, path);
    Console.WriteLine($"Weapons saved to {path}");
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}

static void SaveWeaponsToXml(List<Weapon> weapons, string filePath)
{
    try
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Weapon>));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, weapons);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while saving to XML: {ex.Message}");
    }
}