using System;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.HotReload;

namespace Sharp.UI
{
    public static partial class SharpUIAppExtension
    {
        public static MauiAppBuilder SharpUIApp(this MauiAppBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, SharpUIApplicationBuilder>(_ => new SharpUIApplicationBuilder()));
            return builder;
        }

        class SharpUIApplicationBuilder : IMauiInitializeService
        {
            public void Initialize(IServiceProvider services)
            {
                Application.Services = services;
            }
        }
    }
}