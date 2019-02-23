#r "paket:
source https://api.nuget.org/v3/index.json
nuget Fake.Core.Target
nuget FcsWatch //"
#load "./.fake/build.fsx/intellisense.fsx"

// start build
open Fake.Core
open Fake.IO
open Microsoft.FSharp.Compiler.SourceCodeServices
open FcsWatch.FakeHelper
open Fake.DotNet

Target.create "FcsWatch" (fun _ ->  
    let projectFile = Path.getFullName "FcsWatchMiniSample.fsproj"
    DotNet.build id projectFile
    let checker = FSharpChecker.Create()
    runFcsWatcher checker projectFile
)

Target.runOrDefault "FcsWatch"