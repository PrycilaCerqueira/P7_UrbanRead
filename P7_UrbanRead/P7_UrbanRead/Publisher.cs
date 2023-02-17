using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static void GetGBPublishDates(string bookPublishedDate, Book locBook)
        {
                DateTime dt;
                string[] validDateFormats = new string[]
                {
                    "yyyy",
                    "yyyy-mm-dd"
                };
                if (DateTime.TryParseExact(bookPublishedDate, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    locBook.PublishedDate = dt;
                }

        }
    }
}
