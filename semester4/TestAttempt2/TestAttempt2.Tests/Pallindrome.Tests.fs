module Pallindrome.Tests

open NUnit.Framework
open MaxPallindrome

[<Test>]
let MaxPalindromeTest () =
    Assert.AreEqual(906609, getMaxPallindromeOfThreeDigits())
