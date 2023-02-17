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


        /// <summary>
        /// Sets the PublisherDate data with the correct date format and datatype 
        /// </summary>
        /// <param name="bookPublishedDate"></param>
        /// <param name="locBook"></param>
        public static void GetGBPublishDates(string bookPublishedDate, Book locBook)
        {
                DateTime dt;
                
                //Converts the specified string representation of a date and time to its DateTime equivalent
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
