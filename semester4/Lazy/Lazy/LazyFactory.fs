module LazyFactory

open ILazy
open SingleThreadLazy
open LockMultiThreadLazy
open LockFreeLazy

type LazyFactory<'a> =
    static member CreateSingleThreadLazy supplier = SingleThreadLazy<'a>(supplier) :> ILazy<'a>
    static member LockFreeLazy supplier = LockFreeLazy<'a>(supplier) :> ILazy<'a>
    static member LockMultiThreadLazy supplier = LockMultiThreadLazy<'a>(supplier) :> ILazy<'a>