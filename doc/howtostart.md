
# VS Project Reference

If you want to use the `Sharp.UI` library by project reference

```xml
<ItemGroup>
    <ProjectReference Include="..\Sharp.UI\Sharp.UI.csproj" />
    <ProjectReference Include="..\Sharp.UI.Generator\Sharp.UI.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
    <ProjectReference Include="..\Sharp.UI\libs\HotReloadKit\src\HotReloadKit.Generator\HotReloadKit.Generator.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false"/>
</ItemGroup>
