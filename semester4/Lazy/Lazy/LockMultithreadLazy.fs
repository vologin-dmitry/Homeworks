module LockMultiThreadLazy

open ILazy

/// Simple lazy class realization for multi thread work
/// based on lock
type LockMultiThreadLazy<'a>(supplier : unit->'a) =
    let mutable result = None
    let locker = obj()
    interface ILazy<'a> with
        /// If Get() called first time, calculates func and returns result,
        /// otherwise, returns already computed function

        member this.Get() =
            match result with
            | Some x -> x
            | None ->
                lock locker <| fun () ->
                    match result with
                    | Some x -> x
                    | None ->
                        result <- Some(supplier())
                        result.Value