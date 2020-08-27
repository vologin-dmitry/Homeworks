module StringWorkflow

open System

/// Workflow witch calculates expression with string numbers
type StringBuilder() =
    member this.Bind(x : string, f) =
        match Int32.TryParse(x) with
        | true, number -> number |> f
        | _ -> None
    member this.Return(x) =
        Some(x)