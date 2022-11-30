using System;

namespace Sharp.UI
{
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

        public static T VisualStateGroups<T>(this T obj, VisualStateGroupList visualStateGroups)
            where T : IVisualElement
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.VisualElement>(obj);
            mauiObject.SetValue(VisualStateManager.VisualStateGroupsProperty, visualStateGroups);
            return obj;
        }
    }
}

