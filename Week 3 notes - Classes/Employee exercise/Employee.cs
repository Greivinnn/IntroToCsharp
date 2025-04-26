using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_exercise
{
    public class Employee
    {
        private string name;
        public string Name { get; set; }
        private int employeeID;
        public int employeeId { get; set; }
        private int salary;
        public int Salary {  get; set; }
 
        public Employee() { }
        public void giveRaise()
        {
            salary += 20;
            Console.WriteLine("You received a raise! Congrats.");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Employee ID: {employeeID}");
            Console.WriteLine($"New Salary: {salary}");
        }
    }
}
