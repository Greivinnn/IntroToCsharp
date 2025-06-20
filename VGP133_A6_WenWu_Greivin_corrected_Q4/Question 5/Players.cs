using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_5
{
    public class Players
    {
        private string _name;
        private int _age;

        public Players(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return _age; } set { _age = value; } }
    }
}
