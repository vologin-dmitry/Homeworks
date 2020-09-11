module ILazy

/// Interface that describes lazy computations
type ILazy<'a> =
    /// If Get() called first time, calculates func and returns result,
    /// otherwise, returns already computed function
    abstract member Get: unit -> 'a