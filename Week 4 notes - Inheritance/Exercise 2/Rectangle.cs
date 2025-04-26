using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Rectangle : Shape
    {
        private float _width;
        private float _lenght;
        public Rectangle(float width, float lenght)
        {
            _width = width;
            _lenght = lenght;
        }
        public override float CalculateArea()
        {
            return _width * _lenght;
        }
    }
}
