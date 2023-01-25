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

            builder.Services.AddSingleton<ListViewPageViewModel>();
            builder.Services.AddSingleton<SecondPageViewModel>();
            builder.Services.AddSingleton<MyViewModel>();

            builder.Services.AddSingleton<ListViewPage>();
            builder.Services.AddSingleton<SecondPage>();

            var mauiApp = builder.Build();

#if DEBUG
            HotReload.InitSharpUIHotReload<App>(mauiApp);
#endif

            return mauiApp;
        }
    }
}

