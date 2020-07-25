module Factorial

let factorial number = 
    let rec factorialHelper i acc = 
        if number < 0 then
            invalidArg ("number") ("Negative numbers are not supported!")
        else if number = 0 then
            Some(1)
        else if (number = i) then
            Some(acc * number)
        else
            factorialHelper (i + 1) (acc * i)

    (factorialHelper 1 1).Value