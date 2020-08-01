module HomeworkTwo.Tests.ParseTree_Tests

open NUnit.Framework
open FsUnit
open ParseTree

let cases =
    [
        Sum(Digit(100), Digit(32)), 132
        Multiplication(Subtraction(Digit(50), Digit(3)), Digit(2)), 94
        Multiplication(Digit(5000), Digit(0)), 0
        Multiplication(Digit(5000), Digit(-1)), -5000
        Division(Digit(10), Digit(2)), 5
        Subtraction(Multiplication(Digit(13), Digit(5)), Division(Digit(25), Digit(5))), 60
    ] |> List.map (fun (tree, result) -> TestCaseData(tree, result))


[<TestCaseSource("cases")>]
[<Test>]
let ``simple parse tree testes`` tree result = calculateTree tree |> should equal result

[<Test>]
let ``division by zero test`` () =
    (fun () -> calculateTree (Division(Digit(10), Digit(0))) |> ignore) |> should throw typeof<System.DivideByZeroException>