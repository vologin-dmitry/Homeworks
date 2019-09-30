using System;
using System.Collections.Generic;

namespace Test2_Try2
{
    /// <summary>
    /// A class that sorts the list of items given to it
    /// </summary>
    /// <typeparam name="T">Type of list element</typeparam>
    public class BubbleSort<T>
    {
        /// <summary>
        /// Sorts the entered list using the entered comparer
        /// </summary>
        /// <param name="list">List, you want to sort</param>
        /// <param name="comparer">Comparer, you want to use</param>
        public static void Sort(List<T> list, IComparer<T> comparer)
        {
            if (list == null || comparer == null)
            {
                throw new ArgumentNullException();
            }
            T temp;
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = i + 1; j < list.Count; ++j)
                {
                    if (comparer.Compare(list[i],list[j]) < 0)
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
