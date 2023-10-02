using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {
        private List<Book> _library = new List<Book>(); 
        protected void Init()
        {
            _library = XML.LoadLocalLibrary();
        }
        public static List<Book> SearchBook(string searchTerm,List<string> parameters = null)
        {
            if(parameters != null)
            {
                //handle parameters
            }
            List<Book> searchResults = Help.initiateBookSearch(parameters);
            return searchResults;
        }
    }
}
