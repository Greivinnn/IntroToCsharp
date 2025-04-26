using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public class Rectangle
    {
        //properties and getter/setter
        private float rectangleLenght;
        private float rectangleWidth;  
        public float RectangleLenght
        {
            get { return rectangleLenght; }
            set { rectangleLenght = value; }
        }
        public float RectangleWidth
        {  
            get { return rectangleWidth; } 
            set { rectangleWidth = value; } 
        }
        //methods
        public Rectangle(float rectangleLenght, float rectangleWidth)
        {
            this.rectangleLenght = rectangleLenght;
            this.rectangleWidth = rectangleWidth;
        }

        public float GetPerimeter()
        {
            return 2 * (rectangleLenght + rectangleWidth);
        }
        public float GetArea()
        {
            return (rectangleLenght * rectangleWidth);
        }
        public void ChangeSize(float width, float height)
        {
            if (width < 0 || height < 0)
            {
                Console.WriteLine("Error, your values cannot be negative numbers.");
            }
            else
            {
                RectangleLenght = height;
                RectangleWidth = width;
            }
        }
    }
}
