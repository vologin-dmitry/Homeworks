module RoundWorkflow

open System

/// Workflow witch calculates expression and rounding its result
type RoundResultBuilder(accuracy : int) =
    member this.Bind(x : float, f) =
        Math.Round(x, accuracy) |> f
    member this.Return(x : float) =
        Math.Round(x, accuracy)