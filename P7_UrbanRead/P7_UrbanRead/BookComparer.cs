using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book bookRight, Book bookLeft)
        {
            if (Object.ReferenceEquals(bookRight.ISBNS, null) || Object.ReferenceEquals(bookLeft.ISBNS, null))
                return false;

            foreach (var isbnRigth in bookRight.ISBNS)
            {
                foreach (var isbnLeft in bookLeft.ISBNS)
                {
                    if (isbnRigth == isbnLeft)
                        return true;
                }
            }
            return false; 
            
            /*
            if (Object.ReferenceEquals(x.ISBNS,y.ISBNS)) 
                return true;
            */

        }

        public int GetHashCode([DisallowNull] Book book)
        {
            if (Object.ReferenceEquals(book.ISBNS, null)) return 0;

            int hashID = book.ISBNS.GetHashCode();
            return hashID;
        }
    }
}
