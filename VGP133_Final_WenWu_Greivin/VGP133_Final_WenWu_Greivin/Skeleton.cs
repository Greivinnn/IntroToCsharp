using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Skeleton : Monsters
    {
        private int _originalAtk;
        public int OriginalAtk
        {
            get { return _originalAtk; }
            set { _originalAtk = value; }
        }

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
        public override void SpecialAttack(ref Character player)    // takes out a bone and use it as a sword buffing its basic attack
        {
            Random random = new Random();

            int atkBuff = 10;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"The {MonsterName} has taken out a part of his body...");
            Console.WriteLine($"It is its right femur! Watch out that might do some damage!");
            Console.ForegroundColor = ConsoleColor.Red;
            MonsterAtk += atkBuff;
            Console.WriteLine($"The {MonsterName} has gained a ATK buff of {atkBuff}!");
            Console.ResetColor();
            Console.ReadKey();
        }

        public override Monsters CreateCloneInstance()
        {
            return new Skeleton(MonsterName, MonsterAtk, MonstersDefense, MonstersHp, GoldDropped);
        }

        public Skeleton(string name, int atk, int def, int hp, int goldDropped)
            : base(name, atk, def, hp, goldDropped)
        {
            MonsterName = name;
            MonsterAtk = atk;
            MonstersDefense = def;
            MonstersHp = hp;
            GoldDropped = goldDropped;
            MonsterType = "Skeleton";
            _originalAtk = atk;
        }
    }
}
