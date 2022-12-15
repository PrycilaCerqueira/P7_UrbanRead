using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Json;
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

            var books = new List<Book>();
            for (int i = 0; i < localData.Items.Count; i++)
            {
                var GB = localData.Items[i];
                var locBook = new Book();

                locBook.Title = GB.VolumeInfo.Title;
                locBook.Subtitle = GB.VolumeInfo.Subtitle;
                locBook.Description = GB.VolumeInfo.Description;
                locBook.TotalPages = GB.VolumeInfo.PageCount;
                locBook.PublishedDate = DateTime.Parse(GB.VolumeInfo.PublishedDate);
                
                var isbnId = new ISBN();
                foreach (var item in GB.VolumeInfo.IndustryIdentifiers)
                {
                    if (item.Type == "ISBN_10")
                    {
                        isbnId.Isbn10 = Int64.Parse(item.Identifier);
                    }
                    if (item.Type == "ISBN_13")
                    {
                        isbnId.Isbn13 = Int64.Parse(item.Identifier);
                    }


                    locBook.ISBNS.Add(isbnId);  
                }
                                
                books.Add(locBook);

            }


            Console.WriteLine();
           

        }
    }
}