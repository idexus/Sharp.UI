namespace Sharp.UI
{
	public static class IElementExtension
	{
        public static T ContextFlyout<T>(this T obj,
            Microsoft.Maui.Controls.MenuFlyout menuFlyout)
            where T : IElement
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Element>(obj);
            mauiObject.SetValue(FlyoutBase.ContextFlyoutProperty, menuFlyout);
            return obj;
        }
    }
}

