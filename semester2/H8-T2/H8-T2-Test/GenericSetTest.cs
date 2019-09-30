using Microsoft.VisualStudio.TestTools.UnitTesting;
using H8_T2;

namespace H8_T2_Test
{
    [TestClass]
    public class GenericSet
    {
        [TestMethod]
        public void AddTest()
        {
            var intSet = new GenericSet<int>();
            intSet.Add(8);
            Assert.AreEqual(1, intSet.Count);
        }

        [TestMethod]
        public void AddExistingTest()
        {
            var intSet = new GenericSet<int>();
            intSet.Add(8);
            intSet.Add(16);
            intSet.Add(8);
            Assert.AreEqual(2, intSet.Count);
        }

        [TestMethod]
        public void ContainsTrueTest()
        {
            var intSet = new GenericSet<int>();
            intSet.Add(8);
            Assert.AreEqual(true, intSet.Contains(8));
        }

        [TestMethod]
        public void ContainsFalseTest()
        {
            var intSet = new GenericSet<int>();
            intSet.Add(8);
            Assert.AreEqual(false, intSet.Contains(3));
        }

        [TestMethod]
        public void ForeachTest()
        {
            var intSet = new GenericSet<int>();
            intSet.Add(8);
            intSet.Add(54);
            intSet.Add(2);
            intSet.Add(-2);
            var check = new int[] { 8, 2, -2, 54 };
            var i = 0;
            foreach (var element in intSet)
            {
                Assert.AreEqual(check[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void CountTest()
        {
            var stringSet = new GenericSet<string>();
            stringSet.Add("ohhimark");
            Assert.AreEqual(1, stringSet.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            var stringSet = new GenericSet<string>();
            stringSet.Add("ohhimark");
            stringSet.Add("ohhidoggy");
            stringSet.Clear();
            Assert.AreEqual(0, stringSet.Count);
        }

        [TestMethod]
        public void CopyToTest()
        {
            var intSet = new GenericSet<int>();
            intSet.Add(8);
            intSet.Add(54);
            intSet.Add(2);
            intSet.Add(-2);
            var check = new int[] { 8, 2, -2, 54 };
            var output = new int[4];
            intSet.CopyTo(output, 0);
            CollectionAssert.AreEqual(check, output);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var intSet = new GenericSet<int>();
            var toAdd = new int[] { 5, 16, -32, 56, 0, -1, 44, -112, 13 };
            for (int i = 0; i < toAdd.Length; ++i)
            {
                intSet.Add(toAdd[i]);
            }
            Assert.IsTrue(intSet.Remove(56));
            Assert.IsTrue(intSet.Remove(-1));
            Assert.IsTrue(intSet.Remove(5));
            Assert.IsFalse(intSet.Remove(-1313));
            var check = new int[] { 0, -32, -112, 16, 13, 44 };
            var output = new int[6];
            intSet.CopyTo(output, 0);
            CollectionAssert.AreEqual(check, output);
        }

        [TestMethod]
        public void RemoveEmptyTest()
        {
            var intSet = new GenericSet<int>();
            Assert.IsFalse(intSet.Remove(56));
            Assert.AreEqual(0, intSet.Count);
        }

        [TestMethod]
        public void SetEqualsTrueTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var data = new int[] { 5, 16, -32, 56, 0, -1, 44, -112, 13 };
            for (int i = 0; i < data.Length; ++i)
            {
                intSetFirst.Add(data[i]);
                intSetSecond.Add(data[i]);
            }
            Assert.IsTrue(intSetFirst.SetEquals(intSetSecond));
        }

        [TestMethod]
        public void SetEqualsFalseTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var data = new int[] { 5, 16, -32, 56, 0, -1, 44, -112, 13 };
            for (int i = 0; i < data.Length; ++i)
            {
                intSetFirst.Add(data[i]);
                intSetSecond.Add(data[i]);
            }
            intSetSecond.Add(-4);
            Assert.IsFalse(intSetFirst.SetEquals(intSetSecond));
        }

        [TestMethod]
        public void UnionWithTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var data = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            for (int i = 0; i < data.Length / 2; ++i)
            {
                intSetFirst.Add(data[i]);
            }
            for (int i = data.Length / 2; i < data.Length; ++i)
            {
                intSetSecond.Add(data[i]);
            }
            intSetFirst.UnionWith(intSetSecond);
            var check = new int[] { 5, -32, 0, 16, 13, 56, 44 };
            var output = new int[intSetFirst.Count];
            intSetFirst.CopyTo(output, 0);
            CollectionAssert.AreEqual(check, output);
        }

        [TestMethod]
        public void IntersectWithTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var data = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            for (int i = 0; i < data.Length / 2; ++i)
            {
                intSetFirst.Add(data[i]);
            }
            for (int i = data.Length / 2; i < data.Length; ++i)
            {
                intSetSecond.Add(data[i]);
            }
            intSetFirst.IntersectWith(intSetSecond);
            var check = new int[] { 5, 16 };
            var output = new int[intSetFirst.Count];
            intSetFirst.CopyTo(output, 0);
            CollectionAssert.AreEqual(check, output);
        }

        [TestMethod]
        public void ExceptWithTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var data = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            for (int i = 0; i < data.Length / 2; ++i)
            {
                intSetFirst.Add(data[i]);
            }
            for (int i = data.Length / 2; i < data.Length; ++i)
            {
                intSetSecond.Add(data[i]);
            }
            intSetFirst.ExceptWith(intSetSecond);
            var check = new int[] { -32, 56 };
            var output = new int[intSetFirst.Count];
            intSetFirst.CopyTo(output, 0);
            CollectionAssert.AreEqual(check, output);
        }

