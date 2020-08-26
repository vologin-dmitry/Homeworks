module ComputerModel

/// Simple model of computer
type Computer(name: string, os: string) =

    /// Name of computer
    member this.Name = name

    /// OS of computer
    member this.Os = os

    /// If this computer is infected by virus
    member val Infected = false with get, set

    /// If this computer was infected in current turn
    member val JustInfected = false with get, set

    /// Determines infection-defend by OS of computer
    member this.InfectPossibility =
        match os with
        | "Windows" -> 1.0
        | "MacOS" -> 0.5
        | "Linux" -> 0.25
        | _ -> 0.0

    /// Prints information about current computer
    member this.PrintInfo =
        let getInfectedWord =
            match this.Infected, this.JustInfected with
            | false, _ -> "not"
            | _, true -> "just"
            | _ -> ""

        printfn "Computer %s running on %s is %s infected" this.Name this.Os getInfectedWord
