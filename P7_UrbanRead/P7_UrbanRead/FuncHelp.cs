using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class FuncHelp
    {
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
