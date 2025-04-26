using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Circle : Shape
    {
        private float _radius;
        private float _pi = 3.14f;
        public Circle(float radius)
        {
            _radius = radius;
        }
        public override float CalculateArea()
        {
            return (_radius * _radius) * _pi;
        }
    }
}
