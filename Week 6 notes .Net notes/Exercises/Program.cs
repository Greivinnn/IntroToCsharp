// See https://aka.ms/new-console-template for more information

using Exercises;

string path = @"C:\LASALE FIRST YEAR STUFF\Introduction to C#\Week 6 notes .Net notes\Week 6 notes .Net notes\Data2.txt";
string path2 = @"C:\LASALE FIRST YEAR STUFF\Introduction to C#\Week 6 notes .Net notes\Week 6 notes .Net notes\Data.txt";
string path3 = @"C:\LASALE FIRST YEAR STUFF\Introduction to C#\Week 6 notes .Net notes\Week 6 notes .Net notes\Data3.txt";

List<string> names = new List<string>()
{
"ChantiG",
"JPinga",
"Alking",
"Bossvin"
};
using (StreamWriter writer = new StreamWriter(path))
{
    foreach (string s in names)
    {
        writer.WriteLine(s);
    }
}

List<int> numbersInList = new List<int>();

using (StreamReader reader = new StreamReader(path2))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        if(int.TryParse(line, out int number))
        {
            numbersInList.Add(number);  // add to list
            Console.WriteLine(number);  // or print them directly
        }
    }
}

Students student1 = new Students("JPinga", 1);
Students student2 = new Students("ChantiGG", 2);
Students student3 = new Students("ALCUM", 3);

using (StreamWriter writer = new StreamWriter(path3))
{
    writer.WriteLine(student1.Name + " || ID: " + student1.Id);
    writer.WriteLine(student2.Name + " || ID: " + student2.Id);
    writer.WriteLine(student3.Name + " || ID: " + student3.Id);
}


//foreach (int number in numbersInList)
//{
//    Console.WriteLine(number);
//}