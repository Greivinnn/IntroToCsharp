using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Zombie : Monsters
    {
        public override string MonsterName { get; set; }
        public override int MonsterAtk { get; set; }
        public override int MonstersDefense { get; set; }
        public override int MonstersHp { get; set; }
        public override int GoldDropped { get; set; }
        public override string MonsterType { get; set; }

        public override void BasicAttack(ref Character player)
        {
            // the Math.Max helps us with ensuring that the attack damage is always bigger than 1
            int attackDamage = Math.Max(MonsterAtk - player.Def, 1);

            player.CurrentHp = Math.Max(player.CurrentHp - attackDamage, 1);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{MonsterName} has attack {player.Name} dealing {attackDamage}!");
            Console.ResetColor();
        }
        public override void SpecialAttack(ref Character player)    // bites you and does 50% or 25% damage based on where he bite you
        {
            Random random = new Random();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Watch out! The {MonsterName} is sprinting towards you...");
            Console.ResetColor();

            int takeTwentyFive = player.CurrentHp / 4;
            int takeFifty = player.CurrentHp / 2;

            if (player.CurrentHp <= 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n{MonsterName}: Looks like your health is low. I will kill you in one bite!");
                Console.ResetColor();

                player.CurrentHp = 0;
            }
            else
            {
                if (random.Next(2) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nThe {MonsterName} has bitten you with his special attack on your left leg!");

                    player.CurrentHp -= takeTwentyFive;

                    Console.WriteLine($"You just lost: {takeTwentyFive}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nThe {MonsterName} has bitten you with his special attack on your chest!");

                    player.CurrentHp -= takeFifty;

                    Console.WriteLine($"You just lost: {takeFifty}");
                    Console.ResetColor();
                }
            }
            Console.ReadKey();
        }

        public override Monsters CreateCloneInstance()
        {
            return new Zombie(MonsterName, MonsterAtk, MonstersDefense, MonstersHp, GoldDropped);
        }

        public Zombie(string name, int atk, int def, int hp, int goldDropped)
            : base(name, atk, def, hp, goldDropped)
        {
            MonsterName = name;
            MonsterAtk = atk;
            MonstersDefense = def;
            MonstersHp = hp;
            GoldDropped = goldDropped;
            MonsterType = "Zombie";
        }
    }
}
