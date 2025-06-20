using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    public class MyQueue<T>
    {
        private List<T> _myQueue;

        public MyQueue()
        {
            _myQueue = new List<T>();
        }
                            
        public void Enqueue(T value)
        {
            _myQueue.Add(value);
            Console.WriteLine("Adding new item to queue: " + value);
        }
        public void Dequeue()
        {
            T removedItem = _myQueue[0];
            _myQueue.RemoveAt(0);
            Console.WriteLine("Removing first item from the queue: " + removedItem);
        }
        public void PrintList()
        {
            Console.WriteLine("Items in queue:");
            foreach (var item in _myQueue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
