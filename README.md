# Microsoft Graph Engine

The Microsoft Graph Engine is a fantastic technology and although the original Microsoft Repo does not get much love or attention from the Microsoft Research team the software works and we are using the it in a number of commercial applications and Azure hosted Microservices. We use it heavily @ InKnowWorks and at RocketUrBiz and thus we continue to evolve the technology.

## Focus on Semantic Technology

One of the aspects of development in this repo is to leverage the Graph Engine is the Semantic (Ontology), Generative (Code Generation) and MB/LB (Model-based Machine Learning) disciplines. We are working to create blended capabilities to create a powerful platform for advanced applications in the Server and Client computing spaces. I am also working on a series of blogs that present all aspects of our research, and I have planned and actively working on a new documentation and a book. I have been using the Graph Engine in serious development scenarios dating back to 2015 and learned a great deal in doing so. In the coming years, I will make time to make public what I have learned and to make it easier for developer to get involved in development and to use the technology in their favorite projects. Here are some of they types of capabilities I am working to inclued:

* Visual Modeling for TSL
* Deep intergration with Visual Studio and VS Code
* Built-in support for BFO/IAO Upper ontology code generation
    - TSL to OWL, RDF, SKOS
    - Semantic Reasoing
    - Logic programming
* Extentions to LIKQ
* Leverate (Haskell) Hets - the Heterogeneous Tool Set
* General Purpose Semantic Enhancement Support
* much mroe..

