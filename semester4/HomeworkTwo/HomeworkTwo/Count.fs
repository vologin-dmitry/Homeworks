module Counts

/// Count all even numbers with filter function
let filterCount list =
    List.length <| List.filter (fun x -> x % 2 = 0) list

/// Count all even numbers with map function
let mapCount list =
    List.sum <| List.map (fun x -> abs(x + 1) % 2)  list

/// Count all even numbers with fold functions
let foldCount list =
    List.fold (fun acc x -> (abs(x + 1) % 2) + acc) 0 list