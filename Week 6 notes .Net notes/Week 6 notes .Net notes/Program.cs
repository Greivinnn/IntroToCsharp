// See https://aka.ms/new-console-template for more information

string dir = System.AppDomain.CurrentDomain.BaseDirectory;
Console.WriteLine(dir);

string path = dir + "Data.txt";
string path2 = dir + "Data2.txt";

using (StreamReader reader = new StreamReader(path))
{
    string data = reader.ReadLine();

    while (data != null)
    {
        Console.WriteLine(data);
        data = reader.ReadLine();
    }
}
using (var writer = new StreamWriter(path2))
{
    writer.WriteLine("SELL");
}

if (File.Exists(path))
{
    string fileContent = File.ReadAllText(path);
    Console.WriteLine(fileContent);
}
else
{
    Console.WriteLine("ERROR FILE NOT FOUND.");
}

string newFile = "I AM THE LEADER OF THE LIONS";
File.WriteAllText(path, newFile);

StreamReader reader = new StreamReader(path);
string data = reader.ReadLine();

while (data != null)
{
    Console.WriteLine(data);
    data = reader.ReadLine();
}
reader.Close();

StreamWriter writer = new StreamWriter(path2);
writer.WriteLine("JP IM COMING FOR YOU hrhrrhrhrh");
writer.Close();

StreamReader reader2 = new StreamReader(path2);
string data2 = reader2.ReadLine();
while (data2 != null)
{
    Console.WriteLine(data2);
    data2 = reader2.ReadLine();
}
reader.Close();

string path3 = dir + "Data3.txt";

string name = "bob";
int hp = 50;
int str = 30;
int def = 10;
float money = 2.5f;

using (FileStream fs = new FileStream(path3, FileMode.Create, FileAccess.Write))
using (BinaryWriter writer = new BinaryWriter(fs))
{
    writer.Write(name);
    writer.Write(hp);
    writer.Write(str);
    writer.Write(def);
    writer.Write(money);
}
using (FileStream fs = new FileStream(path3, FileMode.Open, FileAccess.Read))
using (BinaryReader reader = new BinaryReader(fs))
{
    name = reader.ReadString();
    hp = reader.ReadInt32();
    str = reader.ReadInt32();
    def = reader.ReadInt32();
    money = reader.ReadSingle();
}

Console.WriteLine($"{name} - {hp} - {str} - {def} - {money}");





