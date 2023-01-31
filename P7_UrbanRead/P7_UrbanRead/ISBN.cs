using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace P7_UrbanRead
{
    internal class ISBN
    {
        private string _Isbn10;
        private long _Isbn13;

        public string Isbn10
        {
            get { return _Isbn10; }
            set { _Isbn10 = value; }
        }
        public long Isbn13
        {
            get { return _Isbn13; }
            set { _Isbn13 = value; }
        }

        public static bool addIsbnIfValid(List<GoogleBooksJson.IndustryIdentifier> isbnIdentifiers, Book locBook )
        {
            var isbnId = new ISBN();
            if (isbnIdentifiers != null)
            {
                foreach (var item in isbnIdentifiers)
                {
                    if (item.Type == "ISBN_10" && item.Type.Length == 10)
                    {
                        isbnId.Isbn10 = item.Identifier;
                        locBook.ISBNS.Add(isbnId);
                    }
                    else if (item.Type == "ISBN_13" && item.Type.Length == 13)
                    {
                        isbnId.Isbn13 = Int64.Parse(item.Identifier);
                        locBook.ISBNS.Add(isbnId);
                    }
                    else
                    {
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
