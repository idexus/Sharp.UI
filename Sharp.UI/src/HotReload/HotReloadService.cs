
#if DEBUG
#pragma warning disable CS8632

[assembly: System.Reflection.Metadata.MetadataUpdateHandlerAttribute(typeof(Sharp.UI.HotReloadService))]
namespace Sharp.UI
{
    public static class HotReloadService
    {
        internal static void ClearCache(Type[]? types) { }
        internal static void UpdateApplication(Type[]? types)
        {
            HotReload.UpdateApplication(types);
        }
    }
}

#pragma warning restore CS8632
#endif