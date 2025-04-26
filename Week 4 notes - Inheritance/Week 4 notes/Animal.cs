using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_notes
{
    public abstract class Animal(string myName)
    {
        public string _name = myName;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Default");
        }
    }
}
