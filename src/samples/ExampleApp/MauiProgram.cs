
namespace ExampleApp
{
    using Sharp.UI;

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .SharpUIApp()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("JetBrainsMono-Regular.ttf", "CodeFont");
                });

            builder.Services.AddSingleton<SecondPageViewModel>();
            builder.Services.AddSingleton<KeypadViewModel>();

            builder.Services.AddSingleton<SecondPage>();
            builder.Services.AddSingleton<KeypadPage>();

            Routing.RegisterRoute("details", typeof(NavigationDetailPage));
            Routing.RegisterRoute("seconddetails", typeof(NavigationSecondDetailPage));

            return builder.Build();
        }
    }
}