namespace Sharp.UI
{

    [SharpObject(typeof(Microsoft.Maui.Controls.Application))] 
    public partial class Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null;

        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();
            ServiceProvider = this.Handler.MauiContext.Services;
        }
    }
}