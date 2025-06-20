using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    public class Card
    {
        private string _suit;
        private int _value;

        public Card(string suit, int value)
        {
            _suit = suit;
            _value = value;
        }
    }
}
