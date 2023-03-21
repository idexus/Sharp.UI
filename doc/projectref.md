
#  Adding the Library by VS Project Reference

To use the `CodeMarkup.Maui` library in your project, you can add a project reference in Visual Studio.

Add the following code to your `.csproj` file:

```xml
<ItemGroup>
	<ProjectReference Include="..\CodeMarkup.Maui\src\main\CodeMarkup.Maui\CodeMarkup.Maui.csproj" />
	<ProjectReference Include="..\CodeMarkup.Maui\src\generators\CodeMarkup.Maui.Generator.Extensions\CodeMarkup.Maui.Generator.Extensions.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
	<ProjectReference Include="..\CodeMarkup.Maui\src\generators\CodeMarkup.Maui.Generator.Classes\CodeMarkup.Maui.Generator.Classes.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
	<ProjectReference Include="..\CodeMarkup.Maui\libs\HotReloadKit\src\HotReloadKit.Generator\HotReloadKit.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
</ItemGroup> 
```

This will allow you to use the CodeMarkup.Maui library in your project and access its features and functionalities.
