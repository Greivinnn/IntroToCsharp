using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public class Cash(int id, float amount) : PaymentMethod(id, amount)
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Hi thank you for paying in cash");
            Console.WriteLine("Thank you, have a nice day!!");
        }
    }
}
