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

        public Electronics(string brand, string model, int yearsOfWarranty)
        {
            _brand = brand;
            _model = model;
            _yearsOfWarranty = yearsOfWarranty;
        }
        public override void DisplayInfo()
        {
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
