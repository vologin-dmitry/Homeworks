module StringWorkflowTests

open NUnit.Framework
open FsUnit
open StringWorkflow

let workflow = StringBuilder()

[<Test>]
let ``simple plus test`` () =
    workflow {
        let! a = "5"
        let! b = "2"
        let c = a + b
        return c
    } |> should equal (Some(7))

[<Test>]
let ``simple multiply test`` ()=
    workflow {
        let! a = "3"
        let! b = "15"
        let c = b * a
        return c
    } |> should equal (Some(45))

[<Test>]
let ``simple test`` () =
    workflow {
        let! a = "3"
        let! b = "15"
        let! c = "2"
        let d = c * b
        let e = d / a
        return e
    } |> should equal (Some(10))

[<Test>]
let ``simple subtraction test`` () =
    workflow {
        let! a = "3"
        let! b = "15"
        let c = b - a
        return c
    } |> should equal (Some(12))

[<Test>]
let ``simple division test`` () =
    workflow {
        let! a = "3"
        let! b = "15"
        let c = b / a
        return c
    } |> should equal (Some(5))

[<Test>]
let ``one word test`` () =
    workflow {
        let! a = "3"
        let! b = "isword"
        let c = a + b
        return c
    } |> should equal None

[<Test>]
let ``two words test`` () =
    workflow {
        let! a = "mmhmhmh"
        let! b = "isword"
        let c = a / b
        return c
    } |> should equal None