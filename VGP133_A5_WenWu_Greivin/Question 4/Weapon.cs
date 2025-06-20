using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    public class Weapon
    {
        private string _name;
        private int _atkPower;
        private int _strenghtRequirement;
        private string _ownerName;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int AtkPower
        {
            get { return _atkPower; }
            set { _atkPower = value; }
        }
        public int StrenghtRequirement
        {
            get { return _strenghtRequirement; }
            set { _strenghtRequirement = value; }
        }
        public string OwnerName
        {
            get { return _ownerName; }
            set { _ownerName = value; }
        }
        public void PrintInfo()
        {
            Console.WriteLine("Weapon Name: " + Name);
            Console.WriteLine("Attack Power: " + AtkPower);
            Console.WriteLine("Strenght Required: " + StrenghtRequirement);
            Console.WriteLine("Owner Name: " + OwnerName);
        }
    }
}
