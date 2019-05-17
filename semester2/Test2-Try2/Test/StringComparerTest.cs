using System;
using System.Collections.Generic;

namespace BubbleSortTest
{
    public class StringComparerTest : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }
            return first.Length - second.Length;
        }
    }
}