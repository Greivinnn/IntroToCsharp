// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

void GreetingEnglish(string name)
{
    Console.WriteLine($"Hello {name}, how are you?");
}
void GreetingSpanish(string name)
{
    Console.WriteLine($"Hola {name}, como estas?");
}
void GreetingPortuguese(string name)
{
    Console.WriteLine($"olá {name}, como vai?");
}
void GreetingFrench(string name)
{
    Console.WriteLine($"Bonjour {name}, comment allez-vous?");
}
int Add(int x, int y)
{
    return x + y;
}
int Sub(int x, int y)
{
    return x - y;
}
int Mul(int x, int y)
{
    return x * y;
}
int Div(int x, int y)
{
    return x / y;
}

Greetings greetings = GreetingEnglish;
greetings += GreetingSpanish;
greetings += GreetingPortuguese;
greetings += GreetingFrench;

greetings("Alfredo");

Console.WriteLine("What would you like to calculate?");

Console.WriteLine("Enter the first number");
int num1 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the second number");
int num2 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter an operator (+, -, *, /):");
string operation = Console.ReadLine();

int result = 0;

Calculator calculate;

switch (operation)
{
    case "+":
        calculate = Add;
        result = calculate(num1, num2);
        Console.WriteLine($"Addition results: {result}");
        break;
    case "-":
        calculate = Sub;
        result = calculate(num1, num2);
        Console.WriteLine($"Substraction results: {result}");
        break;
    case "*":
        calculate = Mul;
        result = calculate(num1, num2);
        Console.WriteLine($"Multiplication results: {result}");
        break;
    case "/":
        if (num2 != 0)
        {
            calculate = Div;
            result = calculate(num1, num2);
            Console.WriteLine($"Division results: {result}");
        }
        else
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return;
        }
        break;
    default:
        Console.WriteLine("Invalid operator. Please use +, -, *, or /.");
        return;
}

delegate void Greetings(string name);
delegate int Calculator(int x, int y);