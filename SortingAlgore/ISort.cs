using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgore
{
    internal interface ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> values);
    }
}
