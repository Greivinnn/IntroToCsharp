using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_notes
{
    public class Animal(string myName)
    {
        private string _name = myName;
        public virtual void MakeSound() // main class to override from has the virtual
        {
            Console.WriteLine("Default sound");
        }
    }
}
