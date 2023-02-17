using Newtonsoft.Json;
using System;
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
            var jsonData = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={bookTopic}&key={apiKey}");
            var localData = JsonConvert.DeserializeObject<GoogleBooksJson.Root>(jsonData);

            var library = new List<Book>();
            for (int i = 0; i < localData.Items.Count; i++)
            {
                var GB = localData.Items[i];
                var locBook = new Book();

                //Verifies whether or not the ISBNs format and values are valid to add the book to the internal library.
                var isbnIdentifiers = GB.VolumeInfo.IndustryIdentifiers;
                if (ISBN.isIsbnValid(isbnIdentifiers, locBook) == false)
                {
                    library.Remove(locBook);
                    continue;
                }

                locBook.Title = GB.VolumeInfo.Title;
                locBook.Subtitle = GB.VolumeInfo.Subtitle;
                locBook.Description = GB.VolumeInfo.Description;
                locBook.TotalPages = GB.VolumeInfo.PageCount;

                //Gets the authors' names from GoogleBooksJson and passes it to Library
                Author.GetGBAuthorNames(GB.VolumeInfo.Authors, locBook);

                //Gets the Publisher data from GoogleBookJson
                //TODO: get the publisher name from GoogleBookJson and passes it to PublisherName 



                //TODO: move the block below to Publisher class
                //Converts the specified string representation of a date and time to its DateTime equivalent. It adds the date/time to the PublishDate variable
                Publisher.GetGBPublishDates(GB.VolumeInfo.PublishedDate, locBook);
                

                library.Add(locBook);

            }

            Console.WriteLine();
           

        }
    }
}