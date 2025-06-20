// See https://aka.ms/new-console-template for more information

float CalculateAverage(List<float> grades)
{
    float total = 0;
    int numOfNums = 0;

    numOfNums = grades.Count;
    foreach (var grade in grades)
    {
        total += grade;
    }

    total /= numOfNums;

    return total;
}

List<float> grades = new List<float>
{
    55,
    76.5f,
    60,
    40,
    20,
    92
};
List<float> gradeNoFails = new List<float>();

Console.WriteLine("Question 3\n");

Console.Write("Grades: ");
foreach (var grade in grades)
{
    Console.Write(grade + ", ");
}

var query1 = from grade in grades
             where grade >= 55
             orderby grade ascending
             select grade;

foreach (var grade in query1)
{
    gradeNoFails.Add(grade);
}

Console.Write("\nGrades w/o fails: ");
foreach (var grade in query1)
{
    Console.Write(grade + ", ");
}

Console.WriteLine("\nAverage w/o fails: " + CalculateAverage(gradeNoFails));

