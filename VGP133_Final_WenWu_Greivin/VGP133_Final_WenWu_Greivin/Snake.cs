using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Snake : Monsters
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
        public override void SpecialAttack(ref Character player)    // coils you around and doesnt let you flee
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{MonsterName} used its special attack! It coils around you, preventing you from fleeing!");
            Console.ResetColor();

            // Disable fleeing for the player
            player.CanFlee = false;
            Console.ReadKey();
        }

        public override Monsters CreateCloneInstance()
        {
            return new Snake(MonsterName, MonsterAtk, MonstersDefense, MonstersHp, GoldDropped);
        }

        public Snake(string name, int atk, int def, int hp, int goldDropped)
            : base(name, atk, def, hp, goldDropped)
        {
            MonsterName = name;
            MonsterAtk = atk;
            MonstersDefense = def;
            MonstersHp = hp;
            GoldDropped = goldDropped;
            MonsterType = "Snake";
        }
    }
}
