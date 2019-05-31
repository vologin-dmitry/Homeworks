using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archiver;

namespace ArchiverTest
{
    [TestClass]
    public class ArchiverTest
    {
        byte[] input;
        byte[] answer;
        byte[] output;

        [TestMethod]
        public void SimpleEncoderTest()
        {
            input = new byte[] { 1, 1, 1, 4, 5, 8, 4, 4, 4, 4, 4 };
            answer = new byte[] { 3, 1, 1, 4, 1, 5, 1, 8, 5, 4 };
            var output = Archiver.Archiver.Archive(input);
            Assert.AreEqual(answer.Length, output.Length);
            for (int i = 0; i < output.Length; ++i)
            {
                Assert.AreEqual(answer[i], output[i]);
            }
        }

        [TestMethod]
        public void SimpleDecoderTest()
        {
            input = new byte[] { 3, 1, 1, 4, 1, 5, 1, 8, 5, 4 };
            answer = new byte[] { 1, 1, 1, 4, 5, 8, 4, 4, 4, 4, 4 };
            output = Archiver.Archiver.Unarchive(input);
            Assert.AreEqual(answer.Length, output.Length);
            for (int i = 0; i < output.Length; ++i)
            {
                Assert.AreEqual(answer[i], output[i]);
            }
        }

        [TestMethod]
        public void VeryBighInputEncoderTest()
        {
            input = new byte[500];
            for (int i = 0; i < 500; ++i)
            {
                input[i] = 1;
            }
            answer = new byte[] { 255, 1, 245, 1 };
            output = Archiver.Archiver.Archive(input);
            Assert.AreEqual(answer.Length, output.Length);
            for (int i = 0; i < output.Length; ++i)
            {
                Assert.AreEqual(answer[i], output[i]);
            }
        }

        [TestMethod]
        public void VeryBighInputDecoderTest()
        {
            answer = new byte[500];
            for (int i = 0; i < 500; ++i)
            {
                answer[i] = 1;
            }
            input = new byte[] { 255, 1, 245, 1 };
            output = Archiver.Archiver.Unarchive(input);
            Assert.AreEqual(answer.Length, output.Length);
            for (int i = 0; i < output.Length; ++i)
            {
                Assert.AreEqual(answer[i], output[i]);
            }
        }
    }
}
