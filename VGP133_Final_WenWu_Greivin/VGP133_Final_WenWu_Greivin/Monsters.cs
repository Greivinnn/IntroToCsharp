using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public abstract class Monsters
    {
        private string _monstersName;
        private int _monsterAtk;
        private int _monsterDef;
        private int _monsterHp;
        private int _goldDropped;
        private string _monsterType;

        public abstract string MonsterName { get; set; }
        public abstract int MonsterAtk { get; set; }
        public abstract int MonstersDefense { get; set; }
        public abstract int MonstersHp { get; set; }
        public abstract int GoldDropped { get; set; }
        public abstract string MonsterType { get; set; }    

        public abstract void BasicAttack(ref Character player);
        public abstract void SpecialAttack(ref Character player);

        public abstract Monsters CreateCloneInstance();

        protected Monsters(string name, int atk, int def, int hp, int goldDropped)
        {
            _monstersName = name;
            _monsterAtk = atk;
            _monsterDef = def;
            _monsterHp = hp;
            _goldDropped = goldDropped;
            _monsterType = "";
        }
    }
}
