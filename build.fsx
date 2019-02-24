#r "paket:
source https://api.nuget.org/v3/index.json
nuget Fake.Core.Target = 5.12.0
nuget FcsWatch //"
#load "./.fake/build.fsx/intellisense.fsx"

// start build
open Fake.Core
open Fake.IO
open Microsoft.FSharp.Compiler.SourceCodeServices
open FcsWatch.FakeHelper
open Fake.DotNet

Target.create "FcsWatch" (fun _ ->

    let projectFile = Path.getFullName "./FcsWatchMiniSample/FcsWatchMiniSample.fsproj"
    printfn "%A" projectFile
    DotNet.build (fun ops ->
      { ops with
          Configuration = DotNet.BuildConfiguration.Debug }
    ) projectFile
    let checker = FSharpChecker.Create()
    runFcsWatcher checker projectFile
)

Target.runOrDefault "FcsWatch"
