namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.Application))]
    public partial class Application
    {
        public static IServiceProvider Services { get; internal set; }
        public static bool HotReloadIsEnabled { get; internal set; } = false;
    }
}