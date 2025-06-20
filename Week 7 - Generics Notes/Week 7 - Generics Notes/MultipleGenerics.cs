using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7___Generics_Notes
{
    public class MultipleGenerics<T1, T2>   // Generics can have multiple, theres is no limit but we want to keep it short if we can
    {
        private T1 First;   // values
        private T2 Second;

        public MultipleGenerics(T1 first, T2 second)    //constructor
        {
            First = first;
            Second = second;
        }

        public void Show()  // method to show the values
        {
            Console.WriteLine($"First Value: {First}, Second Value: {Second}");
        }
    }
}
