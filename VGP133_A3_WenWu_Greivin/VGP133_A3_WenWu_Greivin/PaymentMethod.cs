using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public abstract class PaymentMethod(int id, float amount)
    {
        private int _id = id;
        private float _amount = amount;

        public abstract void ProcessPayment();
    }
}
