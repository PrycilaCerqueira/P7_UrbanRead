using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Person
    {
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private int _MobilePhoneNumber;
        private int _AlternativePhoneNumber;
        private string _PrimaryEmail;
        private string _SecondaryEmail;
        private Address _Address;
        private List<Book> _WishList;
        private List<Book> _ActiveBook;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        public int MobilePhoneNumber
        {
            get { return _MobilePhoneNumber; }
            set { _MobilePhoneNumber = value; }
        }
        public int AlternativePhoneNumber
        {
            get { return _AlternativePhoneNumber; }
            set { _AlternativePhoneNumber = value; }
        }
        public string PrimaryEmail
        {
            get { return _PrimaryEmail; }
            set { _PrimaryEmail = value; }
        }
        public string SecondaryEmail
        {
            get { return _SecondaryEmail; }
            set { _SecondaryEmail = value; }
        }
        public Address Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public List<Book> WishList
        {
            get { return _WishList; }
            set { _WishList = value; }
        }
        public List<Book> ActiveBook
        {
            get { return _ActiveBook; }
            set { _ActiveBook = value; }
        }

    }
}
