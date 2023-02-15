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
        private DateTime _PublishedDate;

        public string PublisherName
        {
            get { return _PublisherName; }
            set { _PublisherName = value; }
        }

        public DateTime PublishedDate
        {
            get { return _PublishedDate; }
            set { _PublishedDate = value; }
        }
    }
}
