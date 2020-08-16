module BracketsChecker

open System

/// Сhecks that the parentheses are correctly placed in the expression
let bracketsChecker (str : String) =
    let isNotBracket (ch : Char) =
        ch <> '[' && ch <> '{' && ch <> '(' && ch <> ']' && ch <> '}' && ch <> ')'

    /// Checks if symbol is a opening bracket
    let isOpenBracket (bracket : Char) =
        bracket = '[' || bracket = '{' || bracket = '('

    /// Checks if symbols are opening and closing brackets of the same type
    let isMatchingBrackets (first : Char) (second : Char) =
        match first with
        | '(' -> second = ')'
        | '[' -> second = ']'
        | '{' -> second = '}'
        | _ -> true

    /// Checks if brackets in line are correct
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