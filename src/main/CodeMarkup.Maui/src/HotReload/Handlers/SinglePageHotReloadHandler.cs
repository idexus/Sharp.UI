namespace CodeMarkup.Maui
{
    internal class SinglePageHotReloadHandler : IHotReloadHandler
    {
        public bool ReplaceVisualElement(VisualElement oldElement, VisualElement newElement)
        {
            if (oldElement is ContentPage oldPage &&
                oldPage.Parent is Window parentWindow &&
                newElement is ContentPage newPage)
            {
                newPage.Title = oldPage.Title;
                newPage.IconImageSource = oldPage.IconImageSource;
                newPage.BackgroundImageSource = oldPage.BackgroundImageSource;
                newPage.Padding = oldPage.Padding;

                parentWindow.Page = newPage;

                return true;
            }
            return false;
        }
    }
}