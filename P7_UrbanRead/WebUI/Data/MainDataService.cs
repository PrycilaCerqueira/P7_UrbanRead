using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {      
        public static List<Book> SearchBook(string searchTerm,List<string> parameters = null)
        {
            if(parameters != null)
            {
                //handle parameters
            }
            List<Book> searchResults = Help.initiateBookSearch(parameters, searchTerm);
            return searchResults;
        }
    }
}
