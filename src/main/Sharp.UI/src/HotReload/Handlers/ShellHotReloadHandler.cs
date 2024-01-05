namespace Sharp.UI
{
    internal class ShellHotReloadHandler : IHotReloadHandler
    {
        public bool ReplaceVisualElement(VisualElement oldElement, VisualElement newElement)
        {
            if (Shell.Current != null && 
                oldElement is ContentPage oldPage && 
                newElement is ContentPage newPage)
            {
                newPage.Title = oldPage.Title;
                newPage.IconImageSource = oldPage.IconImageSource;
                newPage.BackgroundImageSource = oldPage.BackgroundImageSource;
                newPage.Padding = oldPage.Padding;

                var parent = oldPage.Parent;
                if (parent is Microsoft.Maui.Controls.ShellContent shellContent)
                {
                    shellContent.ContentTemplate = null;
                    shellContent.Content = newPage;

                    if (newPage.Handler == null) newPage.Handler = oldPage.Handler;
                    if (newPage.Parent == null) newPage.Parent = parent;

                    return true;
                }
                else if (Shell.Current.Navigation.NavigationStack.Count > 0)
                {
                    Shell.Current.Navigation.InsertPageBefore(newPage, oldPage);
                    Shell.Current.Navigation.RemovePage(oldPage);

                    var route = Routing.GetRoute(oldPage);

                    Routing.UnRegisterRoute(route);
                    Routing.SetRoute(newPage, route);
                    Routing.RegisterRoute(route, newPage.GetType());

                    return true;
                }
            }
            return false;
        }
    }
}