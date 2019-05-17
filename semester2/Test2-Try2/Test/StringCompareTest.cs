using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2_Try2
{
    class StringCompareTest : IComparer<string>
    {
        public int Compare(string first, string second)
            => first.Length - second.Length;
    }
}