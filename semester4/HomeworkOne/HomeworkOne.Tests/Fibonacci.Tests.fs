module Fibonacci.Tests

open NUnit.Framework
open Fibonacci

[<Test>]
let fibonacciTest () =
    Assert.AreEqual(2, fibonacci 3)
    Assert.AreEqual(0, fibonacci 0)
    Assert.AreEqual(1, fibonacci 1)
    Assert.AreEqual(5, fibonacci 5)
    Assert.AreEqual(55, fibonacci 10)