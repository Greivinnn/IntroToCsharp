// See https://aka.ms/new-console-template for more information

// List<T> is similar to a vector in C++

List<int> scores = new List<int>() {2, 3, 5, 6 };
List<float> grades = new List<float>() { 3.2f, 10.2f, 5.5f, 9.8f };
List<string> names = new List<string>() { "Dani", "Son", "Kun" };

scores.Add(66);
names.Add("JP");
names.Add("Melo");
names.Add("Mam");

names.RemoveRange(0, 2);

foreach (var score in scores)
{
    Console.WriteLine(score);
}
foreach (var grade in grades)
{
    Console.WriteLine(grade);
}

foreach (var name in names)   // you can determine where the iteration starts and ends, this starts from 1 and ends at 2 not printing 2
{
    Console.WriteLine(name);
}

