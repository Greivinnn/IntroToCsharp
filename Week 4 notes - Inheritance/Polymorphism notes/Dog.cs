using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_notes
{
    public class Dog(string myName) : Animal(myName)
    {
        public override void MakeSound()    // baby classes override from the main class, Animal
        {
            Console.WriteLine("I am a dog WOOF WOOF");
        }
    }
}
