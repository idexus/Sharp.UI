using Microsoft.Maui.HotReload;

namespace Sharp.UI
{
    public static class HotReload
    {
        static List<Type> replaceWithTypeList = new List<Type>();
        static List<Element> registeredActiveList = new List<Element>();

        public static void UpdateApplication(Type[] types)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                foreach (var type in types)
                    HotReload.replaceWithTypeList.Add(type);
            });
            TriggerHotReload();
        }

        public static void RegisterActive(Element element)
        {
            registeredActiveList.Add(element);
        }

        public static void ReplaceWithType(Type type)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                replaceWithTypeList.Add(type);
            });
        }

        public static void TriggerHotReload()
        {
            MainThread.BeginInvokeOnMainThread(() => {
                try
                {
                    foreach(var toReloadType in replaceWithTypeList)
                    {
                        var activeObjectList = registeredActiveList.Where(e => e.GetType().FullName == toReloadType.FullName).ToList();

                        foreach(var activeObject in activeObjectList)
                        {
                            try
                            {
                                registeredActiveList.Remove(activeObject);
                                var bindingContext = activeObject.BindingContext;

                                // reload
                                var newObject = toReloadType.GetConstructors().Where(e => e.GetParameters().Count() == 0).FirstOrDefault().Invoke(null);                                
                                var parent = activeObject.Parent;
                                if (newObject is ContentPage newContentPage)
                                {
                                    if (activeObject is ContentPage oldContentPage)
                                    {
                                        if (oldContentPage != newContentPage)
                                        {
                                            newContentPage.BindingContext = bindingContext;
                                            if (parent is Window parentWindow) parentWindow.Page = newContentPage;
                                            else if (parent is ShellContent parentShellContent)
                                            {
                                                var shellSection = parentShellContent.Parent as ShellSection;
                                                var id = shellSection.Items.IndexOf(parentShellContent);
                                                var newContent = new ShellContent().Content(newContentPage);
                                                newContentPage.SetValue(Shell.PresentationModeProperty, oldContentPage.GetValue(Shell.PresentationModeProperty));
                                                shellSection.Items[id] = newContent;
                                            }
                                        }
                                    }
                                }
                                else if (newObject is View newView)
                                {
                                    if (activeObject is View oldView)
                                    {
                                        if (oldView != newView)
                                        {
                                            newView.BindingContext = bindingContext;
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
                            }
                            catch (Exception ex)
                            {                            
                                Console.Write(ex.Message);
                            }
                        }
                    }
                }
                finally
                {
                    replaceWithTypeList.Clear();
                }
            });
        }
    }
}