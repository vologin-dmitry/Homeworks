module Queue

///Простая очередь
type Queue<'a>() =
    let mutable list = []

    ///Добавить в элемент
    member this.Enqueue (value : 'a) =
        let reversed = List.rev list
        list <- List.rev (value :: reversed)

    ///Получить первый в очереди элемент
    member this.Dequeue() = 
        match list.Length with
        | 0 -> raise (System.IndexOutOfRangeException("Queue is empty!"))
        | _ -> let head = list.Head
               list <- list.Tail
               head 

    ///Узнать количество элементов в очереди
    member this.Length() = list.Length
    
    ///Узнать является ли очередь пустой
    member this.IsEmpty = list.IsEmpty