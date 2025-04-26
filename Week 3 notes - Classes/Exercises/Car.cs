using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Car
    {
        string carName;
        int topSpeed;
        string revSound;

        public Car(string carName, int topSpeed, string revSound) // Constructor
        {
            this.carName = carName;
            this.topSpeed = topSpeed;
            this.revSound = revSound;
        }
        public Car() // Default constructor
        {
            carName = "DEFAULT";
            topSpeed = 0;
            revSound = "poof";
        }
        public void displayInfo()
        {
            Console.WriteLine($"Car Name: {carName}");
            Console.WriteLine($"Top Speed: {topSpeed}");
            Console.WriteLine($"Rev Sound: {revSound}");
        }
        public void revEngine()
        {
            Console.WriteLine($"The {carName} goes {revSound}");
        }
    }
}
