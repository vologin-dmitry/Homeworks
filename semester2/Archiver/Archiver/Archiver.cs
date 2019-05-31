using System.Collections.Generic;
using System.Linq;

namespace Archiver
{
    public static class Archiver
    {
        /// <summary>
        /// Compresses the array
        /// </summary>
        /// <param name="input">Byte array, you want to compress</param>
        /// <returns>Compressed array</returns>
        public static byte[] Archive(byte[] input)
        {
            var archivedQueue = new Queue<byte>();
            for (int i = 0; i < input.Count();)
            {
                byte j = 1;
                while (j < 255 && i + j < input.Count() && input[i] == input[i + j])
                {
                    ++j;
                }
                archivedQueue.Enqueue(j);
                archivedQueue.Enqueue(input[i]);
                i += j;
            }
            var output = new byte[archivedQueue.Count()];
            archivedQueue.CopyTo(output, 0);
            return output;
        }

        /// <summary>
        /// Decompresses array, which someone compressed once by "Archive" method
        /// </summary>
        /// <param name="input">Byte array, you want to decomoress</param>
        /// <returns>Decompressed array</returns>
        public static byte[] Unarchive(byte[] input)
        {
            var unarchivedQueue = new Queue<byte>();
            for (var i = 0; i < input.Length; ++i)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < input[i]; ++j)
                    {
                        unarchivedQueue.Enqueue(input[i + 1]);
                    }
                }
            }
            var output = new byte[unarchivedQueue.Count()];
            unarchivedQueue.CopyTo(output, 0);
            return output;
        }
    }
}
