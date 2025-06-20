// See https://aka.ms/new-console-template for more information

// #1 Calculator Function
void CalculatorFunction(float x, float y, string opSymbol)
{
    float opResult;
    if (opSymbol == "+")
    {
        opResult = x + y;
        Console.WriteLine($"The addition result is: {opResult}");
    }
    else if (opSymbol == "-")
    {
        opResult = x - y;
        Console.WriteLine($"The substraction result is: {opResult}");
    }
    else if (opSymbol == "*")
    {
        opResult = x * y;
        Console.WriteLine($"The multiplication result is: {opResult}");
    }
    else if (opSymbol == "/")
    {
        opResult = x / y;
        Console.WriteLine($"The division result is: {opResult}");
    }
    else if(opSymbol == "%")
    {
        if (y != 0)
        {
            opResult = x % y; // Corrected modulus operation
            Console.WriteLine($"The modulus result is: {opResult}");
        }
        else
        {
            Console.WriteLine("Error: Modulus by zero is not allowed.");
        }

    }
    else
    {
        Console.WriteLine("Error, invalid symbol");
    }
}

float usernum1;
float usernum2;
string opSymbol;

Console.Write("Enter first number: ");
usernum1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Choose one operation symbol (+, -, *, /, %): ");
opSymbol = Console.ReadLine();

Console.Write("Enter second number: ");
usernum2 = Convert.ToInt32(Console.ReadLine());

CalculatorFunction(usernum1, usernum2, opSymbol);