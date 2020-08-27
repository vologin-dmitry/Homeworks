module ComputerModel

/// Model of operational system of computer
type OS =
    | Windows
    | Linux
    | MacOS
    
    /// Infection probability of computer with this OS
    member this.GetInfectProbability =
        match this with
        | Windows -> 1.0
        | MacOS -> 0.5
        | Linux -> 0.0

    /// Returns name of system in string format
    member this.GetSystemName =
        match this with
        | Windows -> "Windows"
        | MacOS -> "MacOS"
        | Linux -> "Linux"

/// Simple model of computer
type Computer(name: string, os: OS) =

    let mutable infected = false
    let mutable justInfected = false

    /// If this computer is infected
    member this.Infected = infected


    /// If this computer was infected in current turn
    member this.JustInfected = justInfected

    /// Name of computer
    member this.Name = name

    /// OS of computer
    member this.Os = os

    /// If this computer could be infected now
    member this.CanInfect = infected && (justInfected |> not)

    /// Infect computer
    member this.Infect () =
        infected <- true
        justInfected <- true

    /// Sets JustInfected parameter to false
    member this.ClearJustInfectedStatus () =
        if justInfected then justInfected <- false

    /// Prints information about current computer
    member this.PrintInfo () =
        let getInfectedWord =
            match infected, justInfected with
            | false, _ -> "not"
            | _, true -> "just"
            | _ -> ""

        printfn "Computer %s running on %s is %s infected" this.Name os.GetSystemName getInfectedWord
