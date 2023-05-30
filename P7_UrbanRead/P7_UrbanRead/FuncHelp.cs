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
            GetGBIsbnNumbers(isbnIdentifiers, locBook);
            if (!locBook.ISBNS.Contains(null))
            {
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
        public static void GetGBIsbnNumbers(List<GoogleBooksJson.IndustryIdentifier> isbnIdentifiers, Book locBook)
        {
            ISBN isbnId = new ISBN();
            long isbnNum;

            if (isbnIdentifiers != null)
            {
                foreach (var item in isbnIdentifiers)
                {
                    if (item.Type != null)
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
                    else
                    {
                        continue;
                    }
                }

            }
            else
            {
                isbnId = null;
            }

            locBook.ISBNS.Add(isbnId);
        }

        /// <summary>
        ///  Gets the Book Cover Image and populates the data on the Book instance 
        /// </summary>
        public static void GetCoverImgLink(GoogleBooksJson.ImageLinks imageLinks, Book locBook)
        {
            string imgThumbnails;

            if (imageLinks != null)
            {
                if (!String.IsNullOrEmpty(imageLinks.Thumbnail))
                {
                    imgThumbnails = imageLinks.Thumbnail.ToString();
                }
                else if (!String.IsNullOrEmpty(imageLinks.SmallThumbnail))
                {
                    imgThumbnails = imageLinks.SmallThumbnail.ToString();
                }
                else
                {
                    imgThumbnails = "Null";
                }
            }
            else
            {
                imgThumbnails = "Null";
            }

            locBook.CoverImgLink = imgThumbnails;

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
        /// <param name="lang">GoogleBookJson Language data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetLanguageType(string lang, Book locBook)
        {
            lang = lang.ToLower();
            if (!string.IsNullOrEmpty(lang))
            {
                if (lang == "en")
                {
                    locBook.Language = LangType.English;
                }
                if (lang == "fr")
                {
                    locBook.Language = LangType.French;
                }
                if (lang == "es")
                {
                    locBook.Language = LangType.Spanish;
                }
                if (lang == "pt-br" || lang == "pt")
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

        /// <summary>
        /// Gets the Maturity Raiting and populates the data on the Book instance
        /// </summary>
        /// <param name="matRat">GoogleBookJson Maturity data</param>
        /// <param name="locBook">Book instance with its elements to be populated</param>
        public static void GetMaturityRating(string matRate, Book locBook)
        {
            matRate = matRate.ToLower();
            if (!string.IsNullOrEmpty(matRate))
            {
                if (matRate == "mature")
                {
                    //TODO: Search on how to create a list of Enum 
                    locBook.MaturityRating.Add(MatRatType.Mature);
                }
            }

        }

    }
}
