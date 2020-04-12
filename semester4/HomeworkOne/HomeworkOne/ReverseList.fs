module ReverseList

let listReverse list =
    let rec reverseHelper list reversedList =
        if list = [] then
            reversedList
        else
            reverseHelper (list.Tail) (list.Head :: reversedList)

    reverseHelper list []