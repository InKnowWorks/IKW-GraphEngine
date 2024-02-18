# Microsoft Graph Engine: A Semantic and Ontologically-Grounded Evolution

The Microsoft Graph Engine (GE), originally a product of Microsoft Research, serves as the backbone of multiple production-grade applications at InKnowWorks and RocketUrBiz. This repository aims to extend and enhance the Trinity Graph Engine's capabilities, focusing on semantic and ontological dimensions, leveraging Trinity's Distributed Symmetric RPC over TCP/IP for high-throughput, low-latency distributed systems.

## Discord Channel Update: Launch Rescheduled for May 2024

Preparation of requisite media materials for the Discord channels is more labor-intensive than initially estimated. The launch is therefore rescheduled to October 2023.

## Ontologically-Driven Focus

This repository focuses on advancing the Trinity Graph Engine (TGE) into a robust platform for semantic technologies (OWL 2 DL, BFO, IAO), generative programming, and model-based machine learning (MB/LB). The roadmap includes:

* **Visual Modeling for TSL**
    - Utilizing formal logic notations for design (FOL, SOL, Transaction Logic)
* **Semantic Layering**
    - TSL to BFO 2020, OWL, RDF/RDFS, IAO, RO, (Common Core Ontology) CCO, SKOS transformations
    - Enabling A-Box, T-Box, and R-Box ontological reasoning via BFO 2020 Common Logic Axioms
* **Extensions to LIKQ**
    - Incorporating Prolog-like graph traversal logic
* **Reactive Functional Programming**
    - C# 10/11/12 functional implementations with Rx.NET and MessagePipe
    - TSL compiler modifications to support reactive server-side push automation
    - TSL compiler modifications to support BFO 2020 Attribuites on TSL "struct"

