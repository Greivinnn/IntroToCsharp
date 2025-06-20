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
int Damage(int num)
{
    return num * 2 + 14;
}
void Add(int x, int y)
{
    Console.WriteLine(x + y);
}
void Substract(int x, int y)
{
    Console.WriteLine(x - y);
}

AttackDeletegate attackAction;
attackAction = MeleeAttack;
attackAction();

attackAction = RangeAttack;
attackAction();

CritDamage critDamage = DoCritDamage;
critDamage(100);

DoDamage damageDealth = Damage;
damageDealth(100);

Console.WriteLine(damageDealth(100));

// stacking delegates. making it do 2 stuff at once
MysteryCalculator calculator = Add;
calculator += Substract;
calculator(20, 7);

delegate void AttackDeletegate();
delegate void CritDamage(int num);
delegate int DoDamage(int num); 
delegate void MysteryCalculator(int x, int y);

