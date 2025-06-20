using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    public class Employee
    {
        private string _name;
        private int _age;
        private float _salary;
        private string _email;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public float Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string Email
        {
            get { return _email; } 
            set { _email = value; }
        }
        public void PrintInfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Age);
            Console.WriteLine(Salary);
            Console.WriteLine(Email);
        }
    }
}
