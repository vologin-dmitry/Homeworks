module Reverse.Tests

open NUnit.Framework
open ReverseList

[<Test>]
let reverseTest () =
    Assert.AreEqual([], listReverse [])
    Assert.AreEqual([4], listReverse [4])
    Assert.AreEqual([5; 4], listReverse [4; 5])
    Assert.AreEqual([6; 6], listReverse [6; 6])
    Assert.AreEqual([1;2;3;4;5;6], listReverse [6;5;4;3;2;1])