namespace P7_UrbanRead
{
    internal class BookClub
    {
        private string _PostSubject;
        private string _PostBody;
        private string _Attachment; //filelocation path

        public string PostSubject 
        { 
            get { return _PostSubject; } 
            set { _PostSubject = value; }
        }
        public string PostBody
        {
            get { return _PostBody; }
            set { _PostBody = value; }
        }
        public string Attachment
        {
            get { return _Attachment; }
            set { _Attachment = value; }
        }
    }
}
