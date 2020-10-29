module Interpreter

/// Лямбда-терм, бывает трёх видов
type Term =
    | Variable of char
    | Abstraction of char * Term
    | Application of Term * Term

/// Свободна переменная в выражении или нет
let rec isFree expression variable =
    match expression with
    | Variable var -> var = variable
    | Abstraction (var, term) -> var <> variable && isFree term variable
    | Application (left, right) -> isFree left variable || isFree right variable

/// Замена переменной в выражении
let rec substitution oldVariable newVariable expression =
    let vars = [ 'a' .. 'z' ]
    match expression with
    | Variable var when var = oldVariable -> newVariable
    | Variable _ -> expression
    | Abstraction (var, _) when var = oldVariable -> expression
    | Abstraction (var, term) when not <| isFree newVariable var ->
        Abstraction(var, substitution oldVariable newVariable term)
    | Abstraction (var, term) ->
        let newSymbol =
            vars
            |> List.filter (not << isFree newVariable)
            |> List.head

        Abstraction
            (newSymbol,
             substitution oldVariable newVariable
             <| substitution var (Variable newSymbol) term)
    | Application (left, right) ->
        Application(substitution oldVariable newVariable left, substitution oldVariable newVariable right)

/// Бета-редукция выражения
let betaReduction (term: Term) =
    let rec betaReductionRec term =
        match term with
        | Variable var -> Variable(var)
        | Abstraction (var, term) -> Abstraction(var, betaReductionRec <| term)
        | Application (Abstraction (var, leftTerm), rightTerm) ->
            leftTerm
            |> substitution var rightTerm
            |> betaReductionRec
        | Application (left, right) ->
            let leftReduce = betaReductionRec left
            match leftReduce with
            | Abstraction (_) -> Application(leftReduce, right) |> betaReductionRec
            | _ -> Application(leftReduce, betaReductionRec right)

    betaReductionRec term
