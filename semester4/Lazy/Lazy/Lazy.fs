module SingleThreadLazy

open ILazy

/// Simple lazy class realization for single thread work
type SingleThreadLazy<'a>(supplier : unit -> 'a) =
    let mutable result = None
    interface ILazy<'a> with

        /// If Get() called first time, calculates func and returns result,
        /// otherwise, returns already computed function
        member this.Get() =
            match result with
            | Some x -> x
            | None ->
                result <- Some(supplier())
                result.Value