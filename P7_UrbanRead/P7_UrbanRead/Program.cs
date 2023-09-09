namespace P7_UrbanRead // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Users' input their search parameters
            List<string> searchParameters= UI.BookSearchMenu();

            //Loads the Local Library if file exists 
            List<Book> library = XML.LoadLocalLibrary();
            if (library == null)
            {
                //Establishes the API connection with Google Books to retrieve the books data 
                GoogleBooksJson.Root GBCollection = Help.GoogleBookAPIConnector(searchParameters);
                library = Help.LoadGoogleBooksData(GBCollection);
            }

            var lowercaseSearchTerm = searchParameters[0].ToLower();
            var searchResult = library.Where(b => b.Title.ToLower().Contains(lowercaseSearchTerm)).ToList();

            foreach (Book result in searchResult)
            {
                Console.WriteLine();
                Console.WriteLine(result.ToString());
            }

            //Save the library file into the users' profile folder for a fast load
            XML.ExportFile(library);
            
            
            // Set books reading status 
            //FuncHelp.SetReadingStatus(locBook);




            Console.WriteLine();
           

        }
    }
}