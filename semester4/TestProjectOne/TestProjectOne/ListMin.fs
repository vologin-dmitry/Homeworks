module ListMin

let getLess a b = if a < b then a else b

let getListMin list = List.fold (getLess) (List.head list) (list)