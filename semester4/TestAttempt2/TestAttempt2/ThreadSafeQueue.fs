module ThreadSafeQueue

type ThreadSafeQueue<'T>() =    
    let mutable queue : List<'T> = []

    ///Возращает первый элемент, не забирая его из очереди
    member this.Head = 
        let rec headHelper () =
            match queue with
            | value :: _->
               value
            |[] -> headHelper()

        lock queue (fun () ->
            headHelper()
         )

    /// Добавляет элемент в очередь
    member this.Enqueue value =
      lock queue (fun () -> 
         queue <- queue @ [value] )

    ///Забирает элемент из очереди
    member this.Dequeue() =
        let rec dequeueHelper () =
            match queue with
            | value :: newQueue->
               queue <- newQueue
               value
            |[] -> dequeueHelper()

        lock queue (fun () ->
         dequeueHelper()
      )

    /// Пустая ли очередь
    member this.Empty = queue.IsEmpty