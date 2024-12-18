﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace P7_UrbanRead
{
    public class Person
    {
        private int _Id;
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private string _MobilePhoneNumber;
        private string _AlternativePhoneNumber;
        private string _PrimaryEmail;
        private string _SecondaryEmail;
        private Address _Address = new Address();
        private List<Book> _WishList = new List<Book>();
        private List<ActiveBook> _Bookshelf = new List<ActiveBook>();


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
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
        
        [Required(ErrorMessage = "Mobile no. is required")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, ErrorMessage = "Phone number must be up to 15 characters long.")]
        public string MobilePhoneNumber
        {
            get { return _MobilePhoneNumber; }
            set { _MobilePhoneNumber = value; }
        }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, ErrorMessage = "Phone number must be up to 15 characters long.")]
        public string AlternativePhoneNumber
        {
            get { return _AlternativePhoneNumber; }
            set { _AlternativePhoneNumber = value; }
        }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string PrimaryEmail
        {
            get { return _PrimaryEmail; }
            set { _PrimaryEmail = value; }
        }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
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
        public List<ActiveBook> Bookshelf
        {
            get { return _Bookshelf; }
            set { _Bookshelf = value; }
        }

    }
}
