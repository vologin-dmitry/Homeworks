module GetListMinimal.Test

open NUnit.Framework
open ListMin

[<Test>]
let listMinTest =
    Assert.AreEqual(32, getListMin [32;2141;4215;123])
    Assert.AreEqual(0, getListMin [32;0;4215;123])
    Assert.AreEqual(-5, getListMin [-1;-2;-3;-4;-5])
    Assert.AreEqual(-1, getListMin [-1;-1;-1;-1;-1])
    