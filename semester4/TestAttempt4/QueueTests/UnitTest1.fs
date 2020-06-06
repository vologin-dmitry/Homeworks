module ThirdTimeTests

open NUnit.Framework
open Queue
open FsUnit

let mutable queue = new Queue<string>()

[<SetUp>]
let Setup () = queue <- new Queue<string>()

[<Test>]
let EmptyTest () =
    Assert.True(queue.IsEmpty)

[<Test>]
let OneElementTest () =
    queue.Enqueue "hello"
    Assert.False(queue.IsEmpty)

[<Test>]
let SimpleTest() =
    queue.Enqueue "1"
    queue.Enqueue "2"
    Assert.AreEqual("1", queue.Dequeue())
    Assert.AreEqual("2", queue.Dequeue())

[<Test>]
let ExceptionTest () = Assert.Throws<System.IndexOutOfRangeException>((fun () -> queue.Dequeue() |>ignore)) |> ignore