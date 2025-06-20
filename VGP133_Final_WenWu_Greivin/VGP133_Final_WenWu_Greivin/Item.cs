using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Item
    {
        private string _itemName;
        private int _quantity;
        private string _type;
        private int _value;
        private int _healBonus;

        public virtual string ItemName { get { return _itemName; } set { _itemName = value; } } 
        public virtual int Quantity { get { return _quantity; } set { _quantity = value; } }
        public virtual string Type { get { return _type; } set { _type = value; } }
        public virtual int Value { get { return _value; }set { _value = value; } }
        public int HealBonus { get { return _healBonus; } set { _healBonus = value; } }
        public Item() { }
        public Item(string name, int quantity, string type, int value, int healBonus)
        {
            _itemName = name;
            _quantity = quantity;
            _type = type;
            _value = value;
            _healBonus = healBonus;
        }
    }
}
