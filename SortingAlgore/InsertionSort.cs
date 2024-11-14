using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgore
{
    public class InsertionSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> values)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<T> newList = InsertionSort1(values);
            stopwatch.Stop();

            Console.WriteLine("\n -------------Insertion Sort----------------");
            //PrintList(newList);
            Console.WriteLine("\n" + stopwatch.Elapsed.TotalSeconds);
        }
        private List<T> InsertionSort1(List<T> values)
        {
            int i;
            int j;
            for (i = 1; i < values.Count(); i++)
            {
                T temp = values[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (temp.CompareTo(values[j]) < 0)
                    {
                        values[j + 1] = values[j];
                        j--;
                    }
                    else
                    {
                        ins = 1;
                    }
                }
                values[j + 1] = temp;
            }
            return values;
        }

        /// <summary>
        /// Prints the list of items
        /// </summary>
        /// <param name="list"></param>
        private static void PrintList(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + ", ");
            }
        }
    }
}
