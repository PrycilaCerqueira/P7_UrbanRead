using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            foreach (var isbnX in x.ISBNS)
            {
                foreach (var isbnY in y.ISBNS)
                {
                    if (isbnX == isbnY)
                        return true;
                }
            }
            if (Object.ReferenceEquals(x.ISBNS, null) || Object.ReferenceEquals(y.ISBNS, null))
                return false;



            /*
            if (Object.ReferenceEquals(x.ISBNS,y.ISBNS)) 
                return true;
            */

        }

        public int GetHashCode([DisallowNull] Book x)
        {
            return x.ISBNS.Sum();
        }
    }
}
