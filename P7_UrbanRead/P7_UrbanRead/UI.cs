﻿using System;
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





            return searchParameters;

        } 
    }
}
