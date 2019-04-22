using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Table
{
    [TestClass]
    public class UnitTest1
    {
        DefaultHashFunction VSHash = new DefaultHashFunction();
        MultiplicationHashFunction MultHash = new MultiplicationHashFunction();
        HashTable VSTable;
        HashTable MultTable;


        [TestInitialize]
        public void Initialize()
        {
            VSTable = new HashTable(VSHash);
            MultTable = new HashTable(MultHash);
        }

        [TestMethod]
        public void WordExistsDefaultTest()
            => Assert.IsTrue(WordExists(VSTable));

        [TestMethod]
        public void WordExistsMultTest()
            => Assert.IsTrue(WordExists(MultTable));

        [TestMethod]
        public void WordDoesNotExistsDefaultTest()
            => Assert.IsFalse(WordDoesNotExists(VSTable));

        [TestMethod]
        public void WordDoesNotExistsMultTest()
            => Assert.IsFalse(WordDoesNotExists(MultTable));

        [TestMethod]
        public void NotEmptyDoesNotExistsDefaultTest()
            => Assert.IsFalse(NotEmptyDoesNotExists(VSTable));

        [TestMethod]
        public void NotEmptyDoesNotExistsMultTest()
            => Assert.IsFalse(NotEmptyDoesNotExists(MultTable));

        [TestMethod]
        public void AfterDeletionExistsDefaultTest()
            => Assert.IsFalse(AfterDeletionExists(VSTable));

        [TestMethod]
        public void AfterDeletionExistsMultTest()
            => Assert.IsFalse(AfterDeletionExists(MultTable));

        [TestMethod]
        public void AllExistsDefaultTest()
            => Assert.IsTrue(AllExists(VSTable));

        [TestMethod]
        public void AllExistsmultTest()
            => Assert.IsTrue(AllExists(MultTable));

        [TestMethod]
        public void AfterClearingExistsDefaultTest()
            => Assert.IsFalse(AfterClearingExists(VSTable));

        [TestMethod]
        public void AfterClearingExistsMultTest()
            => Assert.IsFalse(AfterClearingExists(MultTable));

        [TestMethod]
        public void DeletionNotAllDefaultTest()
            => Assert.IsTrue(DeletionNotAll(VSTable));

        [TestMethod]
        public void DeletionNotAllMultTest()
            => Assert.IsTrue(DeletionNotAll(MultTable));


        private bool WordExists(HashTable table)
        {
            table.Add("Hello");
            return (table.Exists("Hello"));
        }

        private bool WordDoesNotExists(HashTable table)
            => table.Exists("Hello");

        private bool NotEmptyDoesNotExists(HashTable table)
        {
            table.Add("Hello");
            return (table.Exists("hello"));
        }

        private bool AfterDeletionExists(HashTable table)
        {
            table.Add("Hello");
            table.Delete("Hello");
            return (table.Exists("Hello"));
        }
        
        private bool AllExists(HashTable table)
        {
            table.Add("one");
            table.Add("two");
            return (table.Exists("one") && table.Exists("two"));
        }

        private bool AfterClearingExists(HashTable table)
        {
            table.Add("one");
            table.Add("two");
            table.Clear();
            return (table.Exists("one") || table.Exists("two"));
        }

        private bool DeletionNotAll(HashTable table)
        {
            table.Add("one");
            table.Add("two");
            table.Delete("one");
            return (table.Exists("two"));
        }
    }
}
