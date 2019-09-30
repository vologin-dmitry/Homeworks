using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Table
{
    [TestClass]
    public class HashTableTest
    {
        private DefaultHashFunction vislualStudioHash = new DefaultHashFunction();
        private MultiplicationHashFunction multHash = new MultiplicationHashFunction();
        private HashTable visualStudioTable;
        private HashTable multTable;


        [TestInitialize]
        public void Initialize()
        {
            visualStudioTable = new HashTable(vislualStudioHash);
            multTable = new HashTable(multHash);
        }

        [TestMethod]
        public void WordExistsDefaultTest()
            => Assert.IsTrue(WordExists(visualStudioTable));

        [TestMethod]
        public void WordExistsMultTest()
            => Assert.IsTrue(WordExists(multTable));

        [TestMethod]
        public void WordDoesNotExistsDefaultTest()
            => Assert.IsFalse(WordDoesNotExists(visualStudioTable));

        [TestMethod]
        public void WordDoesNotExistsMultTest()
            => Assert.IsFalse(WordDoesNotExists(multTable));

        [TestMethod]
        public void NotEmptyDoesNotExistsDefaultTest()
            => Assert.IsFalse(NotEmptyDoesNotExists(visualStudioTable));

        [TestMethod]
        public void NotEmptyDoesNotExistsMultTest()
            => Assert.IsFalse(NotEmptyDoesNotExists(multTable));

        [TestMethod]
        public void AfterDeletionExistsDefaultTest()
            => Assert.IsFalse(AfterDeletionExists(visualStudioTable));

        [TestMethod]
        public void AfterDeletionExistsMultTest()
            => Assert.IsFalse(AfterDeletionExists(multTable));

        [TestMethod]
        public void AllExistsDefaultTest()
            => Assert.IsTrue(AllExists(visualStudioTable));

        [TestMethod]
        public void AllExistsmultTest()
            => Assert.IsTrue(AllExists(multTable));

        [TestMethod]
        public void AfterClearingExistsDefaultTest()
            => Assert.IsFalse(AfterClearingExists(visualStudioTable));

        [TestMethod]
        public void AfterClearingExistsMultTest()
            => Assert.IsFalse(AfterClearingExists(multTable));

        [TestMethod]
        public void DeletionNotAllDefaultTest()
            => Assert.IsTrue(DeletionNotAll(visualStudioTable));

        [TestMethod]
        public void DeletionNotAllMultTest()
            => Assert.IsTrue(DeletionNotAll(multTable));


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
