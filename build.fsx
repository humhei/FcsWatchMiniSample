#r "paket:
git https://github.com/humhei/Paket_NugetServer.git NugetStore Packages: /.nuget/
source https://api.nuget.org/v3/index.json
nuget Atrous.Core.Utils
nuget Fake.Core.Target
nuget FcsWatch //"
#load "./.fake/build.fsx/intellisense.fsx"

// start build
open Fake.Core
open Fake.IO
open Microsoft.FSharp.Compiler.SourceCodeServices
open FcsWatch.FakeHelper
open Atrous.Core.Utils.FakeHelper

let root = Path.getDirectory "./"
Target.create "FcsWatch" (fun _ ->  
    let projectFile = Path.getFullName "FcsWatchMiniSample.fsproj"
    dotnet root "build" [projectFile]
    let checker = FSharpChecker.Create()
    runFcsWatcher checker projectFile
)

Target.create "Default" ignore

Target.runOrDefault "Default"