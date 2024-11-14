using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SortingAlgore
{
    public class MergeSortAlGore<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> values)
        {
            Stopwatch stopwatch = new Stopwatch();

            //Calls DoMergeSort
            stopwatch.Start();
            List<T> sortedList = DoMergeSort(values);
            stopwatch.Stop();

            Console.WriteLine("\n -------------Merge Sort----------------");
            //PrintList(sortedList);
            Console.WriteLine("\n" + stopwatch.Elapsed.TotalSeconds);
        }

        /// <summary>
        /// Break up the list into pieces
        /// </summary>
        /// <param name="primary">The unsorted List input</param>
        /// <returns></returns>
        private static List<T> DoMergeSort(List<T> primary)
        {
            if (primary.Count <= 1) //Check for base case
            {
                return primary;
            }

            //Create the left and right side of the primary starting list
            List<T> left = new List<T>();
            List<T> right = new List<T>();

            //Find what index the middle is at
            int midPoint = primary.Count / 2;

            //Add all values to the left of the midpoint
            for (int i = 0; i < midPoint; i++)
            {
                left.Add(primary[i]);
            }

            //Add all values to the right of the midpoint
            for (int i = midPoint; i < primary.Count; i++)
            {
                right.Add(primary[i]);
            }


            //Recursively divide both lists until the get caught by the base case if statement in the beginning
            left = DoMergeSort(left);
            right = DoMergeSort(right);


            //Calls DoMerge to sort
            return DoMerge(left, right);
        }

        /// <summary>
        /// Sorts the broken up list 
        /// </summary>
        /// <param name="left">Left input lists</param>
        /// <param name="right">Right input list</param>
        /// <returns></returns>
        private static List<T> DoMerge(List<T> left, List<T> right) 
        {
            List<T> result = new List<T>();

            // Compare elements from both lists and merge them in sorted order
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First().CompareTo(right.First()) <= 0) // Compare the first elements of both lists
                    {
                        result.Add(left.First());
                        left.Remove(left.First()); // Remove the added element from the list
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First()); // Remove the added element from the list
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result; // Return the merged and sorted list
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
