using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    public class BookComparer : IEqualityComparer<Book>
    {

        

        public bool Equals(Book bookLeft, Book bookRight)
        {
            if (Object.ReferenceEquals(bookLeft.ISBNS, null) || Object.ReferenceEquals(bookRight.ISBNS, null))
                return false;

            foreach (var isbnRigth in bookRight.ISBNS)
            {
                foreach (var isbnLeft in bookLeft.ISBNS)
                {
                    if (Object.Equals(isbnRigth, isbnLeft))
                        return true;
                }   
            }
            return false;
           

        }

        public int GetHashCode([DisallowNull] Book book)
        {
            if (Object.ReferenceEquals(book.ISBNS, null)) return 0;

            long sum = book.ISBNS.Sum();
            int hash = sum.GetHashCode();
            return hash;
            
        }

    }   
}