![image](https://user-images.githubusercontent.com/5692812/205723281-59ad9df0-d3ed-4dee-8126-c6bccd08e576.png)

The aim is to build a collaborative community. Financing is being secured for 2023/2024 to assemble a dedicated team for open development.

### Extending Microsoft Guan Logic Programming Library

This repository aims to extend the foundational capabilities of Microsoft's Guan Logic Programming Library by integrating various ontological and formal logic systems, thus enriching the logic engine's capacity for semantic reasoning and knowledge representation. The enhancements include:

* **BFO 2020 Logic Productions**: Embedding Basic Formal Ontology 2.0 for grounding real-world entities and events.
* **RO Mereological Productions**: Integration of the Relations Ontology for spatial-temporal reasoning.
* **IAO Logic Productions**: Incorporating the Information Artifact Ontology for digital artifact representation.
* **SKOS Logic Productions**: Enabling the Simple Knowledge Organization System for semantic tagging and categorization.
* **OWL 2 DL Logic Productions**: Extending Web Ontology Language (OWL) 2 Description Logic for nuanced T-Box, A-Box, R-Box, and B-Box reasoning.
* **Extended FOL and SOL**: Enhancing First-Order and Second-Order Logic productions for generalized logical reasoning.
* **Transaction Logic (T-Logic)**: Support for transaction-oriented reasoning, critical for database and workflow operations.
* **BFO 2 SPAN/SNAP Logics**: Integrating SNAP (Spatio-temporal snapshot) and SPAN (Spatio-temporal process) logics for dynamic world modeling.
* **Graph Logics**: Expanding Trinity's TSL capabilities to include logic productions for Hypergraphs, Multi-graphs, and Directed Graphs.

By extending the **Guan Logic Programming Engine/Library** in this manner, we aim to create a robust logic engine capable of handling complex semantic reasoning tasks, from semantic data modeling to ontology-driven natural language understanding. These features are in alignment with our overarching goal of creating a semantically rich, ontologically-grounded, high-throughput, low-latency distributed system leveraging Trinity's Distributed Symmetric RPC environment.

### Forthcoming Features

- **C# Code Generation**: Support for C# 10/11/12, with emphasis on reactive functional paradigms.
- **Semantic Programming Paradigms**: TSL to BFO 2020 and CL Axioms
- **Reactive Server-side Push Automation**: Utilizing TGE's Duplex Symmetric RPC to implement GE Availability Group Aware support.
- **gRPC Alternatives**: Native support for .NET 6/7 utilizing TGE's Symmetric RPC for high-throughput, low-latency distributed systems.

## New Full Sample Programs

Our repository offers a multitude of comprehensive sample programs to assist both newcomers and seasoned developers in mastering the TGE ecosystem. These samples cover a broad spectrum of use-cases, from basic graph traversal to complex microservices design. Examples include:

- **Directed Graph Examples**: Demonstrating basic graph traversal algorithms using TGE API sets and LIKQ.
- **Hypergraph and Multi-graph TSL Schema Modeling**: An in-depth look at designing complex graph structures.
- **Real-world Distributed Hashing**: Practical hashing techniques in a distributed environment.
- **Knowledge Graph Design with GE TSL**: A primer on constructing knowledge graphs using TGE’s TSL.
- **Aligning Knowledge Bases with Knowledge Graphs**: How to semantically align a Knowledge Base (KB) with a Knowledge Graph (KG) using GE TSL.
- **Effective TGE Symmetric D-RPC API Design Idioms**: Best practices for designing Distributed Symmetric RPC APIs.
- **Reactive Event Streaming with Rx.NET and MessagePipe**: Implementing real-time event streaming.
- **Integrating TGE with Microsoft Orleans**: A guide to TGE-Orleans integration.
- **Designing .NET Services using TGE**: Best practices and guidelines.
- **Understanding and Leveraging TGE Proxy**: A deep dive into TGE Proxy capabilities.
- **GE Microservices Design and Implementation**: A comprehensive guide to designing microservices using TGE.

## New Enhancements

Our development roadmap features several enhancements aimed at improving the developer experience and expanding TGE's capabilities:

- **SSL over TCP**: Enhancing security through SSL encryption.
- **New TGE TSL Attributed DSL Mark-up Annotations**: Introducing a new TSL Attribute Processor modeled after TGE’s LIKQ Attribute Processor.

![image](https://github.com/InKnowWorks/IKW-GraphEngine/assets/5692812/dc96e3d8-7399-451b-9834-6950f5b7d3c1)

- # UIServiceRegistrationInfo Cell Struct Definition

## Overview
The `UIServiceRegistrationInfo` cell struct is designed for a graph database system, integrating concepts from Basic Formal Ontology (BFO) and Relation Ontology (RO). This document breaks down its components and explains their significance in the context of a software domain.

### Struct Attributes
- **GraphNodeType: Hyper**: Enables hyperedges, connecting multiple nodes.
- **BFO: Continuant**: Represents entities persisting through time while undergoing changes.
- **RO: part_of**: Implies relationships where components may be part of or contained in other entities.

## Fields Description

### 1. ServiceIdRegId (Guid)
- **BFO: Quality, InformationContentEntity**: A 'Quality' providing information about another entity.

### 2. IsActive (bool)
- **BFO: RealizableEntity, Disposition**: A boolean property manifesting under certain conditions.

### 3. DateTimeStamp (DateTime)
- **BFO: Quality, TemporalQuality**: Timestamp indicating when an event occurred or will occur.

### 4. ServiceName (string)
- **BFO: Quality, InformationContentEntity**: Informational string describing the service.

### 5. Description (DescriptionInfoSet)
- **Criteria: ContextDependent, GraphEdgeType: Directed**
- **BFO: FiatObjectPart to Role, StrongComposition**: Fundamental part of `UIServiceRegistrationInfo`.

### 6. AssociatedViewModels (List<CellId>)
- **GraphEdgeType: Multi**
- **BFO: GenericallyDependentContinuant, Object to ObjectAggregate**: Aggregating multiple objects.

### 7. CommandInfoSetData (List<UIShellCommandInfo>, optional)
- **Criteria: ContextDependent, GraphEdgeType: Multi**
- **BFO: FiatObjectPart to Role, StrongComposition**: Potential, but not necessary, relationship.

### 8. ServiceInfoSetData (List<ServiceShellViewModelAssociation>, optional)
- **GraphEdgeType: Multi, WeakAggregate**
- **BFO: GenericallyDependentContinuant, Role**: Contextually dependent role of `UIServiceRegistrationInfo`.

### 9. EventInfoSet (List<CellId>, optional)
- **GraphEdgeType: Multi, WeakAggregate**
- **BFO: GenericallyDependentContinuant, Role**: Represents a contextually dependent role.

## Graph Database Implications
In a graph database, each property of this struct would be represented as nodes or edges, with BFO and RO annotations providing semantic context for complex querying and reasoning.

## Conclusion
The `UIServiceRegistrationInfo` struct is designed to capture not just data, but the relationships and potential states of that data, enhancing the system's analysis and inference capabilities.

- **Updated TSL Editor with Live Editing and IntelliSense for VS 2022+**: Enhanced editing capabilities for TSL.
- **New TGE TSL Graph Visualizer**: A graphical tool for visualizing TSL-defined structures.
- **New Visual Studio Templates for TGE**: Streamlining project setup.
- **Enhanced Documentation**: Including a new Developer's Guide and updated API documents.

### TSL Compiler Updates:

- **C++ Code Generator to Emit C# 10 code**: ETA Summer 2024.
- **Complete Rewrite of TSL Compiler**: ETA Summer 2025.
    - Support for the latest C# language features such as Records, Record Struct, Named Tuples, and functional programming paradigms like FRP, ROP, and FP (akin to LanguageExt).

### Getting Started

For Windows: Utilize Visual Studio 2022 with .NET 7/8 SDKs installed. Execute `tools/build.ps1` for generating multi-targeting NuGet packages.

For Linux: Install g++, cmake, and libssl-dev, followed by .NET SDK x64 6.0. Run `bash tools/build.sh`.

## Contributions and License

Your contributions via pull requests, issue reports, and suggestions are welcome. Please adhere to our [code of conduct](CODE_OF_CONDUCT.md).

### This Repo does include support for Graph Engine integrated with Azure Service Fabric
    - Support for Azure Service Fabric is still under development
    - Release is targeted for late Winter 2024

| - | Windows | Linux |
|:------:|:------:|:------:|
|Build|![Build status badge](https://msai.visualstudio.com/GraphEngine/_apis/build/status/GraphEngine-Windows)|![Build status badge](https://msai.visualstudio.com/GraphEngine/_apis/build/status/GraphEngine-Linux)|

This repository contains the source code of [Microsoft Graph Engine][graph-engine] and its graph
query language -- [Language Integrated Knowledge Query][likq] (LIKQ).

Microsoft Graph Engine is a distributed in-memory data processing engine,
underpinned by a strongly typed in-memory key-value store and a general-purpose distributed computation
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
- Visual Studio from 2017/2019 to 2022

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
    - .NET 6.0
    - .NET 7.0/8.0
- Desktop development with C++
    - Windows 10 SDK
    - Windows 11 SDK
- Visual Studio extension development
- .NET 6 SDK for Visual Studio
- .NET 7 SDK for Visual Studio
- .NET 8 SDK for Visual Studio
- cmake (latest)
- Updated Linux build

[.NET 6 SDK][dotnet-download] and [cmake][cmake-download] can alternatively be installed using their standalone installers.

The Windows build will generate multi-targeting nuget packages.
Open a PowerShell window, run `tools/build.ps1` for Visual Studio 2017 or `tools/build.ps1 -VS2019` for Visual Studio 2019.

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
