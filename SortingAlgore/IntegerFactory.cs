using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgore
{
    public static class IntegerFactory
    {
        //Turns a file of ints into a list
        public static List<int> ParseIntegerFile(string filePath)
        {
            List<int> ints = new List<int>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    ints.Add(int.Parse(reader.ReadLine()));
                }
            }
            return ints;
        }
    }
}
