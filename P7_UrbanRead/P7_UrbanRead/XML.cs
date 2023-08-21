using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;

namespace P7_UrbanRead
{
    internal class XML
    {
        static string USERNAME = Environment.UserName;
        static string DIRECTORY = @$"C:\Users\{USERNAME}\Documents\UrbanRead";
        static string FILE = System.IO.Path.Combine(DIRECTORY, "Book_Library.xml");
        
       public static void ExportFile(List<Book> library)
        {

            try 
            {
                //Creates the UrbanRead folder in the given location if it doesn't exit
                if (!Directory.Exists(DIRECTORY))
                {
                    Directory.CreateDirectory(DIRECTORY);
                }
            }
            catch (Exception)  
            {
                //If the folder already exists in the given location, it fails silently
            }

            XmlSerializer ser = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter(FILE))
            {
                ser.Serialize(writer, library);
            }

        }

    }
}
