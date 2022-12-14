using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Address
    {
        private int _StreetNumber;
        private string _StreetName;
        private string _AptSuite;
        private string _City;
        private string _StateProvince;
        private string _PostalCode;
        private string _Country;

        public int StreetNumber 
        { 
            get { return _StreetNumber; } 
            set { _StreetNumber = value; } 
        }
        public string StreetName 
        {
            get { return _StreetName; }
            set { _StreetName = value; }
        }
        public string AptSuite
        {
            get { return _AptSuite; }
            set { _AptSuite = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string StateProvince
        {
            get { return _StateProvince; }
            set { _StateProvince = value; }
        }
        public string PostalCode { 
            get { return _PostalCode; } 
            set { _PostalCode = value; }
        }
        public string Country 
        { 
            get { return _Country; } 
            set { _Country = value; }
        }
    }
}
