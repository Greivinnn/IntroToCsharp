// See https://aka.ms/new-console-template for more information
// variables
string name = "JP";
string name2 = "alfred";
string nameWithSpace = "    chanti      ";
int age = 999;
int x = 10;
int y = 20;
int sum = x + y;
int difference = x - y;
int multiplication = x * y;
int quotient = x / y;
float deciMal = 1.2f;
int deci1 = (int)1.3;
int deci2 = (int)2.2;
long deci3 = checked(deci1 + deci2);

// using string interpolation 
Console.WriteLine($"King of Mine Craft, {name} and {name2}");

// regular print with string concatenation
Console.WriteLine("Queen of mineCaraft! " + name2 + " he is " + age + " old asf");

// helps you output whatever with no restrictions 
Console.WriteLine(@"Yoooo how // // / \ \\ \\ is my gente de sona ""are you guys"" doing okay or what?");

// names can have spaces 
Console.WriteLine(nameWithSpace);
nameWithSpace = nameWithSpace.Trim();   // gets rid of the space 
Console.WriteLine(nameWithSpace);

// Math (+, -, *, /)
Console.WriteLine($"{x} + {y} = {sum}");
Console.WriteLine($"{x} - {y} = {difference}");
Console.WriteLine($"{x} * {y} = {multiplication}");
Console.WriteLine($"{x} / {y} = {quotient}");

// decimal addition
Console.WriteLine($"{deci1} + {deci2} = {deci3}");

// get input from the user 
Console.WriteLine("Enter your name: ");
string nameUser = Console.ReadLine();
Console.WriteLine("Your name: " + nameUser);

// if statement
//Console.WriteLine("1 - Go Left");
//Console.WriteLine("2 - Go Right");
//int choice = Convert.ToInt32(Console.ReadLine()); 
//if (choice == 1)
//{
//    Console.WriteLine("You went left.");
//}
//else if(choice == 2)
//{
//    Console.WriteLine("You went right.");
//}

Console.WriteLine("1 - Go Left");
Console.WriteLine("2 - Go Right");

int choice = 1;
Int32.TryParse(Console.ReadLine(), out choice);
if (choice == 1)
{
    Console.WriteLine("You went left.");
}
else if(choice == 2)
{
    Console.WriteLine("You went right.");
}
else
{
    Console.WriteLine("Error.");
}

//Ternary Operator (?)
int userAge = 25;
bool canDrink = userAge >= 19 ? true : false;   // is a fast and short if statement

//Foreach to iterate through something
string[] students = { "JP", "Alfred", "Santi", "Emir" };
foreach (var student in students)   // we can use var for long datatypes, is alike auto in c++
{
    Console.WriteLine(student);
}