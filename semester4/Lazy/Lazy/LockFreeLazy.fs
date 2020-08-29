module LockFreeLazy

open ILazy
open System.Threading

/// Simple lazy class realization for multi thread work
/// without locks
type LockFreeLazy<'a>(supplier : unit -> 'a) =
    let mutable desiredResult = None
    let mutable startResult = None
    let mutable computed = false
    interface ILazy<'a> with

        /// If Get() called first time, calculates func and returns result,
        /// otherwise, returns already computed function
        member this.Get() =
            if not computed then
                desiredResult <- Some(supplier())
                Interlocked.CompareExchange(ref startResult, desiredResult, None) |> ignore
                computed <- true
            desiredResult.Value