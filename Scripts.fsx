#r "/home/michael/.nuget/packages/fsharp.data/3.3.3/lib/netstandard2.0/FSharp.Data.dll"
#load "Dsl.fs"

open TypeProviders.Dsl

let ``F#`` = "F%23"
let ``C#`` = "C%23"

let queryRoot = """https://api.stackexchange.com/2.2/questions?site=stackoverflow"""
let fsQuestions =
    queryRoot
    |> tagged [``F#``]
    |> page 1
    |> pageSize 20
    |> getQuestions