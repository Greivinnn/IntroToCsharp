using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_notes
{
    public class BankAccount
    {
        private string customerName;
        private float balance;
        public BankAccount(string customerName, float bal) // Constructor 
        {
            this.customerName = customerName;   // if the same name is in use use a this to point to the class variable
            balance = bal; // however, if the name is different you do not need to use this.
        } 
        //Methods
        public void DepositMoney(float amount)
        {
            balance += amount;
        }
        public void PrintBalance()
        {
            Console.WriteLine($"Balance: {balance}"); 
        }
        public void PrintCustomerName()
        {
            Console.WriteLine($"Customer Name: {customerName}");
        }
    }
}
