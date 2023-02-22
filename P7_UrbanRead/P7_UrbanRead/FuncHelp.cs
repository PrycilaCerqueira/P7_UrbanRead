using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class FuncHelp
    {
        /// <summary>
        /// Verifies whether the ISBN has a valid format or not 
        /// </summary>
        /// <param name="isbnIdentifiers">GoogleBookJson ISBN data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        /// <returns>Returns true/false for the ISBN format</returns>
        public static bool isIsbnValid(List<GoogleBooksJson.IndustryIdentifier> isbnIdentifiers, Book locBook)
        {
            var isbnId = new ISBN();
            if (isbnIdentifiers != null)
            {
                foreach (var item in isbnIdentifiers)
                {
                    if (item.Type == "ISBN_10")
                    {
                        isbnId.Isbn10 = item.Identifier;
                    }
                    if (item.Type == "ISBN_13")
                    {
                        isbnId.Isbn13 = Int64.Parse(item.Identifier);

                    }
                    if (item.Type == "OTHER")
                    {
                        return false;
                    }

                }
                locBook.ISBNS.Add(isbnId);
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// Gets the Authors'Names and populates the data on the Book instance 
        /// </summary>
        /// <param name="aNames">GoogleBookJson Authors' data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetGBAuthorNames(List<string> aNames, Book locBook)
        {
            for (int n = 0; n < aNames.Count; n++)
            {
                var authorsNames = new Author();
                authorsNames.FullName = aNames[n];
                if (authorsNames == null)
                {
                    continue;
                }

                locBook.Authors.Add(authorsNames);
            }

        }

        /// <summary>
        /// Gets the Language and populates the data on the Book instance
        /// </summary>
        /// <param name="GBlang">GoogleBookJson Language data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetLanguageType(string GBlang, Book locBook)
        {

            if (GBlang == "EN")
            {
                locBook.Language = LangType.English;
            }
            if (GBlang == "FR")
            {
                locBook.Language = LangType.French;
            }
            if (GBlang == "ES")
            {
                locBook.Language = LangType.Spanish;
            }
            if (GBlang == "PT-BR" || GBlang == "PT")
            {
                locBook.Language = LangType.Portuguese;
            }

        }
    }
}
