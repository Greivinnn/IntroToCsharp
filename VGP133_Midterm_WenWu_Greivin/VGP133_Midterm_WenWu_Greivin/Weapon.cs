using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Midterm_WenWu_Greivin
{
    public class Weapon : Equipment
    {
        public Weapon(int hpBonus, int atkBonus, int defBonus)
        {
            HpBonus = hpBonus;
            AtkBonus = atkBonus;
            DefenceBonus = defBonus;
        }
        public override string ToString()
        {
            return $"Weapon [HPBonus: {HpBonus}, ATKBonus: {AtkBonus}, DEFBonus: {DefenceBonus}]";
        }
    }
}
