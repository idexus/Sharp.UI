using System;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.VisualElement),
        attachedProperties: new[] { "VisualStateManager.VisualStateGroups" },
        attachedPropertiesTypes: new[] { typeof(Microsoft.Maui.Controls.VisualStateGroupList) })]
	public static class IVisualElementExtension
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

