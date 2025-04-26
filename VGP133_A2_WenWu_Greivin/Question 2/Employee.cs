using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    internal class Employee
    {
        //properties and getter/setter
        private string _name;
        private int _age;
        private string _employeeEmail;

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
        public string EmployeeEmail
        {
            get { return _employeeEmail; }
            set
            {
                if (value.Contains("@lcv.com"))
                {
                    _employeeEmail = value;
                }
                else
                { 
                    _employeeEmail = "guest@lcv.com";
                }
            }
        }
        //methods
        public Employee(string name, int age, string email)
        {
            _name = name;
            _age = age;
            _employeeEmail = email;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Employee information:\n");
            Console.WriteLine(Name);
            Console.WriteLine(Age);
            Console.WriteLine(EmployeeEmail);
        }

        public void CheckValidEmail()
        {
            if (_employeeEmail.Contains("@lcv.com"))
            {
                Console.WriteLine("Email found: " + _employeeEmail);
            }
            else
            {
                Console.WriteLine("You do not have a valid email address");
            }
        }

    }
}
