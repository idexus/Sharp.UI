using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.HotReload;

namespace Sharp.UI
{
	public static partial class HotReload
	{
        public static MauiAppBuilder EnableSharpUIHotReload<T>(this MauiAppBuilder builder)
            where T : Application
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, SharpUIHotReloadBuilder<T>>(_ => new SharpUIHotReloadBuilder<T>()));
            return builder;
        }

        class SharpUIHotReloadBuilder<T> : IMauiInitializeService
            where T : Application
        {
            public void Initialize(IServiceProvider services)
            {
                HotReload.InitSharpUIHotReload<T>(services);
            }
        }
    }
}

