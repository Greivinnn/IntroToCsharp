using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    public class Item
    {
        private string _itemName;
        private string _itemType;
        private int _quantity;

        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }
        public string ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public static void PrintItems(List<Item> listOfItems)
        {
            Console.WriteLine("Items inside inventory:");
            foreach (var item in listOfItems)
            {
                Console.WriteLine(item.ItemName + " (" + item.ItemType + ")" + " x" + item.Quantity);
            }
        }
    }
}
