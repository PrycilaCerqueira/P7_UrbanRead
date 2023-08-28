namespace P7_UrbanRead // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

           
            
            //Users' input their search parameters
            List<string> searchParameters= UI.BookSearchMenu();

            //Establishes the API connection with Google Books to retrieve the books data 
            GoogleBooksJson.Root GBCollection = Help.GoogleBookAPIConnector(searchParameters);
            List<Book> library = Help.LoadGoogleBooksData(GBCollection);
            
            //Save the library file into the users' profile folder for a fast load
            XML.ExportFile(library);
            XML.ImportFile();
            library = XML.LoadLocalLibrary();

            if (library == null)
            {

            }

            // Set books reading status 
            //FuncHelp.SetReadingStatus(locBook);




            Console.WriteLine();
           

        }
    }
}