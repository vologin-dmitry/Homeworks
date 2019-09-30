using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H8_T1.Test
{
    [TestClass]
    public class ListOnGenericsTest
    {

        [TestMethod]
        public void AddTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            list.Add(15);
            Assert.AreEqual(32, list[0]);
            Assert.AreEqual(15, list[1]);
        }

        [TestMethod]
        public void SizeTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void SizeForTwoTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            list.Add(0);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void IndexAccessTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            Assert.AreEqual(32, list[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexAccessExceptionTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            var temp = list[2];
        }

        [TestMethod]
        public void IndexAccessForTwoTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            list.Add(8);
            Assert.AreEqual(32, list[0]);
            Assert.AreEqual(8, list[1]);
        }

        [TestMethod]
        public void IndexOfTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            Assert.AreEqual(0, list.IndexOf(32));
        }

        [TestMethod]
        public void IndexOfForTwoTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            list.Add(8);
            Assert.AreEqual(0, list.IndexOf(32));
            Assert.AreEqual(1, list.IndexOf(8));
        }

        [TestMethod]
        public void WrongIndexOfTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            list.Add(8);
            Assert.AreEqual(-1, list.IndexOf(0));
        }

        [TestMethod]
        public void InsertForOneElementTest()
        {
            var list = new ListOnGenerics<int>();
            list.Insert(0, 32);
            Assert.AreEqual(32, list[0]);
        }

        [TestMethod]
        public void InsertForSeveralElementTest()
        {
            var list = new ListOnGenerics<int>();
            list.Insert(0, 32);
            list.Insert(1, 48);
            list.Insert(1, 5);
            Assert.AreEqual(32, list[0]);
            Assert.AreEqual(5, list[1]);
            Assert.AreEqual(48, list[2]);
        }

        [TestMethod]
        public void RemoveAtForOneElementTest()
        {
            var list = new ListOnGenerics<int>();
            list.Add(32);
            list.RemoveAt(0);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveAtForSeveralElementsTest()
        {
            var list = new ListOnGenerics<int>();
            list.Insert(0, 32);
            list.Insert(1, 48);
            list.Insert(1, 5);
            list.RemoveAt(1);
            Assert.AreEqual(48, list[1]);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            var list = new ListOnGenerics<string>();
            list.Add("e");
            list.Add("q");
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ContainsTrueTest()
        {
            var list = new ListOnGenerics<string>();
            list.Add("e");
            list.Add("q");
            Assert.AreEqual(true, list.Contains("e"));
        }

        [TestMethod]
        public void ContainsFalseTest()
        {
            var list = new ListOnGenerics<string>();
            list.Add("e");
            list.Add("q");
            Assert.AreEqual(false, list.Contains("r"));
        }

        [TestMethod]
        public void CopyToTest()
        {
            var list = new ListOnGenerics<string>();
            list.Add("e");
            list.Add("q");
            var copied = new string[2];
            list.CopyTo(copied, 0);
            var check = new string[]{ "e", "q" };
            for (int i = 0; i < 2; ++i)
            {
                Assert.AreEqual(check[i], list[i]);
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            var list = new ListOnGenerics<char>();
            list.Add('e');
            list.Add('q');
            list.Remove('e');
            Assert.AreEqual(false, list.Contains('e'));
        }

        [TestMethod]
        public void RemoveNonexistenentElementTest()
        {
            var list = new ListOnGenerics<char>();
            list.Add('e');
            list.Add('q');
            Assert.AreEqual(false, list.Remove('f'));
        }

        [TestMethod]
        public void ForEachTest()
        {
            var list = new ListOnGenerics<char>();
            list.Add('e');
            list.Add('a');
            list.Add('r');
            var answer = "ear";
            var i = 0;
            foreach (var element in list)
            {
                Assert.AreEqual(answer[i], element);
                ++i;
            }
        }
    }
}