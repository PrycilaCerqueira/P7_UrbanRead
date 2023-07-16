using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class UI
    {
        /// <summary>
        /// Menu for the users to refine their book search
        /// </summary>
        /// <returns>All the search parameters</returns>
        public static List <string> BookSearchMenu()
        {
            List<string> searchParameters = new List<string>();

            Console.Write("Book search: ");
            string bookTopic = Console.ReadLine().Trim().ToLower();
            searchParameters.Add(bookTopic);

            int bookTypeNum;
            do
            {
                Console.Write("\nSelect book type\n1) Only free ebooks\n2) Only paied ebooks\n3) All ebooks\n4) All booksn\nNumber: ");
                bookTypeNum = Int32.Parse(Console.ReadLine().Trim());
            } while (bookTypeNum < 1 || bookTypeNum > 4);
            
            switch (bookTypeNum)
            {

            }
            
           




            return searchParameters;

        } 
    }
}
