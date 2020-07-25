module Factorial.Tests

open System
open FsUnit
open NUnit.Framework
open Factorial

[<Test>]
let ``factorial of negative numbers``() =
    (fun() -> factorial -1 |> ignore) |> should throw typeof<ArgumentException>
    (fun() -> factorial -10 |> ignore) |> should throw typeof<ArgumentException>
    (fun() -> factorial -1242141 |> ignore) |> should throw typeof<ArgumentException>
    
[<Test>]
let ``factorial of positive numbers and zero`` () =
    factorial 3 |> should equal 6
    factorial 0 |> should equal 1
    factorial 1 |> should equal 1
    factorial 5 |> should equal 120
    factorial 10 |> should equal 3628800