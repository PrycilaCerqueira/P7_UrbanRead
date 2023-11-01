using System.Text;

namespace P7_UrbanRead
{
    public class ISBN
    {
        private long _Isbn;

        public long Isbn
        {
            get { return _Isbn; }
            set { _Isbn = value; }
        }
        
        
        public override string ToString()
        {
            return $"{Isbn}";
        }
        


    }
}
