module FirstMatch

let firstMatch list toFind =
    let rec firstMatchHelper list position =
        if list = [] then
            None
        else if List.head list = toFind then
            Some(position)
        else
            firstMatchHelper(List.tail list)(position + 1)
    firstMatchHelper list 0