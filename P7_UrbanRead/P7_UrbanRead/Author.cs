using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P7_UrbanRead
{
    internal class Author
    {
        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

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

    }
}
    

