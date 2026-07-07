//using System;
//using System.Reflection.Metadata;

//#if DEBUG
//[assembly: MetadataUpdateHandlerAttribute(typeof(HotReloadHandler))]

//internal static class HotReloadHandler
//{
//    // WYMAGANE przez dotnet watch
//    internal static void ClearCache(Type[] updatedTypes)
//    {
//        Console.WriteLine("ClearCache called");
//    }

//    // WYMAGANE przez dotnet watch  
//    internal static void UpdateApplication(Type[] updatedTypes)
//    {
//        Console.WriteLine("UpdateApplication called: " +
//            string.Join(", ", updatedTypes?.Select(t => t.FullName) ?? []));

//        MainThread.BeginInvokeOnMainThread(() =>
//            Sharp.UI.HotReloadPageRegistry.RebuildAll(updatedTypes));

//    }

//    // OPCJONALNE ale dodaj dla pewności
//    internal static void BeforeUpdate(Type[] updatedTypes)
//    {
//        Console.WriteLine("BeforeUpdate called");
//    }
//}
//#endif

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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
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