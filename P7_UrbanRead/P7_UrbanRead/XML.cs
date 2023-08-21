using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;


namespace P7_UrbanRead
{
    internal class XML
    {
        static string USERNAME = Environment.UserName;
        static string PATH = @$"C:\Users\{USERNAME}\Documents\UrbanRead_Library";

        public static void ExportFile(List<Book> library)
        {

            XmlSerializer ser = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                ser.Serialize(writer, library);
            }

        }

    }
}
