namespace Sharp.UI
{
    internal class NavigationPageHotReloadHandler : IHotReloadHandler
    {
        public bool ReplaceVisualElement(VisualElement oldElement, VisualElement newElement)
        {
            if (oldElement is ContentPage oldPage &&
                oldPage.Parent is NavigationPage navigation &&                
                newElement is ContentPage newPage)
            {
                newPage.Title = oldPage.Title;
                newPage.IconImageSource = oldPage.IconImageSource;
                newPage.BackgroundImageSource = oldPage.BackgroundImageSource;
                newPage.Padding = oldPage.Padding;

                navigation.Navigation.InsertPageBefore(newPage, oldPage);
                navigation.Navigation.RemovePage(oldPage);

                return true;
            }
            return false;
        }
    }
}