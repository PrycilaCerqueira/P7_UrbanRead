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
        private List<string> _Language = new List<string> {"Portuguese", "English", "Spanish", "French", "Italian"};
        private List<string> _Genre = new List<string> {"Fiction", "Non-Fiction"};
        private List<string> _SubGenre = new List<string> { };

        public List<string> Language 
        {
            get { return _Language; }
        }

        private enum Type
        {

        }
        private enum EbookFormart
        {

        }

    }
}
