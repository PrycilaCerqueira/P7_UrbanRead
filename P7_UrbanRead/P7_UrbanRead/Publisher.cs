using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Publisher
    {
        private string _PublisherName;
        private Address _Country;

        public string PublisherName
        {
            get { return _PublisherName; }
            set { _PublisherName = value; }
        }

        public Address Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
    }
}
