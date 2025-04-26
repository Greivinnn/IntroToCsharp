using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_A3_WenWu_Greivin
{
    public class Product
    {
        private string _productName;
        private float _price;
        private float _discount;
        private string _description;

        public virtual void CalculateTax(float price)
        {
            float amountTaxed;
            amountTaxed = _price * 0.12f;
            Console.WriteLine("The total after tax is: " + amountTaxed);
        }
        public virtual float GetPrice()
        {
            return _price - _discount;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Product Name: " + _productName);
            Console.WriteLine("Product Price: " + _price);
            Console.WriteLine("Product Discount: " + _discount);
            Console.WriteLine("Product Price after Discount: " + GetPrice());
            Console.WriteLine("Product Description: " + _description);
        }
    }
}
