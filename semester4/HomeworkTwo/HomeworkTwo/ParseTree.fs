module ParseTree

/// Simple parse tree
type ParseTree =
    | Digit of int
    | Sum of ParseTree * ParseTree
    | Subtraction of ParseTree * ParseTree
    | Multiplication of ParseTree * ParseTree
    | Division of ParseTree * ParseTree

/// Function that calculates the result of parse tree
 let rec calculateTree tree =
    match tree with
    | Digit x -> x
    | Sum(l, r) -> calculateTree l + calculateTree r
    | Subtraction(l, r) -> calculateTree l - calculateTree r
    | Multiplication(l, r) -> calculateTree l * calculateTree r
    | Division(l, r) -> let right = calculateTree r
                        if right = 0 then raise (System.DivideByZeroException())
                        else (calculateTree l) / right