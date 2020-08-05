module HomeworkTwo.Tests.TreeMap

open NUnit.Framework
open FsUnit
open TreeMap

let intTree = (Node(5, Node(3, None, None), Node(0, Node(313, Tree.None, Tree.None), Tree.None)))
let intAnswer = (Node(10, Node(6, None, None), Node(0, Node(626, Tree.None, Tree.None), Tree.None)))

[<Test>]
let intTest () = mapTree (fun (x: int) -> (x * 2)) intTree |> should equal intAnswer

let stringTree = (Node("Hello", Node("World", Node("Another", Node("Word", Tree.None, Tree.None), Tree.None), Tree.None), Tree.None))
let stringAnswer = (Node("Helloa", Node("Worlda", Node("Anothera", Node("Worda", Tree.None, Tree.None), Tree.None), Tree.None), Tree.None))

[<Test>]
let stringTest () = mapTree (fun (x: string) -> x + "a") stringTree |> should equal stringAnswer