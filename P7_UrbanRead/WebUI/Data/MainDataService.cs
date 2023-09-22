using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {      
        public static List<Book> SearchBook()
        {
            List<Book> searchResults = Help.initiateBookSearch();
            return searchResults;
        }
    }
}
