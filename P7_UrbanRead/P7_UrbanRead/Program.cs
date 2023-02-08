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
            var jsonData = client.DownloadString($"https://www.googleapis.com/library/v1/volumes?q={bookTopic}&key={apiKey}");
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
                
                /*
                var authors = new Author();
                string aName = GB.VolumeInfo.Authors;
                foreach (var aName in GB.VolumeInfo.Authors)
                {   
                    authors.FirstName = aName.Split(' ');
                    locBook.Authors.Add();
                }
                */
                //Copy the ISBN codes into their specific variables                

                library.Add(locBook);

            }

            Console.WriteLine();
           

        }
    }
}