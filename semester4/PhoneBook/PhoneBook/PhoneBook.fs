module PhoneBook

open System
open System.IO

/// Simple phonebook with names and phone numbers
type PhoneBook =

    /// Add new record
    static member Add name number seq =
        if not <| Seq.contains (name, number) seq  then
            Seq.append [(name, number)] seq
        else seq

    /// Get name of person by its telephone number
    static member GetName number seq =
        Seq.filter(fun (nameToFind, numberToFind) -> numberToFind = number) seq

    /// Get telephone number of person by its name
    static member GetNumber name seq =
        Seq.filter(fun (nameToFind, numberToFind) -> nameToFind = name) seq

    /// Read some records from file
    static member ReadFromFile filePath seq =
        File.ReadLines (Directory.GetCurrentDirectory() + "/" + filePath)
                |> Seq.filter(fun x -> x |> System.String.IsNullOrWhiteSpace |> not)
                |> Seq.map(fun x -> x.Split ('\t', StringSplitOptions.RemoveEmptyEntries))
                |> Seq.map(fun x -> (x.[0], x.[1])) |> Seq.append seq

    /// Write all your records in file
    static member WriteToFile filePath seq =
        File.WriteAllLines(Directory.GetCurrentDirectory() + "/" + filePath, seq |> Seq.map(fun x -> fst x + "\t" + snd x))