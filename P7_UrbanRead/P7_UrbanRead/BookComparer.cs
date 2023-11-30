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
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] Book obj)
        {
            throw new NotImplementedException();
        }
    }
}
