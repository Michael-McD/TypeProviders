#r "nuget: FSharp.Data"

open FSharp.Data

type Questions = JsonProvider<"""https://api.stackexchange.com/2.2/questions?site=stackoverflow""">

let fsQuestions = """https://api.stackexchange.com/2.2/questions?page=1&pagesize=20&fromdate=1593561600&todate=1598572800&order=desc&sort=activity&tagged=f%23&site=stackoverflow"""
Questions.Load(fsQuestions).Items |> Seq.iter (fun q -> printfn "%s" q.Title)


