using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Midterm_WenWu_Greivin
{
    public class Paladin : Character
    {
        public override int CalculateSkillDamage()
        {
            return Attack + Defence;   // paladin attack + defence 
        }
    }
}
