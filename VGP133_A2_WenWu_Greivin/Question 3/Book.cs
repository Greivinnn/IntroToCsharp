using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_3
{
    internal class Book
    {
        //properties and getters/setters
        private string _name;
        private string _title;
        private string _author;
        private string _isbn;
        private bool _available;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        public bool IsAvailable
        {
            get { return _available; }
            set { _available = value; }
        }
        //methods
        public Book(string name, string title, string author, string isbn, bool available)
        {
            _name = name;
            _title = title;
            _author = author;
            _isbn = isbn;
            _available = false;
        }
        public void CheckOut()
        {
            if (_available)
            {
                _available = false;
                Console.WriteLine("Succesfully checked out book, ISBN: " + _isbn);
            }
            else
            {
                Console.WriteLine("Sorry, book not available at the moment");
            }
        }
        public void Return()
        {
            if (!_available)
            {
                _available = true;
                Console.WriteLine("Book was return to its original place");
            }
            else
            {
                Console.WriteLine("Book was already returned, and in the library");
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Client's Name: " + _name);
            Console.WriteLine("Book's Title: " + _title);
            Console.WriteLine("Book's Author: " + _author);
            Console.WriteLine("Book's ISBN: " + _isbn);
            if (_available)
            {
                Console.WriteLine("Book is available for pick up");
            }
            else
            {
                Console.WriteLine("Book is not available, out of stock");
            }
        }
    }
}
