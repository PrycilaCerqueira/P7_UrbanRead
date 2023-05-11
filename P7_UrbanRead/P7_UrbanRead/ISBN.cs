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
        private long _Isbn10;
        private long _Isbn13;

        public long Isbn10
        {
            get { return _Isbn10; }
            set { if (value < 11 ) _Isbn10 = value; }
        }
        public long Isbn13
        {
            get { return _Isbn13; }
            set { _Isbn13 = value; }
        }
                
    }
}
