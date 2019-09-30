using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    /// <summary>
    /// Hash function, which uses multiplication of itself on every iteration
    /// </summary>
    public class MultiplicationHashFunction : IHash
    {
        /// <summary>
        /// Each iteration multiplies the value of the previous iteration by 5 and adds a new char
        /// </summary>
        /// <param name="data">The value you want to get the hash from</param>
        /// <returns>Hash from entered value</returns>
        public int HashCode(string data)
        {
            int ans = 0;
            foreach (char ch in data)
            {
                ans = ans * 5 + ch;
            }
            return ans;
        }
    }
}
