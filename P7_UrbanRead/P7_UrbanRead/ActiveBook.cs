namespace P7_UrbanRead
{
    internal class ActiveBook
    {
        private Book _ActBook;
        private ReadStatus _ReadingStatus;
        private int _PageAt;
        public Book ActBook
        {
            get { return _ActBook; }
            set { _ActBook = value; }

        }
        public ReadStatus ReadingStatus
        {
            get { return _ReadingStatus; }
            set { _ReadingStatus = value; }
        }
        public int PageAt
        {
            get { return _PageAt; }
            set { _PageAt = value; }
        }
    }
}
