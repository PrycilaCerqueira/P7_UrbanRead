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

namespace P7_UrbanRead // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "AIzaSyC-5Ko6EbggLw5AQVesI1qnmqpbRaS72GI";

            Console.Write("Book search: ");
            string bookTopic= Console.ReadLine().Trim().ToLower();

            var client = new WebClient();
            var jsonData = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={bookTopic}&maxResults&key={apiKey}");
            var localData = JsonConvert.DeserializeObject<GoogleBooksJson.Root>(jsonData);

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
                FuncHelp.GetLanguageType(GB.VolumeInfo.Language.ToUpper().Trim(), locBook);

                //Sets Genre based on GoogleBook category data
                FuncHelp.GetGenreType(GB.VolumeInfo.Categories, locBook);

            }

            Console.WriteLine();
           

        }
    }
}