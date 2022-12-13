using System;

namespace Sharp.UI
{
    [AttachedProperties(typeof(Microsoft.Maui.Controls.VisualStateManager))]
    public interface IVisualElementVisualStateGroupsAttachedProperties
    {
        Microsoft.Maui.Controls.VisualStateGroupList VisualStateGroups { get; set; }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.VisualElement))]
    [AttachedInterfaces(new[] {typeof(IVisualElementVisualStateGroupsAttachedProperties) })]
	public static class VisualElementExtension
    {
        public static T SizeRequest<T>(this T obj, double widthRequest, double heightRequest)
            where T : IVisualElement
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.VisualElement>(obj);
            mauiObject.WidthRequest = widthRequest;
            mauiObject.HeightRequest = heightRequest;
            return obj;
        }
    }
}