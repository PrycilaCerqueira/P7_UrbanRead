﻿namespace P7_UrbanRead // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> searchParameters = UI.BookSearchMenu();
            var searchResult = Help.initiateBookSearch(searchParameters);

            foreach (Book result in searchResult)
            {
                Console.WriteLine();
                Console.WriteLine(result.ToString());
            }

            
            
            // Set books reading status 
            //FuncHelp.SetReadingStatus(locBook);




            Console.WriteLine();
           

        }
    }
}