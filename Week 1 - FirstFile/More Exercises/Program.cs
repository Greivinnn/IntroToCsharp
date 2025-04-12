// See https://aka.ms/new-console-template for more information

// #1 prints all numbers above 50
int[] arrayOfFive = { 22, 15, 66, 100, 19 };
foreach (var item in arrayOfFive)
{
    if(item > 50)
    {
        Console.WriteLine($"This number is greater than 50: {item}");
    }
}

// #2 calculates the average of 4 grades
int grade1;
int grade2;
int grade3;
int grade4;
int gradeSum;
int gradeAvg;

Console.WriteLine("Enter the first grade: ");
grade1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the second grade: ");
grade2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the third grade: ");
grade3 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the fourth grade: ");
grade4 = Convert.ToInt32(Console.ReadLine());

gradeSum = grade1 + grade2 + grade3 + grade4;
gradeAvg = gradeSum / 4;

Console.WriteLine($"Your average is: {gradeAvg}");
string result = gradeAvg >= 60 ? "Pass" : "Fail";
Console.WriteLine($"You have {result}!");

// #3 simple calculator using +, -, *, /
Console.WriteLine("Greivin's Calculator\n");

float usernum1;
float usernum2;
string opSymbol;
float opResult;

Console.Write("Enter first number: ");
usernum1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Choose one operation symbol: ");
opSymbol = Console.ReadLine();

Console.Write("Enter second number: ");
usernum2 = Convert.ToInt32(Console.ReadLine());

if (opSymbol == "+")
{
    opResult = usernum1 + usernum2;
    Console.WriteLine($"The addition result is: {opResult}");
}
else if(opSymbol == "-")
{
    opResult = usernum1 - usernum2;
    Console.WriteLine($"The substraction result is: {opResult}");
}
else if(opSymbol == "*")
{
    opResult = usernum1 * usernum2;
    Console.WriteLine($"The multiplication result is: {opResult}");
}
else if (opSymbol == "/")
{
    opResult = usernum1 / usernum2;
    Console.WriteLine($"The division result is: {opResult}");
}

