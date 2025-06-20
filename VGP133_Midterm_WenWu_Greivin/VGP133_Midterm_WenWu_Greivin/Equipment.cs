using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Midterm_WenWu_Greivin
{
    public abstract class Equipment
    {
        private int _hpBonus;
        private int _atkBonus;
        private int _defenseBonus;

        public int HpBonus
        {
            get { return _hpBonus; }
            set { _hpBonus = value; }
        }
        public int AtkBonus
        {
            get { return _atkBonus; }
            set { _atkBonus = value; }
        }
        public int DefenceBonus 
        {
            get { return _defenseBonus; } 
            set { _defenseBonus = value; } 
        }
    }
}
