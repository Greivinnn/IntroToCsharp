using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7___Generics_Notes
{
    public class Box<T>
    {
        private T item;  //define T item as private

        public void Pack(T item)    //function that inputs a T item to store it as either (int, float, string...)
        {
            this.item = item;
            Console.WriteLine("Packed: " + item);
        }

        public T Unpack()   //method that returns our Packed items
        {
            Console.WriteLine("Unpacked: " + this.item);
            return this.item;
        }
    }
}
