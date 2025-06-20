using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Midterm_WenWu_Greivin
{
    public class Mage : Character
    {
        public override int CalculateSkillDamage()
        {
            return Attack + 50; // mage attack + 50 magic boost
        }
    }
}
