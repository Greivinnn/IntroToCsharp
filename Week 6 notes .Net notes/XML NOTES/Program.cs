// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using XML_NOTES;

string dir = System.AppDomain.CurrentDomain.BaseDirectory;
Console.WriteLine(dir);

string path = dir + "Players.xml";
List<Player> players = new List<Player>();

var xmlSerializer = new XmlSerializer(typeof(List<Player>));
using (var reader = new StreamReader(path))
{
    players = (List<Player>)xmlSerializer.Deserialize(reader);
}

foreach(Player p in players)
{
    Console.WriteLine(p.name + " " + p.highScore);
}


//players.Add(new Player("Jpinga", 420));
//players.Add(new Player("chantiGG", 420));
//players.Add(new Player("ELCUM", 420));

//var xmlSerializer = new XmlSerializer(typeof(List<Player>));

//using (var writer = new StreamWriter(path))
//{
//    xmlSerializer.Serialize(writer, players);
//}

