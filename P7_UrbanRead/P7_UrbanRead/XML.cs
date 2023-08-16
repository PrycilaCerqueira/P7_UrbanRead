using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace P7_UrbanRead
{
    internal class XML
    {
        private static string _USERNAME = Environment.UserName;
        private static string _PATH = @$"C:\Users\{_USERNAME}\AppData\Local\Temp";

        public static void ExportFile(List<Book> library)
        {
            XmlSerializer seria = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter(_PATH))
            {
                seria.Serialize(writer, library);
            }

        }

    }
}
