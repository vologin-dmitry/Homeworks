module LazyFactory

open ILazy
open SingleThreadLazy
open LockMultiThreadLazy
open LockFreeLazy

/// Creates lazy classes of various types
type LazyFactory<'a> =
    /// Creates single thread lazy object
    static member CreateSingleThreadLazy supplier = SingleThreadLazy<'a>(supplier) :> ILazy<'a>

    /// Creates multithread lazy object that works without locks
    static member LockFreeLazy supplier = LockFreeLazy<'a>(supplier) :> ILazy<'a>

    /// Creates simple multithread lazy based on locks
    static member LockMultiThreadLazy supplier = LockMultiThreadLazy<'a>(supplier) :> ILazy<'a>