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
            var localData = FuncHelp.GoogleBookAPIConnector(searchParameters); 

            var library = new List<Book>();
            for (int i = 0; i < localData.Items.Count; i++)
            {
                var GB = localData.Items[i];
                var locBook = new Book();

                //Verifies whether or not the ISBNs format and values are valid to add the book to the internal library.
                if (FuncHelp.isIsbnValid(GB.VolumeInfo.IndustryIdentifiers, locBook) == false)
                {
                    library.Remove(locBook);
                    continue;
                }

                //Gets the cover of the book image link
                FuncHelp.GetCoverImgLink(GB.VolumeInfo.ImageLinks, locBook);

                locBook.Title = GB.VolumeInfo.Title;
                locBook.Subtitle = GB.VolumeInfo.Subtitle;
                locBook.Description = GB.VolumeInfo.Description;
                locBook.TotalPages = GB.VolumeInfo.PageCount;
           
                //Gets the authors' names from GoogleBooksJson and passes it to Library
                FuncHelp.GetGBAuthorNames(GB.VolumeInfo.Authors, locBook);

                //Gets the Publisher data from GoogleBookJson
                locBook.PublisherName = GB.VolumeInfo.Publisher;
                FuncHelp.GetGBPublishDates(GB.VolumeInfo.PublishedDate, locBook);

                //Sets the language type based on the GoogleBook language data
                FuncHelp.GetLanguageType(GB.VolumeInfo.Language, locBook);

                //Sets Genre based on GoogleBook category data
                FuncHelp.GetGenreType(GB.VolumeInfo.Categories, locBook);

                //Sets the high-level of Book Maturity Rating based on GoogleBook data
                FuncHelp.GetMaturityRating(GB.VolumeInfo.MaturityRating, locBook);

                //Get a reading sample of the book 
                FuncHelp.GetBookReadingSamples(GB.AccessInfo.AccessViewStatus,GB.AccessInfo.WebReaderLink, GB.VolumeInfo.PreviewLink, locBook);

                // Set books reading status 
                //FuncHelp.SetReadingStatus(locBook);


                library.Add(locBook);

            }

            
        


            Console.WriteLine();
           

        }
    }
}