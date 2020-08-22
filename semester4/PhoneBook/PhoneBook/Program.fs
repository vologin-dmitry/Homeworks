open System
open System.IO
open PhoneBook

[<EntryPoint>]
let main argv =
    /// Main menu of phonebook
    let rec menu (seq) =
        match Console.ReadLine () with
        | "1" -> 0
        | "2" ->
            printfn "Please enter name"
            let name = Console.ReadLine ()
            printfn "Please enter phone"
            let number = Console.ReadLine ()
            menu (PhoneBook.Add name number seq)
        | "3" ->
            printfn "Please enter name to search"
            let name = Console.ReadLine ()
            let answer = PhoneBook.GetNumber name seq
            if Seq.length answer = 0 then
                printfn "Sorry, name not found"
                menu seq
            else
                Seq.iter (fun x -> x |> snd |> printfn "Number is: %A") answer
                menu seq
        | "4" ->
            printfn "Please enter phone to search"
            let number = Console.ReadLine ()
            let answer = PhoneBook.GetName number seq
            if Seq.length answer = 0 then
                printfn "Sorry, number not found"
                menu seq
            else
                Seq.iter (fun x -> x |> fst |> printfn "Name is: %A") answer
                menu seq
        | "5" ->
            printfn "Your data:"
            seq |> Seq.iter(fun (name, number) -> printfn "%A %A" name number)
            menu seq
        | "6" ->
            printfn "Please enter file path"
            let path = Console.ReadLine ()
            PhoneBook.WriteToFile path seq
            menu seq
        | "7" ->
            printfn "Please enter file path"
            let path = Console.ReadLine ()
            try
                PhoneBook.ReadFromFile path seq |> menu
            with
            | :? FileNotFoundException ->
                printfn "File not found!"
                menu seq
            | :? ArgumentException ->
                printfn "Something bad with file path"
                menu seq
            | _ ->
                printfn "IO Exception!"
                menu seq
        | _ -> menu seq
    
    printfn "Welcome to the PhoneBook!"
    printfn "Press 1 to exit"
    printfn "Press 2 to add data"
    printfn "Press 3 to find number by name"
    printfn "Press 4 to find name by number"
    printfn "Press 5 to print all data"
    printfn "Press 6 to save all data in file"
    printfn "Press 7 to input data from file"
    menu <| Seq.empty<string * string>