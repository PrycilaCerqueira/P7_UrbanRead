using System.Text;

namespace P7_UrbanRead
{
    public class Book
    {
        private string _CoverImgLink;
        private string _Title;
        private string _Subtitle;
        private string _Description;
        private int  _TotalPages;
        private List<ISBN> _ISBNS = new List<ISBN>();
        private List<Author> _Authors = new List<Author>();
        private string _PublisherName; 
        private DateTime _PublishedDate; 
        private LangType _Language; 
        private string _Genre; 
        private BookFormat _BookFormat; 
        private List<MatRatType> _MaturityRating = new List<MatRatType>();
        private List<string> _BookSampleLinks = new List<string>();  
        

        public string CoverImgLink
        {
            get { return _CoverImgLink; }
            set { _CoverImgLink = value; }
        }
        public string Title
        {
            get { return _Title; }  
            set { _Title = value; }
        }
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        } 
        public int TotalPages
        {
            get { return _TotalPages; }
            set { _TotalPages = value; }
        }
        public DateTime PublishedDate
        {
            get { return _PublishedDate; }
            set { _PublishedDate = value; }
        }
        public List<ISBN> ISBNS
        {
            get { return _ISBNS; }
            set { _ISBNS = value; }
        }
        public List<Author> Authors
        {
            get { return _Authors; }
            set { _Authors = value; }
        }
        public string PublisherName
        {
            get { return _PublisherName; }
            set { _PublisherName = value; }
        }
        public LangType Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public string Genre
        {
            get { return _Genre; }
            set { _Genre = value; }
        }

        public BookFormat Type
        {
            get { return _BookFormat; }
            set { _BookFormat = value; }
        }

        public List<MatRatType> MaturityRating
        {
            get { return _MaturityRating; }
            set { _MaturityRating = value; } 
        }
        public List<string> BookSampleLinks
        {
            get { return _BookSampleLinks; }   
            set { _BookSampleLinks = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cover: "); 
            sb.AppendLine(CoverImgLink);
            sb.Append("Title: ");
            sb.AppendLine(Title);

            if (Subtitle != null)
            {
                sb.Append("Subtitle: ");
                sb.AppendLine(Subtitle);
            }

            sb.Append("Description: ");
            sb.AppendLine(Description);
            sb.Append("Total of pages: ");
            sb.AppendLine(TotalPages.ToString());

            sb.Append("ISBNs: ");
            foreach( ISBN i in ISBNS)
            {
                sb.AppendLine(i.ToString());
            }

            sb.Append("Authors: ");
            foreach (Author a in Authors)
            {
                int aCount = Authors.Count;
                if (aCount <= 1)
                {
                    sb.Append(a.ToString());
                }
                else
                {
                    sb.Append(a.ToString() + ", ");
                }                   
            }
            sb.AppendLine(".");
            
            return sb.ToString();
           

        }
    }
}
