using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService
    {      
        public List<string> SearchBook()
        {
            List<Book> searchResult = Help.initiateBookSearch();

            List <string> searchResultToString = new List<string>();
            foreach (Book result in searchResult)
            {
                searchResultToString.Add(result.ToString());
            }
            return searchResultToString;

        }
    }
}
