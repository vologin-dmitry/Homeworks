module ListOfPows.Tests

open NUnit.Framework
open ListOfPows

[<Test>]
let listOfPowsTest () =
    Assert.AreEqual([], listOfPows 2 1)
    Assert.AreEqual([2], listOfPows 1 1)
    Assert.AreEqual([], listOfPows -2 -1)
    Assert.AreEqual([1; 2; 4], listOfPows 0 2)
    Assert.AreEqual([16; 32; 64; 128; 256; 512; 1024; 2048; 4096], listOfPows 4 12)