// See https://aka.ms/new-console-template for more information

/*
 var query = from player in <Player Class>
             group player by <player.Age> into ageGroup
             where ageGorup.Key > 25
             select ageGroup;
 */

// Get people who names start with C
using Week_7___notes_LINQ;

List<string> names = new List<string>   //list
{
    "Cory", "Bob", "Charles", "Clipz", "Alfredo"
};

var query1 = from name in names //query (LINQ)
             where name.StartsWith("C")
             select name;

foreach(var name in query1)
{
    Console.WriteLine(name);
}

//Selects all odd numbers in a list of integers, and then orders them from highest to lowest.
int[] nums = { 33, 11, 12, 50, 25, 44, 77, 101 };

var query2 = from num in nums
             where num % 2 != 0
             orderby num descending
             select num;

foreach(var num in query2)
{
    Console.WriteLine(num);
}

// select num bigger than 50 and add the results together
var query3 = from num in nums
             where num > 50
             select num;

int total = 0;
foreach(var num in query3)
{
    total += num;
}
Console.WriteLine("Query 3 addition: " + total);

List<Person> people = new List<Person>();
people.Add(new Person("Fredo", 50));
people.Add(new Person("Jaden", 14));
people.Add(new Person("AysmanBulcarrado", 17));
people.Add(new Person("Santiago", 16));
people.Add(new Person("Juan", 28));
people.Add(new Person("Jose", 20));

//lambdas function
var filteredPerson = people.Where(x => x.Age < 21).OrderByDescending(x => x.Age).Select(x => x.Name.ToUpper());

// select person that age between 13-17 arrange from youngest to oldest
var query4 = from person in people
             where person.Age >= 13 && person.Age <= 17
             orderby person.Age ascending
             select person;
// select all whose name start with F and age 19 and above
var query5 = from person in people
             where person.Age >= 19 && person.Name.StartsWith("F")
             select person;
var query6 = from person in people
             where person.Name.Length > 12
             select person;

Console.WriteLine();
foreach (var person in query4)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}
Console.WriteLine();
foreach (var person in query5)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}
Console.WriteLine();
foreach (var person in query6)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}
Console.WriteLine();

foreach (var person in filteredPerson)
{
    Console.WriteLine(person);
}