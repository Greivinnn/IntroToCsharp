// See https://aka.ms/new-console-template for more information
using VGP133_Midterm_WenWu_Greivin;

Console.WriteLine("Testing stuff part");
//Instantiate two different Characters objects that belong to different job classes inside the main function
Ninja ninja = new Ninja
{
    MaxHp = 100,
    CurrentHp = 20,
    Attack = 30,
    Defence = 10
};

Mage mage = new Mage
{
    MaxHp = 80,
    CurrentHp = 100,
    Attack = 25,
    Defence = 5
};

Console.WriteLine("Ninja:");
ninja.DisplayStats();
Console.WriteLine($"Skill Damage: {ninja.CalculateSkillDamage()}");
Console.WriteLine();

Console.WriteLine("Mage:");
mage.DisplayStats();
Console.WriteLine($"Skill Damage: {mage.CalculateSkillDamage()}");
Console.WriteLine();

//Create a List of Weapons in main and instantiate three different objects in it.
List<Weapon> weapons = new List<Weapon>
{
    new Weapon(0, 10, 0), // Sword
    new Weapon(0, 15, 0), // Axe
    new Weapon(0, 8, 2)   // Dagger          
};
//Create a List of Armor in main and instantiate three different objects in it.
List<Armor> armors = new List<Armor>
{
    new Armor(20, 0, 5),  // Plate Armor
    new Armor(10, 0, 3),  // Leather Armor
    new Armor(5, 0, 1)    // Cloth Armor
};

//equip a weapon and armor
Console.WriteLine("Equipping weapon and armor test");
ninja.EquipWeapon(weapons[0], weapons);
ninja.EquipArmor(armors[0], armors);
ninja.DisplayStats();

Console.WriteLine("\nWeapons List After Equipping:");
foreach (var weapon in weapons)
{
    Console.WriteLine(weapon);
}
Console.WriteLine();    
//equip another weapon and armor
ninja.EquipWeapon(weapons[1], weapons);
ninja.EquipArmor(armors[1], armors);
ninja.DisplayStats();

Console.WriteLine("\nWeapons List After Equipping:");
foreach (var weapon in weapons)
{
    Console.WriteLine(weapon);
}

Console.WriteLine("\n\n\n\n\n\nREASLISTIC FIGHTING SIMULATOR");
Ninja ninjaForGame = new Ninja
{
    MaxHp = 100,
    CurrentHp = 100,
    Attack = 30,
    Defence = 10
};

Mage mageForGame = new Mage
{
    MaxHp = 120,
    CurrentHp = 110,
    Attack = 25,
    Defence = 5
};

List<Weapon> weaponsForGame = new List<Weapon>
{
    new Weapon(0, 10, 0), 
    new Weapon(0, 15, 0), 
    new Weapon(0, 8, 2),  
    new Weapon(0, 10, 0),
    new Weapon(0, 12, 0)
};
List<Armor> armorsForGame = new List<Armor>
{
    new Armor(15, 0, 5),  
    new Armor(10, 0, 3),  
    new Armor(5, 0, 1),
    new Armor(10, 0, 0),
    new Armor(11, 0, 0)
};

ninjaForGame.EquipWeapon(weaponsForGame[0], weaponsForGame);
ninjaForGame.EquipArmor(armorsForGame[0], armorsForGame);

mageForGame.EquipWeapon(weaponsForGame[1], weaponsForGame);
mageForGame.EquipArmor(armorsForGame[1], armorsForGame);

Character.Game(ninjaForGame, mageForGame, weaponsForGame, armorsForGame);

while(true)
{
    Console.WriteLine("That was a good game, would you like to go again?");
    Console.WriteLine("1. Yes, do everything again");
    Console.WriteLine("2. No, I wanna leave");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 1)
    {
        Character.Game(ninjaForGame, mageForGame, weaponsForGame, armorsForGame);
    }
    else
    {
        Console.WriteLine("Thank you for playing, goodbye!");
        break;
    }
}

