module WebPageDownloader.Tests

open NUnit.Framework
open FsUnit
open Downloader

[<Test>]
let ``Cheeze test`` () =
    let data = (getAllMentionedPages "https://akulovka.com/blog/syr/").Value
    data |> snd |> List.length |> should equal 27
    data |> snd |> List.item 0 |> fst |> should equal "https://akulovka.com/blog/rss/"

[<Test>]
let ``Github test`` () =
    let data = (getAllMentionedPages "https://github.com/").Value
    data |> snd |> List.length |> should equal 53
    data |> snd |> List.item 0 |> fst |> should equal "https://github.githubassets.com"

[<Test>]
let ``Invalid url test`` () =
    getAllMentionedPages "https://theresnotgingihope.com" |> should equal None