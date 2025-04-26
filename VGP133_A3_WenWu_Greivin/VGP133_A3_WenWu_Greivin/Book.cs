using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGP133_A3_WenWu_Greivin;

namespace Question_1
{
    public class Book : Product
    {
        private string _author;
        private string _genre;
        private int _publicationYear;

        public Book(string author, string genre, int publicationYear)
        {
            _author = author;
            _genre = genre;
            _publicationYear = publicationYear;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Book Author: " + _author);
            Console.WriteLine("Book Genre: " + _genre);
            Console.WriteLine("Book Publication Year: " + _publicationYear);
        }
        public void IsModern()
        {
            if (_publicationYear < 2015)
            {
                Console.WriteLine("Book was published before 2015");
            }
            else
            {
                Console.WriteLine("Book is modern. Published after 2014.");
            }
        }
    }
}
