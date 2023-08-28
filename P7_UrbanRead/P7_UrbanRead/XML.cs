using System.Xml.Serialization;

namespace P7_UrbanRead
{
    internal class XML
    {
        static string USERNAME = Environment.UserName;
        static string FOLDER = @$"C:\Users\{USERNAME}\Documents\UrbanRead";
        static string FILE = System.IO.Path.Combine(FOLDER, "Book_Library.xml");
        
               
        /// <summary>
        /// Create the XML repository folder on the user's PC profile
        /// </summary>
        public static void CreateRepoFolder()
        {
            try
            {
                //Creates the UrbanRead folder in the given location if it doesn't exit
                if (!Directory.Exists(FOLDER))
                {
                    Directory.CreateDirectory(FOLDER);
                }
            }
            catch (Exception)
            {
                //If the folder already exists in the given location, it fails silently
            }

        }

        /// <summary>
        /// Serializer the Book Library into XML File
        /// </summary>
        /// <param name="library">Book Library</param>
        public static void ExportFile(List<Book> library)
        { 
            CreateRepoFolder();

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

        public static List<Book> LoadLocalLibrary()
        {
            List<Book> library;

            if (File.Exists(FILE))
            {
                library = ImportFile();
            }
            else
            {
                library = null;
            }
            return library;

        }

    }
}
