using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Barbarian : Monsters
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
        public override void SpecialAttack(ref Character player)    // fills up with rage doing 3 his normal damage
        {
            int rageAttack = MonsterAtk * 3;

            if (player.CurrentHp > 1)
            {
                player.CurrentHp = Math.Max(player.CurrentHp - rageAttack, 1);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"The {MonsterName} is furious! He is charging his special attack. WATCH OUT!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{MonsterName} has used its rage attack on {player.Name} dealing a total of {rageAttack}!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{MonsterName}: Looks like you are very weak. This is my opportunity!");
                player.CurrentHp = 0;
            }
            Console.ReadKey();
        }

        public override Monsters CreateCloneInstance()
        {
            return new Barbarian(MonsterName, MonsterAtk, MonstersDefense, MonstersHp, GoldDropped);
        }

        public Barbarian(string name, int atk, int def, int hp, int goldDropped)
            : base(name, atk, def, hp, goldDropped)
        {
            MonsterName = name;
            MonsterAtk = atk;
            MonstersDefense = def;
            MonstersHp = hp;
            GoldDropped = goldDropped;
            MonsterType = "Barbarian";
        }
    }
}
