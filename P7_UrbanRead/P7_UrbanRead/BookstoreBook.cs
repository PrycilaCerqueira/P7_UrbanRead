using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class BookstoreBook
    {
        private Book _Book;
        private double _Price;
        private bool _InStock;

        public Book Book
        {
            get { return _Book; }
            set { _Book = value; }
        }
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public bool InStock
        {
            get { return _InStock; }
            set { _InStock = value; }
        }
    }
}
