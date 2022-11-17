﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Bookstore
    {
        private string _StoreName;
        private string _Website;
        private Address _Country;
        private List<BookstoreBooks> _Books;

        public string StoreName
        {
            get { return _StoreName; }
            set { _StoreName = value; }
        }
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }
        public Address Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        public List<BookstoreBook> Books
        {
            get { return _Books; }
            set { _Books = value; }
        }
    }
}
