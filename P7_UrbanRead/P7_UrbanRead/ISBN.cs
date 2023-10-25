using System.Text;

namespace P7_UrbanRead
{
    public class ISBN
    {
        private long _Isbn10;
        private long _Isbn13;

        public long Isbn10
        {
            get { return _Isbn10; }
            set { _Isbn10 = value; }
        }
        public long Isbn13
        {
            get { return _Isbn13; }
            set { _Isbn13 = value; }
        }

        /*
        public override string ToString()
        {
           return $"{Isbn13}, {Isbn10}";
        }
        */


    }
}
