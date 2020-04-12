module ListOfPows

open ReverseList

let listOfPows n m =
    let rec listOfPowsHelper list i currentPower =
        if i < 0 then
            []
        else if i > m then
            list
        else
            listOfPowsHelper ((currentPower) :: list) (i + 1) (currentPower * 2)
    listReverse (listOfPowsHelper [] n (pown 2 n))