using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class ActiveBook
    {
        private Person _PersonFullName;
        private Book _Cover;
        private Book _Title;
        private Author _AuthorName;
        private Book _TotalPages;
        private int _PageAt;
        private Book _Type;
        private ReadStatus _ReadingStatus;
        private Person _WishList;


        public Person PersonFullName
        {
            get { return _PersonFullName; }
        }

        public Book Cover 
        { 
            get { return _Cover; }
        }

        public Book Title
        {
            get { return _Title; }
        }
         public Author AuthorName
        {
            get { return _AuthorName; }
        }
        public Book TotalPages
        {
            get { return _TotalPages; }
        }
        public int PageAt
        {
            get { return _PageAt; }
            set { _PageAt = value; }
        }
        internal Book Type
        {
            get { return _Type; }
        }
        public ReadStatus ReadingStatus
        {
            get { return _ReadingStatus; }
            set { _ReadingStatus = value; }
        }
        public Person WishList
        {
            get { return _WishList; }
            set { _WishList = value; }
        }
    }
}
