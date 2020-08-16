module TestProject1


open NUnit.Framework
open FsUnit
open BracketsChecker

let cases = 
    [
        "()", true
        "[]", true
        "{}", true
        "", true
        "1", true
        ")(", false
        "(]", false
        "([{[]}])", true
        "[])", false
        "[[]]", true
        "[1]", true
        "([)]", false
        "(123)", true
        "]", false
        "(", false
        "(1)", true
        "[453]", true
        "[23}", false
    ] |> List.map (fun (string, result) -> TestCaseData(string, result))

[<Test>]
[<TestCaseSource("cases")>]
let bracketsTest str res =
    bracketsChecker str |> should equal res