module TestProject1

open NUnit.Framework
open FsCheck
open PointFree

let ``example and first are equal`` number list = mapMultiply number list = mapMultiply1 number list
let ``first and second are equal`` number list = mapMultiply1 number list = mapMultiply2 number list
let ``second and third are equal`` number list = mapMultiply2 number list = mapMultiply3 number list
let ``third and fourth are equal`` number list = mapMultiply3 number list = mapMultiply4 number list

[<Test>]
let test1 () =  Check.QuickThrowOnFailure ``example and first are equal``

[<Test>]
let test2 () =  Check.QuickThrowOnFailure ``first and second are equal`` 

[<Test>]
let test3 () =  Check.QuickThrowOnFailure ``second and third are equal``

[<Test>]
let test4 () =  Check.QuickThrowOnFailure ``third and fourth are equal``