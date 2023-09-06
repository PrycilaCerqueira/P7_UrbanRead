using Microsoft.AspNetCore.SignalR;
using P7_UrbanRead;

namespace WebUI.Data
{
    public class MainDataService //TODO: rename / make one dataservice for everything 
    {

        private List<Book> _library;
        public void Init()
        {
            _library = XML.LoadLocalLibrary();
        }

        
        public void SearchBook()
        {

        }
    }
}
