using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public class PayPal(int id, float amount) : PaymentMethod(id, amount)
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Nice, paying with Paypal?");
            Console.WriteLine("2% fee will be added to the payment amount");
            Console.WriteLine("Accepted. Thank you have a great day!");
        }
    }
}
