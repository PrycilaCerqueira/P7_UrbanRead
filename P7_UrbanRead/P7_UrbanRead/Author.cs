namespace P7_UrbanRead
{
    public class Author
    {
        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public override string ToString()
        {
            return $"{FullName}";
        }



    }
}
    

