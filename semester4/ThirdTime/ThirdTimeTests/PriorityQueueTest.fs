module ThirdTimeTests

open NUnit.Framework
open PriorityQueue

let mutable queue = new PriorityQueue<string>()

[<SetUp>]
let Setup () = queue <- new PriorityQueue<string>()

[<Test>]
let EmptyTest () =
    Assert.True(queue.IsEmpty)

[<Test>]
let OneElementTest () =
    queue.Enqueue 1 "hello"
    Assert.False(queue.IsEmpty)

[<Test>]
let SimpleTest() =
    queue.Enqueue 1 "1"
    queue.Enqueue 2 "2"
    Assert.AreEqual((2, "2"), queue.Dequeue)
    Assert.AreEqual((1, "1"), queue.Dequeue)

[<Test>]
let SimpleIsQueueTest() =
    queue.Enqueue 1 "1"
    queue.Enqueue 1 "2"
    Assert.AreEqual((1, "1"), queue.Dequeue)
    Assert.AreEqual((1, "2"), queue.Dequeue)
