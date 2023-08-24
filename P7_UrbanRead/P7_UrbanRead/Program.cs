using Newtonsoft.Json;
using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using static GoogleBooksJson;
using static System.Reflection.Metadata.BlobBuilder;

namespace P7_UrbanRead // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //User's input their search parameters
            List<string> searchParameters= UI.BookSearchMenu();

            //Establishes the API connection with Google Books to retrieve the books data 
            GoogleBooksJson.Root GBCollection = FuncHelp.GoogleBookAPIConnector(searchParameters); 

            List<Book> library = FuncHelp.FetchGoogleBooks(GBCollection);


            XML.ExportFile(library);


            // Set books reading status 
            //FuncHelp.SetReadingStatus(locBook);




            Console.WriteLine();
           

        }
    }
}