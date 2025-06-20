using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7___Generics_Notes
{
    public class Stacks<T>
    {
        private List<T> elements = new List<T>();

        public void Push(T item)
        {
            elements.Add(item);
        }

        public List<T> GetValues()
        {
            return elements;
        }

        public void PrintNumber(T num)
        {
            if (num.GetType() == typeof(int) || num.GetType() == typeof(float))
            {
                Console.WriteLine(num);
            }
        }
    }

}
