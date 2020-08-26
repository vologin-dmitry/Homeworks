module ComputerModel

type Computer(name: string, os: string) =

    member this.Name = name
    member this.Os = os
    member val Infected = false with get, set
    member val JustInfected = false with get, set

    member this.InfectPossibility =
        match os with
        | "Windows" -> 1.0
        | "MacOS" -> 0.5
        | "Linux" -> 0.25
        | _ -> 0.0

    member this.PrintInfo =
        let getInfectedWord =
            match this.Infected, this.JustInfected with
            | false, _ -> "not"
            | _, true -> "just"
            | _ -> ""

        printfn "Computer %s running on %s is %s infected" this.Name this.Os getInfectedWord
