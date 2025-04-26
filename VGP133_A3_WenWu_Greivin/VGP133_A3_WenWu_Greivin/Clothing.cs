using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGP133_A3_WenWu_Greivin;

namespace Question_1
{
    public class Clothing : Product
    {
        private string _size;
        private string _color;
        private string _material;

        public Clothing(string size, string color, string material)
        {
            _size = size;
            _color = color;
            _material = material;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Clothes Size: " + _size);
            Console.WriteLine("Clothes Color: " + _color);
            Console.WriteLine("Clothes Material: " + _material);
        }
        public string IsAvailableInColor(string color)
        {
            if (string.Equals(color, _color, StringComparison.OrdinalIgnoreCase))   // compares the colors and "StringComparison.OrdinalIgnoreCase" makes it case-insensitive
            {
                return "true";
            }
            return "false";
        }
    }
}
