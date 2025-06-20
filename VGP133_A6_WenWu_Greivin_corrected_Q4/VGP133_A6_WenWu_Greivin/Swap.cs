using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public class Swap<T>
    {
        private T _firstValue;
        private T _secondValue;

        public void SwapAndPrint(ref T firstValue, ref T secondValue)
        {
            _firstValue = firstValue;
            _secondValue = secondValue;
            Console.WriteLine("Original two values: " + firstValue + ", " + secondValue);

            T temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;

            Console.WriteLine("Swapping values position...");
            Console.WriteLine("Swapped values: " + firstValue + ", " + secondValue);
        }
    }
}
