module PointFree

///Takes list and number and multiplies every element of list to a number
let mapMultiply x l = List.map (fun y -> y * x) l

let mapMultiply1 (x: int): int list -> int list = List.map (fun y -> y * x)

let mapMultiply2 (x: int): int list -> int list = List.map (fun y -> (*) x y)

let mapMultiply3 (x: int): int list -> int list = x |> (*) |> List.map

let mapMultiply4: int -> int list -> int list = List.map << (*)