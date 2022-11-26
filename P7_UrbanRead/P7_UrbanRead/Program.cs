using System;
using System.Text.Json.Serialization;

namespace P7_UrbanRead // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Book> Books = new List<Book>();

            Console.WriteLine("Book search: ");
            string book = Console.ReadLine();

            var searchBook = JsonConvert.SerializeObject(book);

          
        }
    }
}