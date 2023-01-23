namespace Sharp.UI
{

    [SharpObject(typeof(Microsoft.Maui.Controls.Application))] 
    public partial class Application
    {
        public static IServiceProvider ServiceProvider { get; set; } = null;
    }
}