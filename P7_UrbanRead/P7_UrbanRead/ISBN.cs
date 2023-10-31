using System.Text;

namespace P7_UrbanRead
{
    public class ISBN
    {
        private long _Isbn;
        //private long _Isbn13;

        public long Isbn
        {
            get { return _Isbn; }
            set { _Isbn = value; }
        }
        /*public long Isbn13
        {
            get { return _Isbn13; }
            set { _Isbn13 = value; }
        }
        */

     
        public override string ToString()
        {
            return $"{Isbn}";
        }
        


    }
}
