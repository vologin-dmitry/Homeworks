using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Test2_Try2;

namespace BubbleSortTest
{
    [TestClass]
    public class BubbleSortTest
    {
        [TestMethod]
        public void RightSizeIntTest()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            BubbleSort<int>.Sort(list, new IntComparerTest());
            Assert.AreEqual(9, list.Count);
        }

        [TestMethod]
        public void ReverseSortIntTest()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            BubbleSort<int>.Sort(list, new IntComparerTest());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(8 - i, list[i]);
            }
        }

        [TestMethod]
        public void SortedSortIntTest()
        {
            var list = new List<int> { 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 };
            BubbleSort<int>.Sort(list, new IntComparerTest());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(5 - i, list[i]);
            }
        }

        [TestMethod]
        public void SortStringTest()
        {
            var list = new List<string> { "hey you man", "you", "hello", "olololo" };
            var answers = new string[] { "hey you man", "olololo", "hello", "you" };
            BubbleSort<string>.Sort(list, new StringComparerTest());
            for (int i = 0; i < 4; ++i)
            {
                Assert.AreEqual(answers[i], list[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OneObjectNullTest()
            => BubbleSort<int>.Sort(null, new IntComparerTest());
    }
}
