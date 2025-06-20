using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Midterm_WenWu_Greivin
{
    public class Character
    {
        private int _currentHp;
        private int _maxHp;
        private int _attack;
        private int _defence;
        private Weapon _equippedWeapon;
        private Armor _equippedArmor;

        public int MaxHp
        {
            get { return _maxHp; }
            set { _maxHp = value; }
        }
        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public int Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }
        public int CurrentHp
        {
            get { return _currentHp; }
            set
            {
                if (value > _maxHp)
                {
                    _currentHp = _maxHp;
                }
                else if (value < 0)
                {
                    _currentHp = 0;
                }
                else
                {
                    _currentHp = value;
                }
            }
        }
        public Weapon EquippedWeapon
        {
            get { return _equippedWeapon; }
        }

        public Armor EquippedArmor
        {
            get { return _equippedArmor; }
        }

        public void DisplayStats()
        {
            Console.WriteLine("Character Stats:");
            Console.WriteLine($"Current HP: {CurrentHp}");
            Console.WriteLine($"Max HP: {MaxHp}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defence: {Defence}");
            Console.WriteLine($"Equipped Weapon: {(_equippedWeapon != null ? _equippedWeapon.ToString() : "None")}"); // check if the equipped weapon is null or not and displays a message "None" if null
            Console.WriteLine($"Equipped Armor: {(_equippedArmor != null ? _equippedArmor.ToString() : "None")}");
        }

        public virtual int CalculateSkillDamage()
        {
            return Attack;
        }

        // EquipWeapon method
        public void EquipWeapon(Weapon newWeapon, List<Weapon> weaponsList)
        {
            if (newWeapon == null || weaponsList == null)
                throw new ArgumentNullException("Weapon or weapons list cannot be null.");  // this make sure our EquipWeapon Method does not crash if the list is empty

            // Unequip the currently equipped weapon
            if (_equippedWeapon != null)
            {
                weaponsList.Add(_equippedWeapon); // Add the currently equipped weapon back to the list
            }

            // Equip the new weapon
            _equippedWeapon = newWeapon;
            weaponsList.Remove(newWeapon); // Remove the new weapon from the list
        }
        //same logic for armor
        public void EquipArmor(Armor newArmor, List<Armor> armorList)
        {
            if (newArmor == null || armorList == null)
                throw new ArgumentNullException("Armor or armors list cannot be null.");

            if (_equippedArmor != null)
            {
                armorList.Add(_equippedArmor);
            }
            _equippedArmor = newArmor;
            armorList.Remove(newArmor);
        }
        public int BasicAttack(Character character)
        {
            if (character._equippedWeapon != null)
            {
                return _attack + _equippedWeapon.AtkBonus;
            }
            else
            {
                return _attack;
            }
        }
        public int SpecialSkillAttack(Character character)
        {
            Random random = new Random();
            bool isSuccessful = random.Next(0, 2) == 0; // 50% chance (0 or 1)

            if (isSuccessful)
            {
                int newDamage = _attack + CalculateSkillDamage();
                Console.WriteLine("The special attack was succesfull!");
                return newDamage;
            }
            else
            {
                Console.WriteLine("Special attack has MISSED!");
                return 0;
            }
        }
        public static void Game(Character player1, Character player2, List<Weapon> weapons, List<Armor> armors)
        {
            Console.WriteLine("Player 1 stats:");
            player1.DisplayStats();
            Console.WriteLine("\nPlayer 2 stats:");
            player2.DisplayStats();
            Console.WriteLine();
            if (player1.EquipArmor != null)
            {
                player1._maxHp += player1._equippedArmor.HpBonus;
                player1._currentHp += player1._maxHp;
            }
            if (player2.EquipArmor != null)
            {
                player2._maxHp += player1._equippedArmor.HpBonus;
                player2._currentHp += player1._maxHp;
            }

            Random random = new Random();
            bool isSuccessful = random.Next(0, 2) == 0; // 50% chance (0 or 1)

            if (isSuccessful) // player 1 starts
            {
                Console.WriteLine("Flipping coin...");
                Console.WriteLine("Player 1 starts");
                while (true)
                {
                    Console.WriteLine("Player 1 Current HP: " + player1._currentHp);
                    Console.WriteLine("Player 2 Current HP: " + player2._currentHp);
                    Console.WriteLine();
                    Console.WriteLine("Player 1 turn");
                    Console.WriteLine("Choose your move");
                    Console.WriteLine("1. Basic Attack || 2. Special Attack (50/50)");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Chose BASIC ATTACK!");
                        player2._currentHp -= player1.BasicAttack(player1);
                        Console.WriteLine("Player 1 has damaged player 2 by " + player1.BasicAttack(player1));
                    }
                    else
                    {
                        Console.WriteLine("Chose SPECIAL ATTACK");
                        Console.WriteLine("50% chance of missing taken");
                        if (player1.SpecialSkillAttack(player1) == 0)
                        {
                            Console.WriteLine("Special skill missed the opponent by 3.3333 cm, 0 damage dealt");
                        }
                        else
                        {
                            player2._currentHp = player1.SpecialSkillAttack(player1);
                            Console.WriteLine("SPECIAL SKILL HAS HIT");
                            Console.WriteLine("You dealth: " + player1.SpecialSkillAttack(player1));
                        }
                    }
                    Console.WriteLine("Player 2 turn");
                    Console.WriteLine("Choose your move");
                    Console.WriteLine("1. Basic Attack || 2. Special Attack (50/50)");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Chose BASIC ATTACK!");
                        player1._currentHp -= player2.BasicAttack(player2);
                        Console.WriteLine("Player 2 has damaged player 1 by " + player2.BasicAttack(player2));
                    }
                    else
                    {
                        Console.WriteLine("Chose SPECIAL ATTACK");
                        Console.WriteLine("50% chance of missing taken");
                        if (player2.SpecialSkillAttack(player2) == 0)
                        {
                            Console.WriteLine("Special skill missed the opponent by 3.3333 cm, 0 damage dealt");
                        }
                        else
                        {
                            player1._currentHp = player2.SpecialSkillAttack(player2);
                            Console.WriteLine("SPECIAL SKILL HAS HIT");
                            Console.WriteLine("You dealth: " + player2.SpecialSkillAttack(player2));
                        }
                    }
                    if (player1._currentHp <= 0)
                    {
                        Console.WriteLine("K.O.");
                        break;
                    }
                    if (player2._currentHp <= 0)
                    {
                        Console.WriteLine("K.O.");
                        break;
                    }
                }
                if (player1._currentHp <= 0)
                {
                    Console.WriteLine("CONGRATULATIONS PLAYER 2, YOU WON!");
                }
                if (player2._currentHp <= 0)
                {
                    Console.WriteLine("CONGRATULATIONS PLAYER 1, YOU WON!");
                }
            }
            else //player 2 starts
            {
                Console.WriteLine("Flipping coin...");
                Console.WriteLine("Player 2 starts");
                while (true)
                {
                    Console.WriteLine("Player 1 Current HP: " + player1._currentHp);
                    Console.WriteLine("Player 2 Current HP: " + player2._currentHp);
                    Console.WriteLine();
                    Console.WriteLine("Player 2 turn");
                    Console.WriteLine("Choose your move");
                    Console.WriteLine("1. Basic Attack || 2. Special Attack (50/50)");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Chose BASIC ATTACK!");
                        player1._currentHp -= player2.BasicAttack(player2);
                        Console.WriteLine("Player 2 has damaged player 1 by " + player2.BasicAttack(player2));
                    }
                    else
                    {
                        Console.WriteLine("Chose SPECIAL ATTACK");
                        Console.WriteLine("50% chance of missing taken");
                        if (player2.SpecialSkillAttack(player2) == 0)
                        {
                            Console.WriteLine("Special skill missed the opponent by 3.3333 cm, 0 damage dealt");
                        }
                        else
                        {
                            player1._currentHp = player2.SpecialSkillAttack(player2);
                            Console.WriteLine("SPECIAL SKILL HAS HIT");
                            Console.WriteLine("You dealth: " + player2.SpecialSkillAttack(player2));
                        }
                    }
                    Console.WriteLine("Player 1 turn");
                    Console.WriteLine("Choose your move");
                    Console.WriteLine("1. Basic Attack || 2. Special Attack (50/50)");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Chose BASIC ATTACK!");
                        player2._currentHp -= player1.BasicAttack(player1);
                        Console.WriteLine("Player 1 has damaged player 2 by " + player1.BasicAttack(player1));
                    }
                    else
                    {
                        Console.WriteLine("Chose SPECIAL ATTACK");
                        Console.WriteLine("50% chance of missing taken");
                        if (player1.SpecialSkillAttack(player1) == 0)
                        {
                            Console.WriteLine("Special skill missed the opponent by 3.3333 cm, 0 damage dealt");
                        }
                        else
                        {
                            player2._currentHp = player1.SpecialSkillAttack(player1);
                            Console.WriteLine("SPECIAL SKILL HAS HIT");
                            Console.WriteLine("You dealth: " + player1.SpecialSkillAttack(player1));
                        }
                    }
                    if (player1._currentHp <= 0)
                    {
                        Console.WriteLine("K.O.");
                        break;
                    }
                    if (player2._currentHp <= 0)
                    {
                        Console.WriteLine("K.O.");
                        break;
                    }
                }
                if (player1._currentHp <= 0)
                {
                    Console.WriteLine("CONGRATULATIONS PLAYER 2, YOU WON!");
                }
                if (player2._currentHp <= 0)
                {
                    Console.WriteLine("CONGRATULATIONS PLAYER 1, YOU WON!");
                }
            }
        }
    }
}
