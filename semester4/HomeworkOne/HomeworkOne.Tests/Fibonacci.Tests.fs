module Fibonacci.Tests

open NUnit.Framework
open FsUnit
open Fibonacci
open System

[<Test>]
let ``fibonacci with negative numbers`` () =
    (fun() -> fibonacci -1 |> ignore) |> should throw typeof<ArgumentException>
    (fun() -> fibonacci -10 |> ignore) |> should throw typeof<ArgumentException>
    (fun() -> fibonacci -1242141 |> ignore) |> should throw typeof<ArgumentException>

[<Test>]
let ``fibonacci with positive numbers`` () =
    fibonacci 3 |> should equal 2
    fibonacci 0 |> should equal 0
    fibonacci 1 |> should equal 1
    fibonacci 5 |> should equal 5
    fibonacci 10 |> should equal 55