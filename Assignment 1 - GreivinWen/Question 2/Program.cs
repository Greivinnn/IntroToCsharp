// See https://aka.ms/new-console-template for more information

// #2 Calculate final grade excluding lowest number in the list
void CalculateFinalGrade(List<float> grades)
{
    Console.Write("\nThe new average without " + grades.Min() + " is: ");
    grades.Remove(grades.Min());
    Console.WriteLine(grades.Average());
}

List<float> grades = new List<float>();
Console.WriteLine("Input grades (to exit input -1): ");
while (true)
{
    float userInput = Convert.ToInt32(Console.ReadLine());
    if (userInput == -1)
    {
        break;
    }
    else
    {
        grades.Add(userInput);
    }
}

Console.WriteLine("Original grades average: " + grades.Average());
CalculateFinalGrade(grades);