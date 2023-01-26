using System.IO.Pipes;
using System.Reflection;
using Microsoft.Maui.HotReload;
using System.Text.Json;

namespace Sharp.UI
{
    public class HotReloadData
    {
        public string[] TypeNames { get; set; }
        public byte[] AssemblyData { get; set; }
        public byte[] PdbData { get; set; }
    }

    public static partial class HotReload
    {
        // views and pages

        static List<Type> replaceWithTypeList = new List<Type>();
        static List<Element> registeredActiveList = new List<Element>();

        public static void RegisterActive(Element element)
        {
            registeredActiveList.Add(element);
        }

        public static void UpdateApplication(Type[] types)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var type in types)
                    HotReload.replaceWithTypeList.Add(type);
            });
            TriggerHotReload();
        }

        public static void ReplaceWithType(Type type)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                replaceWithTypeList.Add(type);
            });
        }

        // Sharp.UI hot reload
        internal static void InitSharpUIHotReload<T>()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var pipeName = typeof(T).GetTypeInfo().Assembly.GetName().Name;

                        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.In))
                        {
                            await pipeServer.WaitForConnectionAsync();

                            var streamReader = new StreamReader(pipeServer);
                            var jsonData = await streamReader.ReadLineAsync();

                            var hotReloadData = JsonSerializer.Deserialize<HotReloadData>(jsonData);

                            var assembly = Assembly.Load(hotReloadData.AssemblyData, hotReloadData.PdbData);

                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                foreach (var typeName in hotReloadData.TypeNames)
                                {
                                    var type = assembly.GetType(typeName);
                                    HotReload.replaceWithTypeList.Add(type);
                                }
                            });

                            TriggerHotReload();
                        }
                    }
                    catch { }
                }
            });
        }

        internal static object BindingContext = null;
        public static void TriggerHotReload()
        {            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    foreach (var toReloadType in replaceWithTypeList)
                    {
                        var activeObjectList = registeredActiveList.Where(e => e.GetType().FullName == toReloadType.FullName).ToList();

                        foreach (var activeObject in activeObjectList)
                        {
                            try
                            {
                                registeredActiveList.Remove(activeObject);

                                // reload binding context
                                BindingContext = activeObject.BindingContext;

                                var newObject = ActivatorUtilities.GetServiceOrCreateInstance(Application.Services, toReloadType);

                                var parent = activeObject.Parent;
                                if (newObject is ContentPage newContentPage && activeObject is ContentPage oldContentPage)
                                {
                                    if (oldContentPage != newContentPage)
                                    {
                                        if (parent is Window parentWindow) parentWindow.Page = newContentPage;
                                        else if (parent is ShellContent shellContent)
                                        {
                                            shellContent.ContentTemplate = null;
                                            shellContent.Content = newContentPage;
                                            if (newContentPage.Handler == null) newContentPage.Handler = oldContentPage.Handler;
                                        }
                                    }
                                }
                                else if (newObject is ContentView newView && activeObject is ContentView oldView)
                                {
                                    if (oldView != newView)
                                    {
                                        if (parent is Layout parentLayout)
                                        {
                                            var id = parentLayout.IndexOf(oldView);
                                            parentLayout.Children[id] = newView;
                                        }
                                        else if (parent is ContentView parentContentView) parentContentView.Content = newView;
                                        else if (parent is ScrollView parentScrollView) parentScrollView.Content = newView;
                                        else if (parent is ContentPage parentContentPage) parentContentPage.Content = newView;
                                        else if (parent is Border parentBorder) parentBorder.Content = newView;
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
                catch { }
                replaceWithTypeList.Clear();
            });
        }
    }
}