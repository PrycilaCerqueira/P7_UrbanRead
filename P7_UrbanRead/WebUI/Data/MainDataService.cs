using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {      
        public List<string> SearchBook()
        {
            List<Book> searchResults = Help.initiateBookSearch();

            List <string> searchResultsToString = new List<string>();
            foreach (Book result in searchResults)
            {
                searchResultsToString.Add(result.ToString());
            }
            return searchResultsToString;

        }
    }
}
