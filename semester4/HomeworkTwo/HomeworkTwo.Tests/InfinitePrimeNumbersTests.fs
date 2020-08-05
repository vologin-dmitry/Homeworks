module HomeworkTwo.Tests.InfinitePrimeNumbersTests

open NUnit.Framework
open PrimeSequence
open FsUnit

let cases =
    [
        2, 0
        3, 1
        5, 2
        7, 3
        11, 4
        13, 5
        17, 6
        19, 7
        23, 8
    ] |> List.map (fun (number, pos) -> TestCaseData(number, pos))

[<TestCaseSource("cases")>]
[<Test>]
let infinitePrimesTest number pos =
    Seq.item(pos) primeSeq |> should equal number
