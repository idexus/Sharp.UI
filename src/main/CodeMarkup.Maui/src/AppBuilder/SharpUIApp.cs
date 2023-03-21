using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.HotReload;

namespace CodeMarkup.Maui
{
    public static partial class CodeMarkupAppExtension
	{
        public static MauiAppBuilder CodeMarkupApp<T>(this MauiAppBuilder builder, 
            //HotReloadType HotReloadType = HotReloadType.None,
            IPAddress[] IdeIPs = null)
            where T : Application
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IMauiInitializeService, CodeMarkupApplicationBuilder<T>>(_ => new CodeMarkupApplicationBuilder<T> { HotReloadType = HotReloadType.HotReloadKit, IdeIPs = IdeIPs }));
            return builder;
        }

        class CodeMarkupApplicationBuilder<T> : IMauiInitializeService
            where T : Application
        {
            public HotReloadType HotReloadType;
            public IPAddress[] IdeIPs;
            
            public void Initialize(IServiceProvider services)
            {
                Application.Services = services;
                switch (HotReloadType)
                {
                    case HotReloadType.HotReloadKit:
                        if (IdeIPs.Count() > 0)
                        {
                            HotReload.InitHotReload();
                            HotReload.InitHotReloadKit<T>(IdeIPs);
                        }
                        break;
                    case HotReloadType.UserDefined:
                        HotReload.InitHotReload();
                        break;
                }                
            }
        }
    }
}