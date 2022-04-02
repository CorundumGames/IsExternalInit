# IsExternalInit

[![GitHub Workflow Status (branch)](https://img.shields.io/github/workflow/status/CorundumGames/IsExternalInit/Release/main?logo=github&style=for-the-badge)](https://github.com/CorundumGames/IsExternalInit/actions)
[![openupm](https://img.shields.io/npm/v/games.corundum.isexternalinit?label=openupm&registry_uri=https://package.openupm.com&style=for-the-badge)](https://openupm.com/packages/games.corundum.isexternalinit)

Enables support for C# 9's [`record`](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records) types and
[`init` setters](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init) in Unity.

[Unity 2021.2 technically supports C# 9](https://docs.unity3d.com/2021.2/Documentation/Manual/CSharpCompiler),
but some of its language features rely on runtime libraries that aren't available in .NET Standard 2.1.
This package defines an internal class that these features require in order to function.

The included assembly originally came from [this NuGet package](https://www.nuget.org/packages/IsExternalInit.System.Runtime.CompilerServices)
([source](https://github.com/asynkron/IsExternalInit)).

## Installation

Follow the instructions given [here](https://openupm.com/packages/games.corundum.isexternalinit/#modal-manualinstallation)
to install this package in your project via OpenUPM.

## Usage

This package is delivered as a precompiled assembly
so that all [assembly definitions](https://docs.unity3d.com/Manual/class-AssemblyDefinitionImporter) reference it automatically.
There's no public API unless you count the enabled language features.
As a result,
you can get started
using standard [`record`s](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records) and
[`init` setters](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init) immediately.

There are some minor caveats when using this package:

- If an assembly definition uses the "Override References" setting to reference precompiled assemblies explicitly,
you'll need to add a reference to `IsExternalInit.System.Runtime.CompilerServices`.
Otherwise, that `asmdef` won't be able to use `record`s or `init`.
- Unity doesn't currently support serializing or editing `record`s,
so you'll need to implement that yourself.
- A future release of Unity with built-in support for `record`s and `init` may break this package
due to potential naming conflicts with the `System.Runtime.CompilerServices` namespace.
When that happens,
I'll add a [`#define` constraint](https://docs.unity3d.com/Manual/PluginInspector)
[tied to it](https://docs.unity3d.com/Manual/PlatformDependentCompilation) to minimize disruptions.

## Compatibility

This package should work in any version of Unity that provides at least partial support for C# 9, starting with 2021.2.
The provided assembly is disabled in older versions of Unity (i.e. versions that don't define `UNITY_2021_2_OR_NEWER`).
