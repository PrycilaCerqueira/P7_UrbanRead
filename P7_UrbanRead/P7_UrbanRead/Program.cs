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
            string book = Console.ReadLine().Trim().ToLower();

            WebClient client = new WebClient();
            string htmlBookSearch = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={book}&key={apiKey}");
            //string htmlBookData = File.ReadAllText(htmlBookSearch);

            var books = JsonSerializer.Deserialize<List<Book>>(htmlBookSearch);

            //TODO: Re-watch the videos https://www.youtube.com/watch?v=z-5ot9WkE80 and https://www.youtube.com/watch?v=XvsOnKvwhfQ 

        }
    }
}