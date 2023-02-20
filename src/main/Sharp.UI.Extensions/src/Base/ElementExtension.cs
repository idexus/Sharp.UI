namespace Sharp.UI
{
    public static partial class ElementExtension
    {
        public static T ContextFlyout<T>(this T obj, MenuFlyout contextFlyout) where T : Element
        {
            obj.SetValue(FlyoutBase.ContextFlyoutProperty, contextFlyout);
            return obj;
        }
    }
}

