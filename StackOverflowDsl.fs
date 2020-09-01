namespace TypeProviders

module StackOverflowDsl =
    open FSharp.Data
    
    type Questions = JsonProvider<"""https://api.stackexchange.com/2.2/questions?site=stackoverflow""">

    let tagged tags query =
        let joinedTags = tags |> String.concat ";"
        sprintf "%s&tagged=%s" query joinedTags
    let page p query =
        sprintf "%s&page=%i" query p
    let pageSize s query =
        sprintf "%s&pagesize=%i" query s
    let getQuestions (query:string) =
        Questions.Load(query).Items
    

