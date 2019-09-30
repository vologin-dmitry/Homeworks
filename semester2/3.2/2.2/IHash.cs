namespace Table
{
    /// <summary>
    /// Interface of hash functions for strings
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// A function that converts a string to a number
        /// </summary>
        /// <param name="data">String to conver to a number</param>
        /// <returns>Hash from this value</returns>
        int HashCode(string data);
    }
}
