using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Midterm_WenWu_Greivin
{
    public class Ninja : Character
    {
        public override int CalculateSkillDamage()
        {
            return Attack * 2;  //ninja does the double amount of damage
        }
    }
}
