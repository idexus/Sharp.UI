using System;
namespace Sharp.UI
{
	public static class INavigableElementExtension
	{
        public static T StyleClass<T>(this T obj,
           params string[] styleClasses)
            where T : INavigableElement
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.NavigableElement>(obj);
            if (styleClasses.Length > 0) mauiObject.StyleClass = (System.Collections.Generic.IList<string>)styleClasses.ToList<string>();
            return obj;
        }
    }
}
