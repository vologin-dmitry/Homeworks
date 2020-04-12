module Fibonacci

let fibonacci number =
    let rec fibonacciHelper previous current i =
        if number < 0 then
            None
        else if number = 0 then
            Some(0)
        else if number = i then
            Some(current)
        else
            fibonacciHelper (current) (previous + current) (i + 1)

    (fibonacciHelper 0 1 1).Value