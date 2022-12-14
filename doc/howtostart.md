# Before you start

If you want to use this library, you must include the `using Sharp.UI` inside your app namespace, which replaces the standard MAUI classes.

```cs
namespace ExampleApp;
using Sharp.UI;
```

```cs
namespace ExampleApp
{
    using Sharp.UI;
    ...
}
```

## Nuget Package

Last relases

##### .NET CLI

```
dotnet add package Sharp.UI --version 0.2.1-beta
```

##### Package manager

```
NuGet\Install-Package Sharp.UI -Version 0.2.1-beta
```

## VS Project Reference

If you want to use the `Sharp.UI` library by project reference

```xml
<ItemGroup>
    <ProjectReference Include="..\Sharp.UI\Sharp.UI.csproj" />
    <ProjectReference Include="..\Sharp.UI.Generator\Sharp.UI.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
</ItemGroup>
