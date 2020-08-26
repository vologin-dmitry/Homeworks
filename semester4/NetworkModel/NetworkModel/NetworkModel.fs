module NetworkModel

open ComputerModel

/// Simple model of network based on list of computers and map of its connections
type Network(computers: List<Computer>, netMap: List<List<bool>>) =
    let randomHelper = System.Random()

    /// Do one step
    member this.OneStep =
        List.iter (fun (computer: Computer) -> if computer.JustInfected then computer.JustInfected <- false) computers
        for i in 0 .. computers.Length - 1 do
            if (computers.Item i).Infected
               && (computers.Item i).JustInfected
               |> not then
                for j in 0 .. computers.Length - 1 do
                    if ((computers.Item j).Infected |> not)
                       && ((netMap.Item i).Item j) then
                        if (computers.Item j).InfectPossibility > randomHelper.NextDouble() then
                            (computers.Item j).Infected <- true
                            (computers.Item j).JustInfected <- true

    /// Do some number of steps and sometimes print information about every computer in system
    member this.Start (amountOfSteps: int) (frequencyOfPrinting: int) =
        for i in 1 .. amountOfSteps do
            this.OneStep
            if (frequencyOfPrinting = 0 |> not && i % frequencyOfPrinting = 0) then
                List.iter (fun (x: Computer) -> x.PrintInfo) computers
