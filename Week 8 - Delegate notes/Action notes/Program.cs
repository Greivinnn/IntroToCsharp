// See https://aka.ms/new-console-template for more information
void MeleeAttack()
{
    Console.WriteLine("Melee attack");
}
void RangeAttack()
{
    Console.WriteLine("Ranged attack");
}
void DoCritDamage(int num)
{
    Console.WriteLine($"CritDamage: {num * 2}");
}
void Hello(string name, int age)
{
    Console.WriteLine($"Hello {name} you are {age} old");
}
float DoCrit(int dmg)
{
    return dmg * 2;
}
Action action = MeleeAttack;
action += RangeAttack;
action();
action -= RangeAttack;
action();

Action<int> actionWithInt;
actionWithInt = DoCritDamage;
actionWithInt(200);

Action<string, int> actionWithIntAndString;
actionWithIntAndString = Hello;
actionWithIntAndString("JP", 999);

Func<int, float> func;
func = DoCrit;
Console.WriteLine(func(100));

// lambdas

Action actionLambdas = () =>
{
    Console.WriteLine("Alfred pass me the ketchup");
};

Action<int> action2 = (int luckyNum) =>
{
    Console.WriteLine($"Lucku Number is: {luckyNum}");
};

actionLambdas();
action2(55);
