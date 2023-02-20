namespace Sharp.UI
{
    [SharpObject]
    public partial class Application : Microsoft.Maui.Controls.Application
    {
        public static IServiceProvider Services { get; internal set; }
        public static bool HotReloadIsEnabled { get; internal set; } = false;
    }
}