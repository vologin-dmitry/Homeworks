using System.Collections.Generic;

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
