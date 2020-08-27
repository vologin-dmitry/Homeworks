module Workflows.Tests

open NUnit.Framework
open FsUnit
open RoundWorkflow



[<Test>]
let ``zero accuracy test`` () =
    let workflow = RoundResultBuilder(0)
    workflow {
        let! a = 1.0 * 1.5
        let! b = 1.5 * 5.0
        let! c = b / a
        return c
    } |> should equal 4

[<Test>]
let ``one digit accuracy test `` () =
    let workflow = RoundResultBuilder(1)
    workflow {
        let! a = 2.5 * 5.0
        return a
    } |> should equal 12.5

[<Test>]
let ``two digit accuracy test`` () =
    let workflow = RoundResultBuilder(2)
    workflow {
        let! a = 1.5 * 1.5
        let! b = 1.1 * 1.4
        let! c = a / b
        return c
    } |> should equal 1.46

[<Test>]
let ``three digits accuracy test`` () =
    let workflow = RoundResultBuilder(3)
    workflow {
        let! a = 1.5 * 1.5
        let! b = 1.1 * 1.4
        let! c = 1.25 * 2.54
        let! d = 32.3421 / 7.1224
        let! e = a + c * (b / d)
        return e
    } |> should (equalWithin 0.0001) 3.327

[<Test>]
let ``four digits accuracy test`` () =
    let workflow = RoundResultBuilder(4)
    workflow {
        let! a = 1.111 * 1.5
        let! b = 1.1 / 2.345
        let! c = 1.25 + 2.54
        let! d = 32.3421 / 7.1224
        let! e = a * c - (b / d)
        return e
    } |> should (equalWithin 0.00001) 6.2127

[<Test>]
let ``example test`` () =
    let workflow = RoundResultBuilder(3)
    workflow {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } |> should (equalWithin 0.0001) 0.048