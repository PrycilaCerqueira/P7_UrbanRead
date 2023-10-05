using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {
        
        private List<Book> _library = new List<Book>(); 
        public void Init()
        {
            _library = XML.LoadLocalLibrary();
        }
        
        public List<Book> SearchBook(string sTopic, string sCategory, string sFilter)
        {

            //If Local Library file doesn't have data, establishe API connection with Google Books to retrieve books 
            if (_library == null)
            {
                GoogleBooksJson.Root GBCollection = Help.GoogleBookAPIConnector(sTopic, sCategory, sFilter);
                _library = Help.LoadGoogleBooksData(GBCollection);

                XML.ExportFile(_library); //Save the incremented library file into the users' profile folder for a fast load
            }

            //Search for the book title in the Local Library
            var lowerCaseSearchTerm = sTopic.ToLower();
            var searchResults = _library.Where(b => b.Title.ToLower().Contains(lowerCaseSearchTerm)).ToList();

            //If Local Library does not contain the book title, establishe API connection and add the new range of books into the Local Library
            if (searchResults.Count < 1)
            {
                GoogleBooksJson.Root GBCollection = Help.GoogleBookAPIConnector(sTopic, sCategory, sFilter);

                List<Book> addToLib = new List<Book>();
                addToLib = Help.LoadGoogleBooksData(GBCollection);

                _library.AddRange(addToLib);
                XML.ExportFile(_library); //Save the incremented library file into the users' profile folder for a fast load

                searchResults = _library.Where(b => b.Title.ToLower().Contains(lowerCaseSearchTerm)).ToList();
            }

            return searchResults;
        }
    }
    }
}
