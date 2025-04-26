using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Mage(string myName, string battleCry, int age) : Character(myName, battleCry, age)
    {
        public void DisplayCry()
        {
            Console.WriteLine(battleCry);
        }
    }
}
