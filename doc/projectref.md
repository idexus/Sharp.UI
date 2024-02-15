
#  Adding the Library by VS Project Reference

To use the `Sharp.UI` library in your project, you can add a project reference in Visual Studio.

Add the following code to your `.csproj` file:

```xml
<ItemGroup>
	<ProjectReference Include="..\Sharp.UI\src\main\Sharp.UI\Sharp.UI.csproj" />
	<ProjectReference Include="..\Sharp.UI\src\main\Sharp.UI.Generator\Sharp.UI.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
	<ProjectReference Include="..\Sharp.UI\libs\HotReloadKit\src\HotReloadKit.Generator\HotReloadKit.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
</ItemGroup> 
```

This will allow you to use the Sharp.UI library in your project and access its features and functionalities.
