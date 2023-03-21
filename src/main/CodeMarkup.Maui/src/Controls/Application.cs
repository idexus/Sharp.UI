namespace CodeMarkup.Maui
{
    [CodeMarkup]
    public partial class Application : Microsoft.Maui.Controls.Application
    {
        public static IServiceProvider Services { get; internal set; }
    }
}