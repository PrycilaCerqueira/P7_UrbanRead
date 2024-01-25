using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace P7_UrbanRead
{
    public class Book
    {
        private string _id;
        private string _CoverImgLink;
        private string _Title;
        private string _Subtitle;
        private string _Description;
        private int  _TotalPages;
        private List<long> _ISBNS = new List<long>();
        private List<Author> _Authors = new List<Author>();
        private string _PublisherName; 
        private DateTime _PublishedDate; 
        private LangType _Language; 
        private string _Genre; 
        private BookFormat _BookFormat; 
        private List<MatRatType> _MaturityRating = new List<MatRatType>();
        private List<string> _BookSampleLinks = new List<string>();


        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
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
        public List<long> ISBNS
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
            return Title + " " + Subtitle + "Samples:" + BookSampleLinks.Count;
        }
    }
}
