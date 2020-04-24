module TestAttempt2.Tests

open NUnit.Framework
open ThreadSafeQueue

[<Test>]
let QueueEmptyTest () = 
    let queue = new ThreadSafeQueue<int>()
    Assert.True(queue.Empty)

[<Test>]
let QueueNotEmptyTest () = 
    let queue = new ThreadSafeQueue<int>()
    queue.Enqueue(6)
    Assert.False(queue.Empty)

[<Test>]
let QueueRegularTest () = 
    let queue = new ThreadSafeQueue<int>()
    queue.Enqueue(6)
    queue.Enqueue(5)
    Assert.AreEqual(6, queue.Dequeue())
    Assert.AreEqual(5, queue.Dequeue())