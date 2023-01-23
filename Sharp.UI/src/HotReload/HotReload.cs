using System.IO.Pipes;
using System.Reflection;
using Microsoft.Maui.HotReload;
using System.Text.Json;

namespace Sharp.UI
{
    class HotReloadData
    {
        public string DllFileName { get; set; }
        public string[] TypeNames { get; set; }
    }

    public static class HotReload
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
        public static void InitSharpUIHotReload()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("sharpuipipe", PipeDirection.In))
                        {
                            await pipeServer.WaitForConnectionAsync();

                            var streamReader = new StreamReader(pipeServer);
                            var jsonData = await streamReader.ReadLineAsync();

                            var hotReloadData = JsonSerializer.Deserialize<HotReloadData>(jsonData);

                            var assembly = Assembly.LoadFile($"{hotReloadData.DllFileName}.dll");

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
                    await Task.Delay(1000);
                }
            });
        }

        internal static object BindingContext = null;

        static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public static void TriggerHotReload()
        {            
            MainThread.BeginInvokeOnMainThread(async () =>
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
                                var newObject = toReloadType.GetConstructors().Where(e => e.GetParameters().Count() == 0).FirstOrDefault().Invoke(null);

                                var parent = activeObject.Parent;
                                if (newObject is ContentPage newContentPage && activeObject is ContentPage oldContentPage)
                                {
                                    if (oldContentPage != newContentPage)
                                    {
                                        if (parent is Window parentWindow) parentWindow.Page = newContentPage;
                                        else if (parent is ShellContent oldShellContent)
                                        {
                                            var shellSection = oldShellContent.Parent as ShellSection;
                                            var id = shellSection.Items.IndexOf(oldShellContent);
                                            var newShellContent = new ShellContent();
                                            newShellContent.Content = newContentPage;
                                            newShellContent.Title = oldShellContent.Title;
                                            shellSection.Items[id] = newShellContent;
                                            shellSection.CurrentItem = newShellContent;

                                            await Shell.Current.GoToAsync($"///{shellSection.Items[id].Route}", false);
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
                catch
                {

                }

                replaceWithTypeList.Clear();
            });
        }
    }
}