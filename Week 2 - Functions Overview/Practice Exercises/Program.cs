// See https://aka.ms/new-console-template for more information

// #1 Return the average of the grades inputted in the list
List<float> grades = new List<float>() { 60.89f, 55.78f, 80.66f, 90.11f };
Console.WriteLine(grades.Average());

// #2 Add three more numbers and remove the first index[0]
grades.Remove(0);
grades.Add(89.55f);
grades.Add(90.33f);
grades.Add(66.12f);

Console.WriteLine("New average: " + grades.Average());

// #3 Remove the lowest number in the list
grades.Remove(grades[0]);
Console.WriteLine("New average: " + grades.Average());

// #4 User input names and then print them out
List<string> names = new List<string>();

Console.WriteLine(@"Please enter names (to exit type ""done""):" + "\n");

while (true)
{
    string userOption = Console.ReadLine();
    if (userOption == "done")
    {
        break;
    }
    else
    {
        names.Add(userOption);
    }
}

Console.WriteLine("Final List Of Names: ");
foreach(string name in names)
{
    Console.WriteLine(name);
}

