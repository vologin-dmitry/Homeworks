module Draw

/// Create List<string> that contains wanted picture
let getBoxList (n: int) =

    /// Returns lines
    let rec otherLines current line =
        if current = n then
            otherLines (current - 1) "*"
        else if (current = 1) then
            "*" + line
        else
            otherLines (current - 1) " "

    /// Returns upper and bottom lines
    let rec firstAndLastLine pos line =
        if pos > 0 then firstAndLastLine (pos - 1) (line + "*")
        else line

    /// Creates List of strings we need
    let rec getList linePos (list: List<string>) =
        match linePos with
        | number when number < 1 -> printfn "%s" "ERROR!!"
                                    []
        | 1 -> (list @ [firstAndLastLine n ""])
        | a when a = n -> getList (linePos - 1) [(firstAndLastLine n "")]
        | _ -> getList (linePos - 1) (list @ [otherLines n ""])
    
    getList n []

/// Prints our list
let rec printPicture (list: List<string>) =
    match list.Length with 
    | 0 -> printfn ""
    | 1 -> printfn "%s" list.Head
    | _ -> printfn "%s" list.Head
           printPicture list.Tail