using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGP133_A3_WenWu_Greivin;

namespace Question_1
{
    public class Electronics : Product
    {
        private string _brand;
        private string _model;
        private int _yearsOfWarranty;

        public Electronics(string productName, float price, float discount, string description, string brand, string model, int yearsOfWarranty)
             : base(productName, price, discount, description) // Call the base class constructor
        {
            _brand = brand;
            _model = model;
            _yearsOfWarranty = yearsOfWarranty;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // this is our display info from Product, thats our base class
            Console.WriteLine("Brand: " + _brand);
            Console.WriteLine("Model: " + _model);
            Console.WriteLine("Warranty Period (years): " + _yearsOfWarranty);
        }
        public bool IsWarrantyValid(float age)
        {
            return age <= _yearsOfWarranty; // return if is still valid 
        }

    }
}
