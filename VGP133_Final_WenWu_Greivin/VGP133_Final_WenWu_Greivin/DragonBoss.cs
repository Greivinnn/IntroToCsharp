using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class DragonBoss : Monsters
    {
        private bool _beenDefeted = false;
        private int _defenseReduced = 0;

        public int DefenseReduce
        {
            get { return _defenseReduced; }
            set { _defenseReduced = value; }
        }
        public bool IsDefeted
        {
            get { return _beenDefeted; }
            set { _beenDefeted = value; }
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
        public override void SpecialAttack(ref Character player)    // steal 25% of player HP
        {
            Random random = new Random();
            int attackChoice = random.Next(1, 4); // Randomly choose one of three special attacks

            if (attackChoice == 1)
            {
                // Special Attack 1: Steal 25% of the player's HP
                int stolenHp = player.CurrentHp / 4;
                player.CurrentHp -= stolenHp;
                MonstersHp += stolenHp;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{MonsterName} used Life Drain! It stole {stolenHp} HP from {player.Name} to heal itself!");
                Console.ResetColor();
            }
            else if (attackChoice == 2)
            {
                // Special Attack 2: Reduce the player's defense temporarily
                int defenseReduction = 10; // Example value
                _defenseReduced += defenseReduction; // Track the total defense reduced
                player.Def = Math.Max(player.Def - defenseReduction, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{MonsterName} used Armor Break! {player.Name}'s defense was reduced by {defenseReduction}!");
                Console.ResetColor();
            }
            else if (attackChoice == 3)
            {
                // Special Attack 3: Deal a powerful attack ignoring defense
                player.CurrentHp = Math.Max(player.CurrentHp - MonsterAtk, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{MonsterName} used Savage Strike! It dealt {MonsterAtk} damage to {player.Name}!");
                Console.ResetColor();
            }
        }
        public void OnDefeat(ref Character player)
        {
            // Restore the player's defense
            if (_defenseReduced > 0)
            {
                player.Def += _defenseReduced;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{player.Name}'s defense has been restored by {_defenseReduced} after defeating {MonsterName}!\n");
                Console.ResetColor();
                _defenseReduced = 0; // Reset the reduced defense tracker
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{MonsterName} has been defeated!");
            Console.WriteLine($"Not bad {player.Name}, you could show me one or two moves...");
            Console.ResetColor();
        }

        public override Monsters CreateCloneInstance()
        {
            return new DragonBoss(MonsterName, MonsterAtk, MonstersDefense, MonstersHp, GoldDropped);
        }
        public DragonBoss CreateBossCopy()
        {
            return new DragonBoss(MonsterName, MonsterAtk, MonstersDefense, MonstersHp, GoldDropped);
        }

        public DragonBoss(string name, int atk, int def, int hp, int goldDropped)
            : base(name, atk, def, hp, goldDropped)
        {
            MonsterName = name;
            MonsterAtk = atk;
            MonstersDefense = def;
            MonstersHp = hp;
            GoldDropped = goldDropped;
            MonsterType = "Dragon";
        }
    }
}
