module InterpreterTests

open NUnit.Framework
open FsUnit
open Interpreter

[<Test>]
let ``simple variable test`` () =
    Variable('x')
    |> betaReduction
    |> should equal (Variable('x'))

[<Test>]
let ``simple abstraction test`` () =
    Abstraction('x', Variable('x'))
    |> betaReduction
    |> should equal (Abstraction('x', Variable('x')))

[<Test>]
let ``simple application test`` () =
    Application(Variable('x'), Variable('y'))
    |> betaReduction
    |> should equal (Application(Variable('x'), Variable('y')))

// (λx.x y)
[<Test>]
let ``simple test`` () =
    Application(Abstraction('x', Variable('x')), Variable('y'))
    |> betaReduction
    |> should equal (Variable('y'))

// λx.(x y) z
[<Test>]
let ``simple test two`` () =
    Application(Abstraction('x', Application(Variable('x'), Variable('y'))), Variable('z'))
    |> betaReduction
    |> should equal (Application(Variable('z'), Variable('y')))

// (λx.y z) (λa.(a z) b)
[<Test>]
let ``simple test three`` () =
    Application(Application(Abstraction('x', Variable('y')), Variable('z')), Application(Abstraction('a', Application(Variable('a'), Variable('z'))), Variable('b')))
    |> betaReduction
    |> should equal (Application(Variable('y'), Application(Variable('b'), Variable('z'))))