![image](https://user-images.githubusercontent.com/5692812/205723281-59ad9df0-d3ed-4dee-8126-c6bccd08e576.png)

I can't possibly do all of myself so I am hoping that others might want to get involved. I am also working to secure financing in the 2023 to build a team that will continue to develop the Graph Engine is the open.

### New Capabilities are coming! (Winter 2022/ Spring 2023)

- Revised and Updated MSBuild CI/CD for GitHub and Azure Git Repos (completed)
- Updated C# Code generation: Support for C# 8, 9 and 10/11 coming in the Fall of 2022 (in progress)
- New documentation to help developer to better understand leverage the Trinity Graph Engine APIs and 
  new Design Guide on best practices in support for Graph Engine Symmetric (DUAL) DSL runtime (in progress)
- Native code generation for Java 15 Client-side code only
- NEW - Native Support for Fully Managed Reactive Server-side Push Automation - GE Availability Group Aware support under development
    * Mods to TSL compiler to support Push automation
    * Fully baked .NET 6 Console and WPF/WinUI/MAUI/Blazer Cleint and Server apps that demonstrate the power of the Graph Engine Semantic programming paradigms
    * prototype complete - refactoring in progress
- Native support for .NET 6/7 gRPC "ge app server to ge app server" - (in progress)
- Refactored Azure Service Fabric and extended support (in progress)
- UPDATE: Native OWL 2 support via TSL 2.0 via Reactive Event processing, C# 10 Functional implementation and new Graph Engine Adapter Pattern
    * new Visual TSL modeling engine under construction
    * TSL to OWL 2.0 with DL and Full extensions
- Updated and Revised LIKQ for various graph traversal
    * Demos that demonstrate the powerful Prolog-like capabilities of the LIKQ
    * Demos that demonstrate integration of the Microsoft Guan Logic statements in LIKQ and in the GE 
- New Graph Engine VS 2022 plug-in (new VS 2022 project setup complete; testing in progress)
    * New VS 2022 Templates
        - TSL Graph Data Taxonomy Model Templates
        - GE App Server, Proxy and Server Protocol Templates
- New Developers Guide
- much more ..

### This Repo does include support for Graph Engine integrated with Azure Service Fabric
    - Support for Azure Service Fabric is still under development
    - Release is targeted for late Spring 2023

| - | Windows | Linux |
|:------:|:------:|:------:|
|Build|![Build status badge](https://msai.visualstudio.com/GraphEngine/_apis/build/status/GraphEngine-Windows)|![Build status badge](https://msai.visualstudio.com/GraphEngine/_apis/build/status/GraphEngine-Linux)|

This repository contains the source code of [Microsoft Graph Engine][graph-engine] and its graph
query language -- [Language Integrated Knowledge Query][likq] (LIKQ).

Microsoft Graph Engine is a distributed in-memory data processing engine,
underpinned by a strongly-typed in-memory key-value store and a general-purpose distributed computation
engine.

[LIKQ][likq-gh]
is a versatile graph query language built atop Graph Engine. It
combines the capability of fast graph exploration with the flexibility
of lambda expressions. Server-side computations can be expressed in
lambda expressions, embedded in LIKQ, and executed on the Graph Engine servers during graph traversal.

## Recent changes

The main version number is bumped to 4.0 to reflect the recent toolchain updates.
- .NET 7
- .NET from 3.1 to 6.0
- .NET Framework from 4.61 to 4.8
- Visual Studio from 2017/2019 to 2022

One goal of Graph Engine 4.0 is to bring the system up-to-date and make it slimmer.
Some obsolete or outdated modules and tools will be removed from the build pipeline.

## Getting started

Recommended operating system: Windows 10 or Ubuntu 20.04.

### Building on Windows

Download and install [Visual Studio][vs] with the following "workloads" and "individual components" selected:
- The ".NET desktop development" and "Desktop development with C++" workloads.
- The ".NET Portable Library targeting pack" individual component.

Open a powershell window, run `tools/build.ps1` for generating multi-targeting nuget packages.
The script has been tested on Windows 10 (21H2) with Visual Studio 2022.

- Support for VS 2022 is under development

- .NET desktop development
    - .NET Framework 4.8 development tools
    - .NET 6.0
    - .NET 7.0
- Desktop development with C++
    - Windows 10 SDK
    - Windows 11 SDK
- Visual Studio extension development
- .NET 6 SDK for Visual Studio
- .NET 7 SDK for Visual Studio
- cmake (latest)
- Updated Linux build

[.NET 6 SDK][dotnet-download] and [cmake][cmake-download] can alternatively be installed using their standalone installers.

The Windows build will generate multi-targeting nuget packages.
Open a powershell window, run `tools/build.ps1` for Visual Studio 2017 or `tools/build.ps1 -VS2019` for Visual Studio 2019.

The Linux native assemblies will also be packaged (pre-built at `lib`) to allow the Windows build to work for Linux `.Net Core` as well.

### Building on Linux

Install g++, cmake, and libssl-dev. For example, on Ubuntu, simply run

```shell
sudo apt install g++ cmake libssl-dev
```

Install [.NET SDK x64 6.0][dotnet6-on-ubuntu20-04] and run:

```shell
bash tools/build.sh
```

The build script has been tested on Ubuntu 20.04 with g++ 9.4.0.

### Using the built packages

You can find the built nuget packages `build/GraphEngine**._version_.nupkg` in the `build/` folder.
The folder `build/` will be registered as a local NuGet repository and the local package cache for
`GraphEngine.Core` will be cleared. After the packages are built, run `dotnet restore` to use the newly built packages.

### Running your first Graph Engine app

Go to the `samples/Friends/Friends` folder, execute `dotnet restore` and `dotnet run` to run the sample project.

## Contributing

Pull requests, issue reports, and suggestions are welcome.

Please read the [code of conduct](CODE_OF_CONDUCT.md) before contributing code.

Follow these [instructions](SECURITY.md) for reporting security issues.

## License

Copyright (c) Microsoft Corporation. All rights reserved.

Licensed under the [MIT](LICENSE.md) license.

## Disclaimer

Microsoft Graph Engine is a research project. It is not an officially supported Microsoft product.

<!--
Links
-->

[graph-engine]: https://www.graphengine.io/

[likq]: https://www.graphengine.io/video/likq.video.html

[likq-gh]: https://github.com/Microsoft/GraphEngine/tree/master/src/Modules/LIKQ

[academic-graph-search]: https://azure.microsoft.com/en-us/services/cognitive-services/academic-knowledge/

[vs-extension]: https://visualstudiogallery.msdn.microsoft.com/12835dd2-2d0e-4b8e-9e7e-9f505bb909b8

[graph-engine-core]: https://www.nuget.org/packages/GraphEngine.Core/

[likq-nuget]: https://www.nuget.org/packages/GraphEngine.LIKQ/

[vs]: https://www.visualstudio.com/

[dotnet-download]: https://dotnet.microsoft.com/

[dotnet6-on-ubuntu20-04]: https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004

[license]: LICENSE.md
