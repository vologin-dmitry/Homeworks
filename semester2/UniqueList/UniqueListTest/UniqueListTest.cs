using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniqueList;

namespace UniqueList
{
    [TestClass]
    public class UniqueListTest
    {
        UniqueList list;
        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        [ExpectedException(typeof(AddingExistingElementException))]
        public void AddExistingElement()
        {
            list.Add("hello", 1);
            list.Add("hello", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(AddingExistingElementException))]
        public void AddNotOneExistingElement()
        {
            list.Add("wow", 1);
            list.Add("hello", 2);
            list.Add("wow", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DeletionOfNotExistingElement))]
        public void DeleteFirstExistingElement()
        {
            list.Delete(1);
        }

        [TestMethod]
        [ExpectedException(typeof(DeletionOfNotExistingElement))]
        public void DeleteNegativeExistingElement()
        {
            list.Delete(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(DeletionOfNotExistingElement))]
        public void DeletePositiveExistingElement()
        {
            list.Delete(8);
        }

        [TestMethod]
        [ExpectedException(typeof(DeletionOfNotExistingElement))]
        public void DoubleDeletion()
        {
            list.Add("first", 1);
            list.Delete(1);
            list.Delete(1);
        }

        [TestMethod]
        [ExpectedException(typeof(AddingExistingElementException))]
        public void ChangingToExisting()
        {
            list.Add("first", 1);
            list.Add("second", 2);
            list.SetDataOn("first", 2);
        }

        [TestMethod]
        public void NoExceptionOnDifferentValues()
        {
            list.Add("first", 1);
            list.Add("second", 2);
            Assert.AreEqual(list.GetDataOn(1), "first");
            Assert.AreEqual(list.GetDataOn(2), "second");
        }

        [TestMethod]
        public void NoExceptionWhenChangingOk()
        {
            list.Add("first", 1);
            list.Add("second", 2);
            list.SetDataOn("First", 2);
            Assert.AreEqual(list.GetDataOn(1), "first");
            Assert.AreEqual(list.GetDataOn(2), "First");
        }

        [TestMethod]
        public void NormalDeletion()
        {
            list.Add("first", 1);
            list.Add("second", 2);
            list.Delete(1);
            Assert.AreEqual(list.GetDataOn(1), "second");
        }
    }
}