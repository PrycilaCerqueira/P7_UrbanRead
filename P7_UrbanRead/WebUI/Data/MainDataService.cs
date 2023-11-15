using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {
        
        private static List<Book> _library = new List<Book>(); 
        

        /// <summary>
        /// Initialize the internal Library during the program startup
        /// </summary>
        protected static void Init()
        {
            _library = XML.LoadLocalLibrary();
        }


        /// <summary>
        /// Search for books based on the user's parameters input (Local Library and GoogleBooks) 
        /// </summary>
        /// <returns>List of book records</returns>
        public static List<Book> SearchBook(string sTopic, string sCategory, string sFilter)
        {

            //If Local Library file doesn't have data, establishes API connection with Google Books to retrieve books 
            if (_library == null)
            {
                GoogleBooksJson.Root GBCollection = Help.GoogleBookAPIConnector(sTopic, sCategory, sFilter);
                _library = Help.LoadGoogleBooksData(GBCollection);

                XML.ExportFile(_library); //Save the incremented library file into the users' profile folder for a fast load
            }

            //Search for the book title in the Local Library
            var lowerCaseSearchTerm = sTopic.ToLower();
            var searchResults = new List<Book>();

            if (sCategory == "intitle" || sCategory =="")
            {
                searchResults = _library.Where(t => t.Title.ToLower().Contains(lowerCaseSearchTerm)).ToList();
            }
            if (sCategory == "inauthor")
            {
                searchResults = _library.Where(a => a.Authors.ToString().Contains(lowerCaseSearchTerm, StringComparison.InvariantCultureIgnoreCase)).ToList();
    
            }

       




            //If Local Library does not contain the book title, establishes API connection and add the new range of books into the Local Library
            if (searchResults.Count < 1)
            {
                GoogleBooksJson.Root GBCollection = Help.GoogleBookAPIConnector(sTopic, sCategory, sFilter);

                List<Book> addToLib = new List<Book>();
                addToLib = Help.LoadGoogleBooksData(GBCollection);

                _library.AddRange(addToLib);
                XML.ExportFile(_library); //Save the incremented library file into the users' profile folder for a fast load

                if (sCategory == "intitle" || sCategory == "")
                {
                    searchResults = _library.Where(t => t.Title.ToLower().Contains(lowerCaseSearchTerm)).ToList();
                }
                if (sCategory == "inauthor")
                {
                    searchResults = _library.Where(a => a.Authors.ToString().Contains(lowerCaseSearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

                    //searchResults = _library.ForEach(a => a.Authors.Where(n => n.FullName.Contains(lowerCaseSearchTerm,StringComparison.OrdinalIgnoreCase))).ToList();
                    
                }
            }

            return searchResults;
        }
    }
}

