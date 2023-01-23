using System;

namespace ExampleApp
{
    using Sharp.UI;

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()            
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            //builder.Logging.AddDebug();
            HotReload.InitSharpUIHotReload();
#endif

            builder.Services.AddSingleton<ListViewPageViewModel>();
            builder.Services.AddSingleton<SecondPageViewModel>();
            builder.Services.AddSingleton<MyViewModel>();
           
            var mauiApp = builder.Build();
            Application.ServiceProvider = mauiApp.Services;
            return mauiApp;
        }
    }
}

