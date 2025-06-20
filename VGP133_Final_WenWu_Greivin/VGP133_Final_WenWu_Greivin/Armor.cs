using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VGP133_Final_WenWu_Greivin
{
    public class Armor : Item
    {
        public Armor() : base() { }
        private int _defenseBonus;
        public int DefenseBonus { get { return _defenseBonus; } set { _defenseBonus = value; } } 
        public Armor(string name, int quantity, int value, int defenceBonus)
            :base (name, quantity, "Armor", value, defenceBonus)
        {
            _defenseBonus = defenceBonus;
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
            get { return "Armor"; }
            set { base.Type = value; }
        }
        public override int Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }
    }
}
