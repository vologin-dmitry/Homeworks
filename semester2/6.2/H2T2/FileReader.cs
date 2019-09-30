using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace H6T2
{
    /// <summary>
    /// A class that allows you to read from a file
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Reads data from a file and converts it into a list of strings
        /// </summary>
        /// <param name="filePath">The path of the file from which you want to read data</param>
        /// <returns>Data from a file in the form of a list of strings</returns>
        public static List<string> MakeList(string filePath)
        {
            StreamReader fileReader = new StreamReader(filePath);
            if (fileReader == null)
            {
                throw new FileNotFoundException();
            }
            var map = new List<string>();
            while (!fileReader.EndOfStream)
            {
                map.Add("#" + fileReader.ReadLine());
            }
            fileReader.Close();
            int size = map.Max( str => str.Length);
            CompleteMap(map, size + 1);
            DrawLines(map, size + 1);
            return map;
        }

        private static void CompleteMap(List<string> map, int size)
        {
            for (int i = 0; i < map.Count; ++i)
            {
                for (int j = map[i].Length; j < size; ++j)
                {
                    map[i] += "#";
                }
            }
        }

        private static void DrawLines(List<string> map, int size)
        {
            string line = "";
            for (int i = 0; i < size; ++i)
            {
                line += '#';
            }
            map.Add(line);
            map.Insert(0, line);
        }
    }
}