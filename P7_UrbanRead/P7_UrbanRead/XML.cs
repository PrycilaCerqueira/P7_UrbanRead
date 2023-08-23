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
        
        /// <summary>
        /// Serializer the Book Library into XML File
        /// </summary>
        /// <param name="library">Book Library</param>
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

            //Exports the file in XML format into the Directory 
            XmlSerializer ser = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter(FILE))
            {
                ser.Serialize(writer, library);
            }

       }

        /// <summary>
        ///  Deserializer the XML File into the Book Library
        /// </summary>
        /// <returns>Book Library</returns>
        public static List<Book> ImportFile()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Book>));
            using (FileStream reader = new FileStream(FILE,FileMode.Open, FileAccess.Read))
            {
                var library = (List<Book>)ser.Deserialize(reader);
                return library;
            }
                       
        }

    }
}
