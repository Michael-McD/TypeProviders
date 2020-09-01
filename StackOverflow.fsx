#r "/home/michael/.nuget/packages/fsharp.data/3.3.3/lib/netstandard2.0/FSharp.Data.dll"
#load "StackOverflowDsl.fs"

open TypeProviders.StackOverflowDsl

let ``F#`` = "F%23"
let ``C#`` = "C%23"

let queryRoot = """https://api.stackexchange.com/2.2/questions?site=stackoverflow"""
let fsQuestions =
    queryRoot
    |> tagged [``F#``]
    |> page 1
    |> pageSize 100
    |> getQuestions
let csQuestions =
    queryRoot
    |> tagged [``C#``]
    |> page 1
    |> pageSize 100
    |> getQuestions
let javaQuestions =
    queryRoot
    |> tagged ["Java"]
    |> page 1
    |> pageSize 100
    |> getQuestions
let jsQuestions =
    queryRoot
    |> tagged ["JavaScript"]
    |> page 1
    |> pageSize 100
    |> getQuestions
    
let analyzeTags (qs:Questions.Item seq) =
    qs
    |> Seq.collect (fun q -> q.Tags)
    |> Seq.countBy id
    |> Seq.filter (fun (_, count) -> count > 2)
    |> Seq.sortBy (fun (_, count) -> count)
    |> Seq.iter (fun (tag, count) -> printfn "%s - %i" tag count)