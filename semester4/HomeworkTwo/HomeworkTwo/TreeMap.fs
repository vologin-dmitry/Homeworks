module TreeMap

/// Simple binary tree
type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | None

/// Function that transforms tree with given function
let rec mapTree mapFunc tree =
    match tree with
    | None -> None
    | Node(c, l, r) -> Node(mapFunc c, mapTree mapFunc l, mapTree mapFunc r)