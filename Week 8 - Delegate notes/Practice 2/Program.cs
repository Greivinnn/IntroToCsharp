// See https://aka.ms/new-console-template for more information

int Add(int x, int y, int z)
{
    return x + y + z;
}
int Mul(int x, int y, int z)
{
    return x * y * z;
}
void Print(string message, int times)
{
    for(int i = 0; i < times; i++)
    {
        Console.WriteLine(""
    }
}

Func<int, int, int, int> func;
func = Add;
Console.WriteLine(func(1, 1, 1));
func += Mul;
Console.WriteLine(func(1, 1, 1));