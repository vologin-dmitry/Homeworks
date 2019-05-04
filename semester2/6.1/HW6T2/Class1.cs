﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6T2
{
    /// <summary>
    /// Class with Map, filter and fold functions, for work with lists
    /// </summary>
    class ListMethods
    {
        /// <summary>
        /// Converts all list elements using the entered function
        /// </summary>
        /// <param name="list">Your list</param>
        /// <param name="func">The function you want to use for each item in the list</param>
        /// <returns>Changed list</returns>
        public static List<int> Map(List<int> list, Func<int, int> func)
        {
            var newList = new List<int>();
            foreach (var element in list)
            {
                newList.Add(func(element));
            }
            return newList;
        }

        /// <summary>
        /// Returns a list with elements that satisfy your condition
        /// </summary>
        /// <param name="list">Your list</param>
        /// <param name="func">The function, that filters your list</param>
        /// <returns>List with only elements, which satisfies your function</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> func)
        {
            var newList = new List<int>();
            foreach (var element in list)
            {
                if (func(element))
                {
                    newList.Add(element);
                }
            }
            return newList;
        }

        /// <summary>
        /// Accumulates the value of a list using some function
        /// </summary>
        /// <param name="list">Your list</param>
        /// <param name="func">Function, which accumulates your list elements by some rule</param>
        /// <param name="storage">Initial value for the accumulation function</param>
        /// <returns>Accumulated value from all list elements</returns>
        public static int Fold (List<int> list, Func<int, int, int> func, int storage)
        {
            foreach (var element in list)
            {
                storage = func(storage, element);
            }
            return storage;
        }
    }
}
