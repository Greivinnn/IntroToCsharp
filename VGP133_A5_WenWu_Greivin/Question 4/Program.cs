// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using Question_4;

string dir = System.AppDomain.CurrentDomain.BaseDirectory;
string path = dir + "Weapons.xml";

if (!File.Exists(path))
{
    Console.WriteLine("Weapons.xml file not found.");
    return;
}

List<Weapon> weapons = LoadWeaponsFromXml(path);

if (weapons.Count > 0)
{
    Console.WriteLine("Weapons loaded from XML:");
    foreach (var weapon in weapons)
    {
        weapon.PrintInfo();
        Console.WriteLine(); // Add a blank line between weapons
    }
}
else
{
    Console.WriteLine("No weapons found in the XML file.");
}

static List<Weapon> LoadWeaponsFromXml(string filePath)
{
    try
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Weapon>));
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return (List<Weapon>)serializer.Deserialize(fs);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while loading from XML: {ex.Message}");
        return new List<Weapon>();
    }
}
