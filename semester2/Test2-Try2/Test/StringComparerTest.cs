using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortTest
{
    public class StringComparerTest : IComparer<string>
    {
        public int Compare(string first, string second)
            => first.Length - second.Length;
    }
}