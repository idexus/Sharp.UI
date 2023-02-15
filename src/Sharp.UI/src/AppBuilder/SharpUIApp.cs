using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.HotReload;

namespace Sharp.UI
{
	public static partial class SharpUIAppExtension
	{
        public static MauiAppBuilder SharpUIApplication<T>(this MauiAppBuilder builder, IPAddress[] IdeIPs)
            where T : Application
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, SharpUIApplicationBuilder<T>>(_ => new SharpUIApplicationBuilder<T> { IdeIPs = IdeIPs }));
            return builder;
        }

        class SharpUIApplicationBuilder<T> : IMauiInitializeService
            where T : Application
        {
            public IPAddress[] IdeIPs;

            public void Initialize(IServiceProvider services)
            {
                Application.Services = services;
                HotReload.InitSharpUIHotReload<T>(IdeIPs);
            }
        }
    }
}

