using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.HotReload;

namespace Sharp.UI
{
	public static partial class SharpUIAppExtension
	{
        public static MauiAppBuilder SharpUIApplication<T>(this MauiAppBuilder builder)
            where T : Application
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, SharpUIApplicationBuilder<T>>(_ => new SharpUIApplicationBuilder<T>()));
            return builder;
        }

        class SharpUIApplicationBuilder<T> : IMauiInitializeService
            where T : Application
        {
            public void Initialize(IServiceProvider services)
            {
                Application.Services = services;
#if DEBUG
                HotReload.InitSharpUIHotReload<T>();
#endif
            }
        }
    }
}

