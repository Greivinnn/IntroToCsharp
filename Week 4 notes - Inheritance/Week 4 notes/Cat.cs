using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_notes
{
    public class Cat(string myName) : Animal(myName)
    {
        public override void MakeSound()
        {
            Console.WriteLine("Scratchy Scratchy");
        }
    }
}
