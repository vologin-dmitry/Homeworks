module FirstMatch.Tests

open NUnit.Framework
open FirstMatch

[<Test>]
let firstMatchTest () =
    Assert.AreEqual(None, firstMatch [] 1)
    Assert.AreEqual(None, firstMatch [0; 24; 532] 1)
    Assert.AreEqual(Some(0), firstMatch [0; 24; 532] 0)
    Assert.AreEqual(Some(4), firstMatch [0; 24; 532; 2121; 1512] 1512)
    Assert.AreEqual(Some(2), firstMatch [0; 24; 532; 2121; 1512] 532)
    Assert.AreEqual(None, firstMatch ['a'; 'b'; 'c'; 'd'; 'e'; 'f'] 'g')
    Assert.AreEqual(Some(3), firstMatch ['a'; 'b'; 'c'; 'd'; 'e'; 'f'] 'd')
