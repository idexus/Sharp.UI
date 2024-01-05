using System.IO.Pipes;
using System.Reflection;
using Microsoft.Maui.HotReload;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using HotReloadKit;
using System.Diagnostics;
using Microsoft.Maui.Graphics;

namespace Sharp.UI
{
    public static partial class HotReload
    {
        class HotReloadToken
        {
            public string Token { get; set; }
        }

        class HotReloadRequest
        {
            public string[] TypeNames { get; set; }
        }

        class HotReloadData
        {
            public string[] TypeNames { get; set; }
            public byte[] AssemblyData { get; set; }
            public byte[] PdbData { get; set; }
        }

        // --------- public -----------

        public static List<IHotReloadHandler> Handlers { get; } = new List<IHotReloadHandler>();
        public static bool IsEnabled { get; private set; } = false;

        public static void UpdateApplication(Type[] types)
        {
            if (IsEnabled)
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var type in types)
                        ReplacedTypesDict[type.FullName] = type;
                    InvokeHotReload();
                });
        }

        public static void ReplaceWithType(Type type)
        {
            if (IsEnabled)
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ReplacedTypesDict[type.FullName] = type;
                });
        }

        public static void TriggerHotReload()
        {
            if (IsEnabled)
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    InvokeHotReload();
                });
        }

        // ------------ internal/private -----------

        static List<VisualElement> registeredActiveVisualElements = new List<VisualElement>();
        internal static Dictionary<string, Type> ReplacedTypesDict = new Dictionary<string, Type>();

        internal static void RegisterActive(VisualElement visualElement)
        {

            if (registeredActiveVisualElements.Contains(visualElement)) return;
            registeredActiveVisualElements.Add(visualElement);
        }

        internal static void UnregisterActive(VisualElement visualElement)
        {
            registeredActiveVisualElements.Remove(visualElement);
        }

        public static ValueTask WriteAsync<T>(this NetworkStream stream, T obj, CancellationToken cancellationToken = default)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            jsonString += "\0";
            var messageBytes = Encoding.UTF8.GetBytes(jsonString);
            return stream.WriteAsync(messageBytes, cancellationToken);
        }

        internal static void InitHotReload()
        {
            IsEnabled = true;
            Handlers.Add(new ShellHotReloadHandler());
            Handlers.Add(new NavigationPageHotReloadHandler());
            Handlers.Add(new TabbedPageHotReloadHandler());
            Handlers.Add(new SinglePageHotReloadHandler());
            Handlers.Add(new FlyoutPageHotReloadHandler());
        }
        
        internal static void InitHotReloadKit<T>(IPAddress[] IdeIPs)
        {
            var platformName = DeviceInfo.Platform switch
            {
                var t when t == Microsoft.Maui.Devices.DevicePlatform.iOS => "ios",
                var t when t == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst => "maccatalyst",
                var t when t == Microsoft.Maui.Devices.DevicePlatform.Android => "android",
                var t when t == Microsoft.Maui.Devices.DevicePlatform.WinUI => "windows",
                var t when t == Microsoft.Maui.Devices.DevicePlatform.Tizen => "tizen",
                _ => "",
            };
            HotReloader.Init<T>(IdeIPs, platformName: platformName);
            HotReloader.RequestAdditionalTypes = () => registeredActiveVisualElements.Select(e => e.GetType().FullName).ToArray();
            HotReloader.UpdateApplication = UpdateApplication;
        }

        internal static object BindingContext = null;
        static void InvokeHotReload()
        {
            try
            {
                foreach (var toReloadTypeName in ReplacedTypesDict.Keys)
                {
                    var activeVisualElementsForRequestedName = registeredActiveVisualElements.Where(e => e.GetType().FullName == toReloadTypeName).ToList();
                    foreach (var oldVisualElement in activeVisualElementsForRequestedName)
                    {
                        // check if visual element type changed
                        var typeToReload = ReplacedTypesDict[toReloadTypeName];
                        if (oldVisualElement.GetType() != typeToReload)
                        {
                            try
                            {
                                var newObject = ActivatorUtilities.GetServiceOrCreateInstance(Application.Services, typeToReload);
                                if (newObject is VisualElement newVisualElement)
                                {
                                    BindingContext = oldVisualElement.BindingContext;

                                    bool replaced = false;
                                    foreach (var handler in Handlers)
                                    {
                                        replaced = handler.ReplaceVisualElement(oldVisualElement, newVisualElement);
                                        if (replaced) break;
                                    }
                                    
                                    if (replaced)
                                    {
                                        RegisterActive(newVisualElement);
                                        UnregisterActive(oldVisualElement);
                                    }
                                }
                            }
                            finally
                            {
                                BindingContext = null;
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}