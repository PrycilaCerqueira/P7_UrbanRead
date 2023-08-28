namespace P7_UrbanRead
{
    internal class UI
    {
        /// <summary>
        /// Menu for the users to refine their book search
        /// </summary>
        /// <returns>All the search parameters</returns>
        public static List <string> BookSearchMenu()
        {
            List<string> searchParameters = new List<string>();

            Console.Write("Book search: ");
            string bookTopic = Console.ReadLine().Trim().ToLower();
            searchParameters.Add(bookTopic);

            int bookTypeNum;
            do
            {
                Console.Write("\nSelect book type\n1) Only free ebooks\n2) Only paid ebooks\n3) All ebooks\n4) All books\nNumber: ");
                bookTypeNum = Int32.Parse(Console.ReadLine().Trim());

            } while (bookTypeNum < 1 || bookTypeNum > 4);
            
            switch (bookTypeNum)
            {
                case 1:
                    searchParameters.Add("free-ebooks");
                    break;
                case 2:
                    searchParameters.Add("paid-ebooks");
                    break;
                case 3:
                    searchParameters.Add("ebooks");
                    break;
                case 4:
                    searchParameters.Add("partial");
                    break;
                default:
                    searchParameters.Add("partial");
                    break;
            }

            return searchParameters;

        } 
    }
}
