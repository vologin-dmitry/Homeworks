module PriorityQueue

///Очередь, где чем больше приоритет итема, тем ближе к голове списка
type PriorityQueue<'a>() =
    let mutable list = []

    ///Добавить определенный элемент с определенным приоритетом
    member this.Enqueue prior (value : 'a) =
        let rec enqueueHelper prev fol =
            match fol with
            | (insidePriority, insideValue) :: tail -> if insidePriority < prior
                                                         then prev @ [(prior, value)] @ fol
                                                         else enqueueHelper (prev @ [(prior, value)]) fol
            | [] -> prev @ [(prior, value)]
        
        match list.Head with
            | (hPrior, hValue) when hPrior < prior -> [(prior, value)] @ list
            | _ -> enqueueHelper [] list

    ///Получить элемент с низшим приоритетом
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