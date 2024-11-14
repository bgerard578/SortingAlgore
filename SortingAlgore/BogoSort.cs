using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgore
{
    public class BogoSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> values)
        {
            Stopwatch stopwatch = new Stopwatch();
            //Calls InsertionSort
            stopwatch.Start();
            List<T> sortedList = BogoSortALGore(values);
            stopwatch.Stop();

            Console.WriteLine("\n -------------Bogo Sort----------------");
            PrintList(sortedList);
            Console.WriteLine("\n" + stopwatch.Elapsed);
        }
        static bool IsSorted(List<T> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (values[i].CompareTo(values[i + 1]) > 0)
                { 
                    return false; 
                }
            }
            return true;
        }

        static List<T> RandomPermutation(List<T> values)
        {
            Random randomRandy = new Random();
            var n = values.Count;
            while (n > 1)
            {
                n--;
                var i = randomRandy.Next(n + 1);
                var temp = values[i];
                values[i] = values[n];
                values[n] = temp;
            }
            return values;
        }

        static List<T> BogoSortALGore(List<T> values)
        {
            while (!IsSorted(values))
            {
                values = RandomPermutation(values);
                Console.ForegroundColor = GetRandomColor();
                PrintList(values);
            }
            return values;

        }
        private static ConsoleColor GetRandomColor()
        {
            // Generate random RGB values
            Random random = new Random();
            int r = random.Next(1,5);
            if (r == 1) { return  ConsoleColor.Red; }
            if (r == 2) { return ConsoleColor.Blue; }
            if (r == 3) { return ConsoleColor.Green; }
            if (r == 4) { return ConsoleColor.Yellow; }
            if (r == 5) { return ConsoleColor.Magenta; }
            return ConsoleColor.Cyan;
        }
        private static void PrintList(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + ", ");
            }
        }
    }
}
