using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_notes
{
    public class Dog(string myName) : Animal(myName), ILife
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof WOof");
        }
        public void Reproduce()
        {
            Console.WriteLine("Yaay new puppy");
        }
        public void Die()
        {
            Console.WriteLine("RIP michi");
        }
    }
}
