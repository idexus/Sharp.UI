
# Project Reference

To use the `Sharp.UI` library in your project, you can add a project reference in Visual Studio.

Add the following code to your `.csproj` file:

```xml
<ItemGroup>
	<ProjectReference Include="..\Sharp.UI\src\packages\Sharp.UI\Sharp.UI.csproj" />
	<ProjectReference Include="..\Sharp.UI\src\generators\Sharp.UI.Generator.Extensions\Sharp.UI.Generator.Extensions.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
	<ProjectReference Include="..\Sharp.UI\src\generators\Sharp.UI.Generator.SharpObjects\Sharp.UI.Generator.SharpObjects.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
	<ProjectReference Include="..\Sharp.UI\libs\HotReloadKit\src\HotReloadKit.Generator\HotReloadKit.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
</ItemGroup> 
```

By adding this code, you will reference the main `Sharp.UI` project, the `Sharp.UI.Generator.Extensions` project, the `Sharp.UI.Generator.SharpObjects` project and the `HotReloadKit.Generator` project. This will allow you to use the Sharp.UI library in your project and access its features and functionalities.
