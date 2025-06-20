using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Students
    {
        private string _name;
        private int _id;
        
        public Students(string name, int id)
        {
            _name = name;
            _id = id;
        }
        public string Name
        {
            get { return _name; } 
            set { _name = value; }
        }
        public int Id
        { 
            get { return _id; } 
            set { _id = value; }
        }

    }
}
