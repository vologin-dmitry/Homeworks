module BracketsChecker

open System

let bracketsChecker (str : String) =
    let isNotBracket (ch : Char) =
        ch <> '[' && ch <> '{' && ch <> '(' && ch <> ']' && ch <> '}' && ch <> ')'

    let isOpenBracket (bracket : Char) =
        bracket = '[' || bracket = '{' || bracket = '('

    let isMatchingBrackets (first : Char) (second : Char) =
        match first with
        | '(' -> second = ')'
        | '[' -> second = ']'
        | '{' -> second = '}'
        | _ -> true

    let rec checkLine (str : List<Char>) (memory : List<Char>) =
        if str = []
            then memory = []
        else
            let current = List.head str
            if (isNotBracket current) then
                checkLine (List.tail str) (memory)
            elif (isOpenBracket current) then
                checkLine (List.tail str) (current :: memory)
            elif (memory <> [] && isMatchingBrackets (List.head memory) (current)) then
                checkLine (List.tail str) (List.tail memory)
            else false

    checkLine (Seq.toList str) []