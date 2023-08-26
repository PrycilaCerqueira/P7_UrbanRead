using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace P7_UrbanRead
{
    internal class Help
    {
        /// <summary>
        /// Establishes the API connection with Google Books to retrieve the books data
        /// </summary>
        /// <param name="bookTopic">Topic of the Book</param>
        /// <returns>Google Books findings of the topic</returns>
        public static GoogleBooksJson.Root GoogleBookAPIConnector(List<string> parameters)
        {

            string bookTopic = parameters[0];
            string filter = parameters[1];

            string apiKey = Secret.gbKey;
            
            var client = new WebClient();
            var jsonData = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={bookTopic}&filter={filter}&printType=books&maxResults=40&key={apiKey}");
            var localData = JsonConvert.DeserializeObject<GoogleBooksJson.Root>(jsonData);
            
            return localData;
        }

        /// <summary>
        /// Fetchs GoogleBooks book reference into a local library  
        /// </summary>
        /// <param name="GBCollection">GoogleBooks book collection</param>
        /// <returns>Book library</returns>
        public static List<Book> LoadGoogleBooks(GoogleBooksJson.Root GBCollection)
        {
            var library = new List<Book>();
            for (int i = 0; i < GBCollection.Items.Count; i++)
            {
                var gb = GBCollection.Items[i];
                var bookRef = new Book();

                //Verifies whether or not the ISBNs format and values are valid to add the bookRef to the internal library.
                if (isIsbnValid(gb.VolumeInfo.IndustryIdentifiers, bookRef) == false)
                {
                    library.Remove(bookRef);
                    continue;
                }

                //Gets the cover of the bookRef image link
                GetCoverImgLink(gb.VolumeInfo.ImageLinks, bookRef);

                bookRef.Title = gb.VolumeInfo.Title;
                bookRef.Subtitle = gb.VolumeInfo.Subtitle;
                bookRef.Description = gb.VolumeInfo.Description;
                bookRef.TotalPages = gb.VolumeInfo.PageCount;

                //Gets the authors' names from GoogleBooksJson and passes it to Library
                GetGBAuthorNames(gb.VolumeInfo.Authors, bookRef);

                //Gets the Publisher data from GoogleBookJson
                bookRef.PublisherName = gb.VolumeInfo.Publisher;
                GetGBPublishDates(gb.VolumeInfo.PublishedDate, bookRef);

                //Sets the language type based on the GoogleBook language data
                GetLanguageType(gb.VolumeInfo.Language, bookRef);

                //Sets Genre based on GoogleBook category data
                GetGenreType(gb.VolumeInfo.Categories, bookRef);

                //Sets the high-level of Book Maturity Rating based on GoogleBook data
                GetMaturityRating(gb.VolumeInfo.MaturityRating, bookRef);

                //Get a reading sample of the bookRef 
                GetBookReadingSamples(gb.AccessInfo.AccessViewStatus, gb.AccessInfo.WebReaderLink, gb.VolumeInfo.PreviewLink, bookRef);

                library.Add(bookRef);

            }

            return library;

        }

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
                        else
                        {
                            isbnId = null;
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
            if (aNames != null)
            {
                foreach (string name in aNames)
                {
                    Author authorsName = new Author();
                    authorsName.FullName = name;
                    locBook.Authors.Add(authorsName);
                }
            }
            else
            {
                Author authorsName = new Author();
                authorsName.FullName = "unknown";
                locBook.Authors.Add(authorsName);
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
                    locBook.MaturityRating.Add(MatRatType.Mature);
                }
                if (matRate == "not_mature")
                {
                    locBook.MaturityRating.Add(MatRatType.NotMature);
                }
                if (matRate == "everyone")
                {
                    locBook.MaturityRating.Add(MatRatType.Everyone);
                }
                if (matRate == "child 6y to 9y")
                {
                    locBook.MaturityRating.Add(MatRatType.Child_6to9);
                }
                if (matRate == "teen 9y to 13y")
                {
                    locBook.MaturityRating.Add(MatRatType.Teen_9to13);
                }
                if (matRate == "teen 13y to 17y")
                {
                    locBook.MaturityRating.Add(MatRatType.Teen_13to17);
                }
                if (matRate == "adult")
                {
                    locBook.MaturityRating.Add(MatRatType.Adult);
                }
                if (matRate == "restricted")
                {
                    locBook.MaturityRating.Add(MatRatType.Restricted);
                }
            }

        }

        /// <summary>
        /// Gets the link of the bookRef preview and populates the data on the Book instance
        /// </summary>
        public static void GetBookReadingSamples(string sampleStatus, string webLink, string previewlink, Book locBook)
        {

            if (sampleStatus == "SAMPLE")
            {
                webLink = webLink.Replace("&hl=", "");
                locBook.BookSampleLinks.Add(webLink);

                locBook.BookSampleLinks.Add(previewlink);
            }         
            else
            {
                locBook.BookSampleLinks.Add("Null");
            }
        }

        /// <summary>
        /// Function will return the bookRef reading status based on the page at users' are 
        /// </summary>
        /// <param name="book">Library Book</param>
        public static void SetReadingStatus(ActiveBook book)
        {
            if (book.PageAt == book.ActBook.TotalPages)
            {
                book.ReadingStatus = ReadStatus.Finished;
            }
            if (book.PageAt > 0 && book.PageAt != book.ActBook.TotalPages)
            {
                book.ReadingStatus = ReadStatus.InProgress;
            }
            if (book.PageAt <= 0)
            {
                book.ReadingStatus = ReadStatus.Unread;
            }

        }

    }
}
