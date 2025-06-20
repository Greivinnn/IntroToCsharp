// See https://aka.ms/new-console-template for more information

string dir = System.AppDomain.CurrentDomain.BaseDirectory;
string file = dir + "Names.txt";

List<string> names = new List<string>()
{
    "JP",
    "CHANTI",
    "BOBY",
    "Fred",
    "SantaClaus"
};
while (true)
{
    Console.WriteLine("Enter a name (or 'done' to quit):");
    string input = Console.ReadLine();
    if (input.ToLower() == "done")
    {
        break;
    }
    names.Add(input);
}
using (StreamWriter writer = new StreamWriter(file))
{
    foreach (string name in names)
    {
        writer.WriteLine(name);
    }
}
try
{
    using (StreamReader reader = new StreamReader(file))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
    throw;
}
