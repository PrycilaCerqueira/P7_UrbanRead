namespace P7_UrbanRead
{
    public class Author
    {
        int _Id;
        private string _FullName;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

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
    