        [TestMethod]
        public void SymmetricExceptWithTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var data = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            for (int i = 0; i < data.Length / 2; ++i)
            {
                intSetFirst.Add(data[i]);
            }
            for (int i = data.Length / 2; i < data.Length; ++i)
            {
                intSetSecond.Add(data[i]);
            }
            intSetFirst.SymmetricExceptWith(intSetSecond);
            var check = new int[] { 0, -32, 56, 44, 13 };
            var output = new int[intSetFirst.Count];
            intSetFirst.CopyTo(output, 0);
            CollectionAssert.AreEqual(check, output);
        }

        [TestMethod]
        public void TrueIsSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsTrue(intSetSecond.IsSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void SetIsSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsTrue(intSetSecond.IsSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void FalseIsSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 14, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsFalse(intSetSecond.IsSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void TrueIsProperSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsTrue(intSetSecond.IsProperSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void FalseIsProperSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 14, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsFalse(intSetSecond.IsProperSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void SetIsNotProperSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsFalse(intSetSecond.IsProperSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void EmptyIsSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            Assert.IsTrue(intSetSecond.IsSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void EmptyIsProperSubsetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            Assert.IsTrue(intSetSecond.IsProperSubsetOf(intSetFirst));
        }

        [TestMethod]
        public void TrueIsProperSupersetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsTrue(intSetFirst.IsProperSupersetOf(intSetSecond));
        }

        [TestMethod]
        public void TrueIsSupersetOfTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsTrue(intSetFirst.IsSupersetOf(intSetSecond));
        }

        [TestMethod]
        public void TrueOverlapsTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { 5, 16, 44, 16, 13 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsTrue(intSetFirst.Overlaps(intSetSecond));
        }

        [TestMethod]
        public void FalseOverlapsTest()
        {
            var intSetFirst = new GenericSet<int>();
            var intSetSecond = new GenericSet<int>();
            var firstData = new int[] { 5, 16, -32, 56, 0, 5, 44, 16, 13 };
            var secondData = new int[] { -1, 2, 7, 321, 1315 };
            for (int i = 0; i < firstData.Length; ++i)
            {
                intSetFirst.Add(firstData[i]);
            }
            for (int i = 0; i < secondData.Length; ++i)
            {
                intSetSecond.Add(secondData[i]);
            }
            Assert.IsFalse(intSetFirst.Overlaps(intSetSecond));
        }
    }
}