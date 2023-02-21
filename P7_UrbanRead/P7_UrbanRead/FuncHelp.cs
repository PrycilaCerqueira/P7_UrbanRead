using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class FuncHelp
    {

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
