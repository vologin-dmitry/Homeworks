using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortTest
{
    public class IntComparerTest : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            if (first > second)
            {
                return 1;
            }
            if (second > first)
            {
                return -1;
            }
            return 0;
        }
    }
}
