using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Weapon : Item
    {
        public Weapon() : base() { }
        private int _attackBonus;
        public int AttackBonus { get { return _attackBonus; } set { _attackBonus = value; } }
        public Weapon(string name, int quantity, int value, int attackBonus)
            :base(name, quantity, "Weapon", value, attackBonus)
        {
            _attackBonus = attackBonus;
        }
        //overriden functions from Item
        public override string ItemName
        {
            get { return base.ItemName; }
            set { base.ItemName = value; }
        }
        public override int Quantity
        {
            get { return base.Quantity; }
            set { base.Quantity = value; }
        }
        public override string Type
        {
            get { return "Weapon"; }
            set { base.Type = value; }
        }
        public override int Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }
    }
}
