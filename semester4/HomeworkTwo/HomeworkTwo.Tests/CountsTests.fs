module HomeworkTwo.Tests.Counts

open FsUnit
open FsCheck
open Counts
open NUnit.Framework

let inputs =
    [
        [1..10], 5
        [3], 0
        [2], 1
        [2; 4; 6; 8; 10], 5
        [1; 3; 5; 7; 9; 11; 13], 0
        [-1; 0; 1], 1
        [-2], 1
        [-4; -10; 241212], 3
        [], 0
    ] |> List.map (fun (list, result) -> TestCaseData(list, result))

[<TestCaseSource("inputs")>]
[<Test>]
let filterTest list count = filterCount list |> should equal count

[<TestCaseSource("inputs")>]
[<Test>]
let foldTest list count = foldCount list |> should equal count

[<TestCaseSource("inputs")>]
[<Test>]
let mapTest list count = mapCount list |> should equal count

let filterEqualsMap list = filterCount list = mapCount list

let foldEqualsMap list = foldCount list = mapCount list

let filterEqualsFold list = filterCount list = foldCount list

[<Test>]
let ``filter equals map``() = Check.QuickThrowOnFailure filterEqualsMap

[<Test>]
let ``fold equals map``() = Check.QuickThrowOnFailure foldEqualsMap

[<Test>]
let ``filter equals fold``() = Check.QuickThrowOnFailure filterEqualsFold