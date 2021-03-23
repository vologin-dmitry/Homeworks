module NetworkModel

open ComputerModel

/// Simple model of network based on list of computers and map of its connections
type Network(computers: List<Computer>, netMap: List<List<bool>>) =
    let randomHelper = System.Random()

    /// Do one step
    member this.OneStep =
        List.iter (fun (computer: Computer) -> computer.ClearJustInfectedStatus()) computers

        for i in 0 .. computers.Length - 1 do
            if (computers.Item i).CanInfect then
                for j in 0 .. computers.Length - 1 do
                    if ((computers.Item j).Infected |> not) && ((netMap.Item i).Item j) then
                        if (computers.Item j).Os.GetInfectProbability > randomHelper.NextDouble() then
                            (computers.Item j).Infect()

    /// Do some number of steps and sometimes print information about every computer in system
    member this.Start (amountOfSteps: int) (frequencyOfPrinting: int) =
        for i in 1 .. amountOfSteps do
            this.OneStep
            if (frequencyOfPrinting = 0 |> not && i % frequencyOfPrinting = 0) then
                List.iter (fun (x: Computer) -> x.PrintInfo()) computers
