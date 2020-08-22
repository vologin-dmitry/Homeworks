module TestProject1

open NUnit.Framework
open FsUnit
open PhoneBook

[<Test>]
let ``add test`` () =
    let seq = PhoneBook.Add "Hello" "213-222-555" Seq.empty<string * string>
    seq |> should contain ("Hello", "213-222-555")

[<Test>]
let ``add two equal test`` () =
    let seq = Seq.empty<string * string> |> PhoneBook.Add "hey" "213-222-555"
                                         |> PhoneBook.Add "hey" "213-222-555"
    Seq.length seq |> should equal 1

[<Test>]
let ``add two test`` () =
    let seq = Seq.empty<string * string> |> PhoneBook.Add "Hello" "213-222-555"
                                         |> PhoneBook.Add "hey" "213-222-556"
    seq |> should contain ("Hello", "213-222-555")
    seq |> should contain ("hey", "213-222-556")

[<Test>]
let ``search name test`` () =
    let seq = Seq.empty<string * string> |> PhoneBook.Add "Hello" "213-222-555"
                                         |> PhoneBook.Add "hey" "213-222-556"
    let answer = PhoneBook.GetName "213-222-555" seq
    Seq.length answer |> should equal 1
    Seq.contains ("Hello", "213-222-555") answer |> should equal true

[<Test>]
let ``search number test`` () =
    let seq = Seq.empty<string * string> |> PhoneBook.Add "Hello" "213-222-555"
                                         |> PhoneBook.Add "hey" "213-222-556"
    let answer = PhoneBook.GetNumber "hey" seq
    Seq.length answer |> should equal 1
    Seq.contains ("hey", "213-222-556") answer |> should equal true

[<Test>]
let ``search name test two matches`` () =
    let seq = Seq.empty<string * string> |> PhoneBook.Add "Hello" "213-222-555"
                                         |> PhoneBook.Add "hey" "213-222-556"
                                         |> PhoneBook.Add "Hello again" "213-222-555"
    let answer = PhoneBook.GetName "213-222-555" seq
    Seq.length answer |> should equal 2
    Seq.contains ("Hello", "213-222-555") answer |> should equal true
    Seq.contains ("Hello again", "213-222-555") answer |> should equal true

[<Test>]
let ``search number test two matches`` () =
    let seq = Seq.empty<string * string> |> PhoneBook.Add "Ivan" "213-222-555"
                                         |> PhoneBook.Add "Ivan" "213-222-556"
                                         |> PhoneBook.Add "Ivan Ivanov" "213-222-555"
    let answer = PhoneBook.GetNumber "Ivan" seq
    Seq.length answer |> should equal 2
    Seq.contains ("Ivan", "213-222-555") answer |> should equal true
    Seq.contains ("Ivan", "213-222-556") answer |> should equal true

[<Test>]
let ``read from file to empty sequence test`` () =
    let data = PhoneBook.ReadFromFile "TestFile.txt" Seq.empty
    Seq.contains ("Ivan", "111-222-333") data |> should equal true
    Seq.contains ("Ivanov", "123-456-222") data |> should equal true

[<Test>]
let ``read from file to sequence test`` () =
    let data = Seq.empty |> PhoneBook.Add "Badnames" "132-132-132"|> PhoneBook.ReadFromFile "TestFile.txt" 
    Seq.contains ("Ivan", "111-222-333") data |> should equal true
    Seq.contains ("Badnames", "132-132-132") data |> should equal true