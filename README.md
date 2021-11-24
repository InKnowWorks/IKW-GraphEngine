# Graph Engine - Open Source

The Microsoft Graph Engine is a fantastic technology and although  the original Microsoft Repo does not get much love or attention from the Microsoft Research team the software works has planned used in a number of commercial applications. We use it heavily @ InKnowWorks and thus we continue to evolve the technology.

### New Capabilities are coming! (Spring 2022)

- Updated C# Code generation: Support for C# 8, 9 and 10 coming in the Spring of 2022
- Native code generation for Java 15 Client-side code only
- Refactored Azure Service Fabric support 
- Native OWL 2 support via TSL 2.0
- Updated and Revised LIKQ for various graph traversal
- New Graph Engine VS 2022 plug-in
- much more ..

| - | Windows Multi Targeting | Ubuntu 16.04 .NET Core |
|:------:|:------:|:------:|
|Build|[<img src="https://trinitygraphengine.visualstudio.com/_apis/public/build/definitions/4cfbb293-cd2c-4f49-aa03-06894081c93b/3/badge"/>](https://trinitygraphengine.visualstudio.com/trinity-ci/_build/index?definitionId=3)|[<img src="https://trinitygraphengine.visualstudio.com/_apis/public/build/definitions/4cfbb293-cd2c-4f49-aa03-06894081c93b/4/badge"/>](https://trinitygraphengine.visualstudio.com/trinity-ci/_build/index?definitionId=4)|
|Tests|_|_|
|Stress|_|_|

This repository contains the source code of [Graph Engine][graph-engine] and its graph
query language -- [Language Integrated Knowledge Query][likq] (LIKQ).

Microsoft Graph Engine is a distributed
in-memory data processing engine, underpinned by a strongly-typed
in-memory key-value store and a general-purpose distributed computation
engine.

[LIKQ][likq-gh]
is a versatile graph query language atop Graph Engine. It
combines the capability of fast graph exploration with the flexibility
of lambda expression. Server-side computations can be expressed in
lambda expressions, embedded in LIKQ, and executed on Graph Engine servers during graph traversal.

## How to contribute

If you are interested in contributing to Graph Engine, please fork the
repository and submit pull requests to the `master` branch.

Pull requests, issue reports, and suggestions are welcome.


## Getting started with Graph Engine

### NuGet packages and Visual Studio extension

NuGet packages [Graph Engine Core][graph-engine-core] and [LIKQ][likq-nuget] are available in the NuGet Gallery.

If you develop Graph Engine applications using [Visual Studio][vs] on Windows, [Graph Engine VSExtension][vs-extension] can be used to facilitate the development work.

### Building on Windows

Install [Visual Studio 2017 or 2019 and VS *2022][vs] with the following components selected:

- Support for VS 2022 is under development

- .NET desktop development
    - .NET Framework 4.7.2 development tools
    - .NET 5.0 / .NET 6.0
- Desktop development with C++
    - Windows 10 SDK
    - Windows 11 SDK
- Visual Studio extension development
- .NET Core SDK 3.1
- .NET 5/6 SDK for Visual Studio
- cmake (latest)

[.NET 5/6 SDK][dotnet-download] and [cmake][cmake-download] can alternatively be installed using their standalone installers.

The Windows build will generate multi-targeting nuget packages.
Open a powershell window, run `tools/build.ps1` for Visual Studio 2017 or `tools/build.ps1 -VS2019` for Visual Studio 2019.

The Linux native assemblies will also be packaged (pre-built at `lib`) to allow the Windows build to work for Linux `.Net Core` as well.

### Building on Linux

Install `libunwind8`, `g++`, `cmake` and `libssl-dev`. For example, run `sudo apt install libunwind8 g++ cmake libssl-dev` for Ubuntu.

Install [.NET 5.0][dotnet-download] and execute `bash tools/build.sh`.
Install [.NET 6.0][dotnet-download] and execute `bash tools/build.sh`.

The Windows native assemblies will also be packaged so that the
Linux build will work for Windows `.Net Core` as well.

**Note:** Because `.Net Framework` is Windows-only, the packages built on Linux only support `.Net Core`. The build script is tested only on `Ubuntu 16.04`, `Ubuntu 18.04`, and `Ubuntu 20.04`.

### How to use the built Graph Engine packages

Nuget packages will be built as
`build/GraphEngine**._version_.nupkg`. The folder `build/` will be
registered as a local NuGet repository and the local package cache for
`GraphEngine.Core` will be cleared. After the packages are built, run `dotnet restore` to use the newly built package.

### Build for Mac OS (Coming in 2022!)

### Run your first Graph Engine app

Go to the `samples/Friends/Friends` folder, execute `dotnet restore` and `dotnet run` to run the sample project.

### New Samples apps and new learnings + useful documentation

Lost of new Samples 
- WPF 
- UWP (Current)
- WinUI (current)
- Reactive Design Patterns for Graph Engine Server and Client side implementations
- RDF, RDFS, and Labled Property Graphs and HyperGraphs data models
=======

[LIKQ][likq-gh]
is a versatile graph query language on top of Graph Engine that
combines the capability of fast graph exploration with the flexibility
of lambda expression. Server-side computations can be expressed in
lambda expressions, embedded in LIKQ, and executed server side
during graph traversal.

## How to Contribute

If you are interested in contributing to the code, please fork the
repository and submit pull requests to the `master` branch.


### Don't' use these Nuget packages as they are obsolete !

[graph-engine]: https://www.graphengine.io/

[likq]: https://www.graphengine.io/video/likq.video.html

[likq-gh]: https://github.com/Microsoft/GraphEngine/tree/master/src/Modules/LIKQ

[academic-graph-search]: https://azure.microsoft.com/en-us/services/cognitive-services/academic-knowledge/
[vs-extension]: https://visualstudiogallery.msdn.microsoft.com/12835dd2-2d0e-4b8e-9e7e-9f505bb909b8
=======
[gallery]: https://visualstudiogallery.msdn.microsoft.com/12835dd2-2d0e-4b8e-9e7e-9f505bb909b8

[graph-engine-core]: https://www.nuget.org/packages/GraphEngine.Core/

[likq-nuget]: https://www.nuget.org/packages/GraphEngine.LIKQ/

[vs]: https://www.visualstudio.com/

[dotnet-download]: https://dotnet.microsoft.com/download/

[cmake-download]: https://cmake.org/download/

[license]: LICENSE.md
