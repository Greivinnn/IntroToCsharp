using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBack_Exercise
{
    public class CreditCard
    {
        private string cardHolderName;
        public string CardHolderName { get; set; } // get and set properties
        private float cashbackPercent;
        public float CashbackPercent
        {
            get { return cashbackPercent; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    cashbackPercent = value;
                }
                else
                {
                    Console.WriteLine("Invalid cashback percentage. It should be between 0 and 100.");
                }
            }
        }
        public CreditCard(string cardHolderName, float cashbackPercent)
        {
            this.cardHolderName = cardHolderName;
            this.cashbackPercent = cashbackPercent;
        }
        public void CalculateCashback(float amountSpent)
        {
            float cashback = (amountSpent * cashbackPercent) / 100;
            Console.WriteLine($"Cashback for {cardHolderName}: {cashback}");
        }
    }
}
