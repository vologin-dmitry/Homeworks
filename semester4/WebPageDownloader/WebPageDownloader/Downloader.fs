module Downloader

open System.Net
open System.IO
open System.Text.RegularExpressions
open System

let expr = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))"
let regex = Regex (expr, RegexOptions.IgnoreCase)

/// Downloads page and returns page and its url
let fetchAsync url =
    async {
        try
            let request = WebRequest.Create(Uri(url))
            use! response = request.AsyncGetResponse()
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let page = reader.ReadToEnd()
            return Some (url, page)
        with
        | _ ->
            return None
    }

/// Finds all links on given page
let getAllLinks page =
    regex.Matches(page) |> Seq.map (fun (x : Match) -> x.Groups.[1].Value) |> Seq.toList 

/// Tales list of urls and download all page by every url
let getAllPages links =
    List.map fetchAsync links |> Async.Parallel |> Async.RunSynchronously |> Array.toList

/// Returns page located by given url and all pages mentioned there
let getAllMentionedPages url =
    let firstPage = fetchAsync url |> Async.RunSynchronously
    match firstPage with
    | None -> None
    | Some (_, page) ->
        let pages = page |> getAllLinks |> getAllPages |> List.filter (fun x -> x.IsSome) |> List.map Option.get
        Some (firstPage.Value, pages)

/// Prints all urls mentioned in page located by given url and number of symbols in these pages
let printAllData url =
    match getAllMentionedPages url with
    | None -> printfn "Nothing had been found, seems like url is wrong"
    | Some (page, mentioned) ->
        printfn "Original url %s --- %i symbols" (fst page) ((snd page).Length)
        mentioned |> List.length  |> printfn "Found %i valid links"
        mentioned |> List.iter (fun item -> printfn "Url: %s --- %i symbols" (fst item) (snd item).Length)