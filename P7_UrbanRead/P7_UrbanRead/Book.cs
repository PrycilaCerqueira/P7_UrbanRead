using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Book
    {
        private string _Cover; //Source of the cover image
        private string _Title;
        private string _Description;
        private int _TotalPages;
        private DateTime _Edition;
        private int _ISBN;
        private Author _Author;
        private Publisher _Publisher;
        private LangType _Language; 
        private GenreType _Genre; 
        private List <SubGenereType> _SubGenres;
        private BookType _Type;
        private EbookFormat _EbookFormat;
     


        public LangType Language 
        {
            get { return _Language; }
        }


    }
}
