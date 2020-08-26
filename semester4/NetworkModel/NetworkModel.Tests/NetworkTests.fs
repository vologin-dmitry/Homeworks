module NetworkModel.Tests

open NUnit.Framework
open FsUnit
open ComputerModel
open NetworkModel

let map1 =
    [ [ false; true; false ]
      [ true; false; true ]
      [ false; true; false ] ]

let map2 =
    [ [ false; true; false ]
      [ true; false; false ]
      [ false; false; false ] ]

let map3 =
    [ [ false; true; true; false; false ]
      [ true; false; false; true; false ]
      [ true; false; false; false; true ]
      [ false; true; false; false; false ]
      [ false; false; true; false; false ] ]

[<Test>]
let ``simple infect line test one step`` () =
    let computers =
        [ Computer("First", "Windows")
          Computer("Second", "Windows")
          Computer("Third", "Windows") ]

    computers.[0].Infected <- true
    let net = Network(computers, map1)
    net.Start 1 0
    computers.[0].Infected |> should equal true
    computers.[0].JustInfected |> should equal false
    computers.[1].Infected |> should equal true
    computers.[1].JustInfected |> should equal true
    computers.[2].Infected |> should equal false
    computers.[2].JustInfected |> should equal false

[<Test>]
let ``simple infect line test two steps`` () =
    let computers =
        [ Computer("First", "Windows")
          Computer("Second", "Windows")
          Computer("Third", "Windows") ]

    computers.[0].Infected <- true
    let net = Network(computers, map1)
    net.Start 2 0
    computers.[0].Infected |> should equal true
    computers.[0].JustInfected |> should equal false
    computers.[1].Infected |> should equal true
    computers.[1].JustInfected |> should equal false
    computers.[2].Infected |> should equal true
    computers.[2].JustInfected |> should equal true

[<Test>]
let ``simple infect line test three steps`` () =
    let computers =
        [ Computer("First", "Windows")
          Computer("Second", "Windows")
          Computer("Third", "Windows") ]

    computers.[0].Infected <- true
    let net = Network(computers, map1)
    net.Start 3 0
    computers.[0].Infected |> should equal true
    computers.[0].JustInfected |> should equal false
    computers.[1].Infected |> should equal true
    computers.[1].JustInfected |> should equal false
    computers.[2].Infected |> should equal true
    computers.[2].JustInfected |> should equal false

[<Test>]
let ``computers wit zero percent infection are not infected`` () =
    let computers =
        [ Computer("First", "General OS")
          Computer("Second", "BolgenOS")
          Computer("Third", "EncryptedThing") ]

    computers.[0].Infected <- true
    let net = Network(computers, map1)
    net.Start 10 0
    computers.[1].Infected |> should equal false
    computers.[2].Infected |> should equal false

[<Test>]
let ``separated computer should not be infected`` () =
    let computers =
        [ Computer("First", "Windows")
          Computer("Second", "Windows")
          Computer("Third", "Windows") ]

    computers.[0].Infected <- true
    let net = Network(computers, map2)
    net.Start 3 0
    computers.[2].Infected |> should equal false
    computers.[2].JustInfected |> should equal false

[<Test>]
let ``tree test one step`` () =
    let computers =
        [ Computer("First", "Windows")
          Computer("Second", "Windows")
          Computer("Third", "Windows")
          Computer("Fourth", "DomestOS")
          Computer("Fifth", "Igotnoideas") ]

    computers.[0].Infected <- true
    let net = Network(computers, map3)
    net.Start 1 0
    computers.[1].Infected |> should equal true
    computers.[2].Infected |> should equal true

[<Test>]
let ``tree test second step`` () =
    let computers =
        [ Computer("First", "Windows")
          Computer("Second", "Windows")
          Computer("Third", "Windows")
          Computer("Fourth", "DomestOS")
          Computer("Fifth", "Igotnoideas") ]

    computers.[0].Infected <- true
    let net = Network(computers, map3)
    net.Start 2 0
    computers.[3].Infected |> should equal false
    computers.[4].Infected |> should equal false
