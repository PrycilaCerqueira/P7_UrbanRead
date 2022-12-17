using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Author
    {
        private string _FirstName;
        private string _LastName;
        private string _FullName;

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
        public string FullName
        { 
            get { return _FullName; }
            set { _FullName = $"{FirstName} {LastName}"; }
        }
    }
    
}
