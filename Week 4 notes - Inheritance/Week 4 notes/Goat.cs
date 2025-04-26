using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_notes
{
    public class Goat(string myName) : Animal(myName), ILife
    {
        public override void MakeSound()
        {
            Console.WriteLine("BAAAHHH IM THE GOAT");
        }
    }
}
