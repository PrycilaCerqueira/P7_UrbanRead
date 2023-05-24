using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Book
    {
        //Sample book https://www.googleapis.com/books/v1/volumes/EYzOAwAAQBAJ
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
        private BookFormat _BookFormat; //Field used when the user uploads the purchased book. The field should accept any format and convert to others - PDF, MOBI, etc
        private string _MaturityRating; //TODO: Revise datatype / Is it inappropriate for kids?  
        private string _BookPreviewLink;  //TODO: Revise datatype / Get the HTTPS of the book preview (Ex.: https://play.google.com/books/reader?id=EYzOAwAAQBAJ&pg=GBS.PP1&hl=en)
        private ReadStatus _ReadingStatus; //TODO: Defaul = undread. Allow the user to edit it
        private int _PageAt; //TODO: Default = 1. Get the page number where the user last read the book

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

        public string MaturityRating
        {
            get { return _MaturityRating; }
            set { _MaturityRating = value; } 
        }
        public string BookPreviewLink
        {
            get { return _BookPreviewLink; }   
            set { _BookPreviewLink = value; }
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
