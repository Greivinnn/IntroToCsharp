using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public class CreditCard(int id, float amount) : PaymentMethod(id, amount)
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Paying with credit card...");
            Console.WriteLine("2% fee will be added to the payment amount.");
            Console.WriteLine("Card accepted. Thank you for visiting us!");
        }
    }
}
