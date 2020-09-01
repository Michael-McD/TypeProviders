# F# TypeProviders

F# Type Providers consuming a number of data sources including those from StackOverflow and the World Bank.

## Stackoverflow API
We create a simple Domain Specific Language (DSL) allowing us to construct queries in a more friendly manner.

```f#
let jsQuestions =
    queryRoot
    |> tagged ["JavaScript"]
    |> page 1
    |> pageSize 100
    |> getQuestions
```
There is also a small script to analyze the questions i.e. returns a count of the top tags.
```f#
let analyzeTags (qs:Questions.Item seq) =
    qs
    |> Seq.collect (fun q -> q.Tags)
    |> Seq.countBy id
    |> Seq.filter (fun (_, count) -> count > 2)
    |> Seq.sortBy (fun (_, count) -> count)
    |> Seq.iter (fun (tag, count) -> printfn "%s - %i" tag count)
```

## World Bank

