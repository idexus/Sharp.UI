namespace Sharp.UI
{
    internal class TabbedPageHotReloadHandler : IHotReloadHandler
    {
        public bool ReplaceVisualElement(VisualElement oldElement, VisualElement newElement)
        {
            if (oldElement is ContentPage oldPage &&
                oldPage.Parent is TabbedPage tabbedPage &&
                newElement is ContentPage newPage)
            {
                newPage.Title = oldPage.Title;
                newPage.IconImageSource = oldPage.IconImageSource;
                newPage.BackgroundImageSource = oldPage.BackgroundImageSource;
                newPage.Padding = oldPage.Padding;

                int selectedId = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);

                int id = tabbedPage.Children.IndexOf(oldPage);
                tabbedPage.Children[id] = newPage;

                if (newPage.Handler == null) newPage.Handler = oldPage.Handler;
                if (newPage.Parent == null) newPage.Parent = oldPage.Parent;

                tabbedPage.CurrentPage = tabbedPage.Children[selectedId];

                return true;
            }
            return false;
        }
    }
}