namespace Sharp.UI
{
    internal class FlyoutPageHotReloadHandler : IHotReloadHandler
    {
        public bool ReplaceVisualElement(VisualElement oldElement, VisualElement newElement)
        {
            if (oldElement is ContentPage oldPage &&
                oldPage.Parent is FlyoutPage flyoutPage &&
                newElement is ContentPage newPage)
            {
                newPage.Title = oldPage.Title;
                newPage.IconImageSource = oldPage.IconImageSource;
                newPage.BackgroundImageSource = oldPage.BackgroundImageSource;
                newPage.Padding = oldPage.Padding;

                if (flyoutPage.Detail == oldPage)
                    flyoutPage.Detail = newPage;
                else if (flyoutPage.Flyout == oldPage)
                    flyoutPage.Flyout = newPage;
                
                return true;
            }
            return false;
        }
    }
}