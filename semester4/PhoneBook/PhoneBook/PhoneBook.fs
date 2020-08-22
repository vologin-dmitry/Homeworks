module PhoneBook

open System
open System.IO

/// Simple phonebook with names and phone numbers
type PhoneBook =

    /// Add new record
    static member Add name number seq =
        if not <| Seq.contains (name, number) seq  then
            Seq.append seq [(name, number)] 
        else seq

    /// Get name of person by its telephone number
    static member GetName number seq =
        Seq.filter(fun x -> snd x = number) seq

    /// Get telephone number of person by its name
    static member GetNumber name seq =
        Seq.filter(fun x -> fst x = name) seq

    /// Read some records from file
    static member ReadFromFile filePath seq =
        File.ReadLines (filePath)
                |> Seq.filter(fun x -> x |> System.String.IsNullOrWhiteSpace |> not)
                |> Seq.map(fun x -> x.Split (".....", StringSplitOptions.RemoveEmptyEntries))
                |> Seq.map(fun x -> (x.[0], x.[1]))
                |> Seq.filter(fun x -> Seq.contains x seq |> not)
                |> Seq.append seq

    /// Write all your records in file
    static member WriteToFile filePath seq =
        File.WriteAllLines(filePath, seq |> Seq.map(fun x -> fst x + "....." + snd x))