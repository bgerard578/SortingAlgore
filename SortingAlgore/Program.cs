using System.IO;

namespace SortingAlgore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Brady Gerard and Hayden Culbert
            string type;
            //tetermins if it is sorting books or ints
            Console.WriteLine("int or book?");
            type = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Please provide your file path.");
            if (type == "int")
            {
                //saves the file path
                string path = Console.ReadLine();
                //sets the list of ints
                List<int> testData = IntegerFactory.ParseIntegerFile(path);
                Console.Clear();
                // Print the generated list
                Console.WriteLine(string.Join(", ", testData));
                //creates the sorts
                MergeSortAlGore<int> TestMerge = new MergeSortAlGore<int>();
                InsertionSort<int> TestInsertion = new InsertionSort<int>();
                BogoSort<int> TestBogoSort = new BogoSort<int>();
                //runs the merge sort
                TestMerge.Sort(testData);
                //resets the list of ints
                testData = IntegerFactory.ParseIntegerFile(path);
                //runs the insertion sort
                TestInsertion.Sort(testData);
                /*testData = IntegerFactory.ParseIntegerFile(path);
                TestBogoSort.Sort(testData);*/
            }
            else if ( type == "book")
            {
                string path = Console.ReadLine();
                List<Book> testData = ParseBookFile(path);
                Console.Clear();
                // Print the generated list
                foreach (Book book in testData) { Console.WriteLine(book.ToString()); }
                MergeSortAlGore<Book> TestMerge = new MergeSortAlGore<Book>();
                InsertionSort<Book> TestInsertion = new InsertionSort<Book>();
                BogoSort<Book> TestBogoSort = new BogoSort<Book>();
                //runs the merge sort
                TestMerge.Sort(testData);
                //resets the list of ints
                testData = ParseBookFile(path);
                //runs the insertion sort
                TestInsertion.Sort(testData);
                /*testData = ParseBookFile(path);
                TestBogoSort.Sort(testData);*/
            }
        }
        public static List<Book> ParseBookFile(string filePath)
        {
            List<Book> books = new List<Book>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                //passes the first 3 lines
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string description = reader.ReadLine();
                    //the last line states with + so this skips the last line
                    if (!description.StartsWith("+"))
                    {
                        books.Add(Book.Parse(description));
                    }
                }
            }
            return books;
        }
    }
}
