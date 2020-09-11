module Lazy.Tests

open System.Threading
open NUnit.Framework
open FsUnit
open LazyFactory
open ILazy

[<Test>]
let ``simple int single thread lazy test`` () =
    let holder = LazyFactory<int>.CreateSingleThreadLazy <| fun () -> 1
    holder.Get() |> should equal 1

[<Test>]
let ``simple string single thread lazy test`` () =
    let holder = LazyFactory<string>.CreateSingleThreadLazy <| fun () -> "h" + "e" + "l" + "l" + "o"
    holder.Get() |> should equal "hello"

[<Test>]
let ``array single thread lazy test`` () =
    let holder =
        LazyFactory<List<int>>
            .CreateSingleThreadLazy(fun () ->
                                   [ 2; 4; 1; 3; 4; 52; 9; 17; 33; 36 ]
                                   |> List.map (fun x -> x * 1000)
                                   |> List.filter (fun x -> x % 3 = 0))

    holder.Get() |> should equal [ 3000; 9000; 33000; 36000 ]

[<Test>]
let ``called once single thread test`` () =
    let mutable counter = 0
    let holder = LazyFactory<unit>.CreateSingleThreadLazy(fun () -> counter <- counter + 1)
    for i in 1..100 do
        holder.Get()
    counter |> should equal 1

[<Test>]
let ``called once test multi thread with lock`` () =
    let mutable counter = ref 0
    let holder = LazyFactory<int>.LockMultiThreadLazy(fun () -> Interlocked.Increment(counter))
    for i in 1..100 do
        holder.Get() |> ignore
    counter.contents |> should equal 1

[<Test>]
let ``called once test lock free with lock`` () =
    let mutable counter = ref 0
    let holder = LazyFactory<int>.LockFreeLazy(fun () -> Interlocked.Increment(counter))
    for i in 1..100 do
        holder.Get() |> ignore
    counter.contents |> should equal 1

[<Test>]
let ``lot of thread multi thread lock test`` () =
    let holder = LazyFactory<obj>.LockMultiThreadLazy(fun () -> obj())
    let toCompare = holder.Get()
    for i in 1..100500 do
        holder.Get() |> should equal toCompare

[<Test>]
let ``lot of thread lock free test`` () =
    let holder = LazyFactory<obj>.LockFreeLazy(fun () -> obj())
    let toCompare = holder.Get()
    for i in 1..100500 do
        holder.Get() |> should equal toCompare

[<Test>]
let ``simple work lock free test`` () =
    let holder = LazyFactory<int>.LockFreeLazy(fun () -> 1)
    holder.Get() |> should equal 1

[<Test>]
let ``simple work multi thread lock test`` () =
    let holder = LazyFactory<int>.LockMultiThreadLazy(fun () -> 1)
    holder.Get() |> should equal 1

let LazyTestHelper (object : ILazy<'a>, expected) =
    let threadWork () =
        object.Get() |> should equal expected

    let threads = Array.init 10 (fun _ -> Thread(threadWork))

    for thread in threads do
        thread.Start()

    for thread in threads do
        thread.Join()

[<Test>]
let ``multithread lock free lazy`` () =
    LazyTestHelper(LazyFactory<string>.LockFreeLazy(fun _ -> "hello" + " " + "world"), "hello world")

[<Test>]
let ``multithread lock lazy`` () =
    LazyTestHelper(LazyFactory<string>.LockMultiThreadLazy(fun _ -> "hello" + " " + "world"), "hello world")