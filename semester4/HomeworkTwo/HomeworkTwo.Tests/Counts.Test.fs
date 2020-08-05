module HomeworkTwo.Tests.Counts

open FsUnit
open FsCheck
open Counts
open NUnit

let filterEqualsMap list = filterCount list = mapCount list

let foldEqualsMap list = foldCount list = mapCount list

let filterEqualsFold list = filterCount list = foldCount list

[<Test>]
let ``filter equals map``() = Check.QuickThrowOnFailure filterEqualsMap