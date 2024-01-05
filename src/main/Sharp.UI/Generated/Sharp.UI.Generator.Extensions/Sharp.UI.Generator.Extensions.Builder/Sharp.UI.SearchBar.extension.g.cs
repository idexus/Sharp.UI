﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.Builder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    using Sharp.UI;
    
    public static partial class SearchBarExtension
    {

        public static T TextCenterHorizontal<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenterVertical<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenter<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextTop<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottom<T>(this T self)
            where T : Sharp.UI.SearchBar, Microsoft.Maui.ITextAlignment
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextTopStart<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottomStart<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextTopEnd<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextBottomEnd<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextStart<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextEnd<T>(this T self)
            where T : Sharp.UI.SearchBar
        {
            self.SetValue(Sharp.UI.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        
    }
}

#pragma warning restore CS8601
#nullable restore
