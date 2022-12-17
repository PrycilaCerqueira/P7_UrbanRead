using Newtonsoft.Json;
using System;
using System.Globalization;
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


                //Converts the specified string representation of a date and time to its DateTime equivalent.
                DateTime dt;
                string[] validDateFormats = new string[] 
                {
                    "yyyy",
                    "yyyy-mm-dd"
                };
                if (DateTime.TryParseExact(GB.VolumeInfo.PublishedDate, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    locBook.PublishedDate = dt;
                }

                var authors = new Author();
                string aName = GB.VolumeInfo.Authors;
                foreach (var aName in GB.VolumeInfo.Authors)
                {

                   
                    authors.FirstName = aName.Split(' ');
                    locBook.Authors.Add();
                }
                
                //Copy the ISBN codes into their specific variables                
                var isbnId = new ISBN();
                foreach (var item in GB.VolumeInfo.IndustryIdentifiers)
                {
                    if (item.Type == "ISBN_10")
                    {
                        isbnId.Isbn10 = Int64.Parse(item.Identifier);
                    }
                    else if (item.Type == "ISBN_13")
                    {
                        isbnId.Isbn13 = Int64.Parse(item.Identifier);
                    }
                    else
                    {
                        break;
                    }

                    locBook.ISBNS.Add(isbnId);  
                }
                
                
                books.Add(locBook);

            }


            Console.WriteLine();
           

        }
    }
}