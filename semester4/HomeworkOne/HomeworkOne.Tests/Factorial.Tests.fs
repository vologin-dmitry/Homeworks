module Factorial.Tests

open NUnit.Framework
open Factorial

(*[<Test>]
let factorialNegativestTest () =
    Assert.Throws<System.NullReferenceException>(factorial -100)
    Assert.AreEqual(factorial -100, None)
    Assert.AreEqual(factorial -1, None)
    Assert.AreEqual(factorial -1024124, None)*)

[<Test>]
let factorialPositivesAndZeroTest () =
    Assert.AreEqual(6, factorial 3)
    Assert.AreEqual(1, factorial 0)
    Assert.AreEqual(1, factorial 1)
    Assert.AreEqual(120, factorial 5)
    Assert.AreEqual(3628800, factorial 10)