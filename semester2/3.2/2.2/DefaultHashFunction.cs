using System;

namespace Table 
{
    /// <summary>
    /// Default hash function from visual studio, but returns only positive numbers
    /// </summary>
    public class DefaultHashFunction : IHash
    {
        /// <summary>
        /// Retrns absolute value of default hash function from visual studio
        /// </summary>
        /// <param name="data">The value you want to get the hash from</param>
        /// <returns>Hash from entered value</returns>
        public int HashCode(string data)
            => Math.Abs(data.GetHashCode());
    }
}