using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Test2_Try2;

namespace Test
{
    [TestClass]
    public class BubbleSortTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }
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
        public void EqualIntSort()
        {
            var list = new List<int> { -5, -5, -5, -5, -5, -5, -5, -5, -5, -5, -5 };
            BubbleSort<int>.Sort(list, new IntComparerTest());
            for (int i = 0; i < 11; ++i)
            {
                Assert.AreEqual(-5, list[i]);
            }
        }
    }
}
