#r "/home/michael/.nuget/packages/fsharp.data/3.3.3/lib/netstandard2.0/FSharp.Data.dll"

open FSharp.Data

type WorldBank = WorldBankDataProvider<"World Development Indicators", Asynchronous=true>
let wb = WorldBank.GetDataContext()

wb
    .Countries.``United Kingdom``
    .Indicators.``School enrollment, tertiary (% gross)``
    |> Seq.maxBy fst