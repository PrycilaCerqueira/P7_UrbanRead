using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;

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

            var GB = localData.Items[0];
            var locBook = new Book();

            locBook.Title = GB.VolumeInfo.Title;

            //for (int i = 0; i < searchData.Length; i++)
            //{
                //var book = new Book();
                //book.Title = searchData.
                
                //books.Add(book);

            //}
          

            Console.WriteLine();
            //TODO: Re-watch the videos https://www.youtube.com/watch?v=z-5ot9WkE80 and https://www.youtube.com/watch?v=XvsOnKvwhfQ 

        }
    }
}