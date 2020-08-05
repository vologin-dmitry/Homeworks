module Seq

/// Checks if number is prime 
let isPrime n =
    if n < 2 then false
    else
        let searchEnd = (float >> sqrt >> int) n
        List.forall (fun x -> n % x <> 0)([2..searchEnd])

/// Creates infinity sequence of prime numbers
let primeSeq = (Seq.initInfinite id |> Seq.filter (isPrime))