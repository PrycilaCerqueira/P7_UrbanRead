using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            long isbnNum;

            if (isbnIdentifiers != null)
            {
                foreach (var item in isbnIdentifiers)
                {
                    bool isntAlphaNumeric = long.TryParse(item.Identifier, out isbnNum);
                    if (isntAlphaNumeric)
                    {
                        if (item.Type == "ISBN_10")
                        {
                            isbnId.Isbn10 = isbnNum;
                        }
                        if (item.Type == "ISBN_13")
                        {
                            isbnId.Isbn13 = isbnNum;

                        }
                        if (item.Type == "OTHER")
                        {
                            return false;
                        }
                    }
                    else
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
        /// Verifies whether or not the ISBNs format and values are valid to adding to library
        /// </summary>
        /// <param name="isbnIdentifiers">GoogleBookJson ISBNs' data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static ISBN GetGBIsbnNumbers (List<GoogleBooksJson.IndustryIdentifier> isbnIdentifiers, Book locBook)
        {
            ISBN isbnId = new ISBN();
            long isbnNum;

            foreach (var item in isbnIdentifiers)
            {
                bool isntAlphaNumeric = long.TryParse(item.Identifier, out isbnNum);
                if (isntAlphaNumeric == true)
                {
                    if (item.Type == "OTHER")
                    {
                        continue;
                    }
                    if (item.Type == "ISBN_10")
                    {
                        isbnId.Isbn10 = isbnNum;
                    }
                    if (item.Type == "ISBN_13")
                    {
                        isbnId.Isbn13 = isbnNum;
                    }
                }

            }

            if (isbnId != null)
            {
                return isbnId;
            }
            return null;
                     
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
        /// Gets the PublisherDate data with the correct date format and datatype 
        /// </summary>
        /// <param name="bookPublishedDate">GoogleBookJson Published Date data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetGBPublishDates(string bookPublishedDate, Book locBook)
        {
            DateTime dt;

            //Converts the specified string representation of a date and time to its DateTime equivalent
            string[] validDateFormats = new string[]
            {
                    "yyyy",
                    "yyyy-mm-dd"
            };
            if (DateTime.TryParseExact(bookPublishedDate, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                locBook.PublishedDate = dt;
            }

        }

        /// <summary>
        /// Gets the Language and populates the data on the Book instance
        /// </summary>
        /// <param name="GBlang">GoogleBookJson Language data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetLanguageType(string GBlang, Book locBook)
        {
            GBlang = GBlang.ToLower();
            if (GBlang != null)
            {
                if (GBlang == "en")
                {
                    locBook.Language = LangType.English;
                }
                if (GBlang == "fr")
                {
                    locBook.Language = LangType.French;
                }
                if (GBlang == "es")
                {
                    locBook.Language = LangType.Spanish;
                }
                if (GBlang == "pt-br" || GBlang == "pt")
                {
                    locBook.Language = LangType.Portuguese;
                }
            }
            else
            {
                locBook.Language = LangType.Others;
            }

        }

        /// <summary>
        /// Gets the Language and populates the data on the Book instance
        /// </summary>
        /// <param name="Categories">GoogleBookJson Category data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetGenreType(List<string> Categories, Book locBook)
        {
            if (Categories != null)
            {
                foreach (string categ in Categories)
                {
                    locBook.Genre = categ;
                }
            }
            else
            {
                locBook.Genre = "Null";
            }
        }

    }
}
