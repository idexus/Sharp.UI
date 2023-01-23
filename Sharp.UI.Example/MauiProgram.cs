using System;
using Sharp.UI;

namespace ExampleApp
{
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
            
            return builder.Build();
        }
    }
}

