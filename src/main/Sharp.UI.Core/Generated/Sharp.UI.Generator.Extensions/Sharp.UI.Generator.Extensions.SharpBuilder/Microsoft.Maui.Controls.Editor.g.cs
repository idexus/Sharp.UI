﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class EditorExtension
    {
        public static T AutoSize<T>(this T self,
            Microsoft.Maui.Controls.EditorAutoSizeOption autoSize)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.AutoSizeProperty, autoSize);
            return self;
        }
        
        public static T AutoSize<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.EditorAutoSizeOption>, IPropertyBuilder<Microsoft.Maui.Controls.EditorAutoSizeOption>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.EditorAutoSizeOption>(self, Microsoft.Maui.Controls.Editor.AutoSizeProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontAttributes<T>(this T self,
            Microsoft.Maui.Controls.FontAttributes fontAttributes)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.FontAttributesProperty, fontAttributes);
            return self;
        }
        
        public static T FontAttributes<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.FontAttributes>, IPropertyBuilder<Microsoft.Maui.Controls.FontAttributes>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.FontAttributes>(self, Microsoft.Maui.Controls.Editor.FontAttributesProperty);
            configure(context).Build();
            return self;
        }
        
        public static T IsTextPredictionEnabled<T>(this T self,
            bool isTextPredictionEnabled)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.IsTextPredictionEnabledProperty, isTextPredictionEnabled);
            return self;
        }
        
        public static T IsTextPredictionEnabled<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Editor.IsTextPredictionEnabledProperty);
            configure(context).Build();
            return self;
        }
        
        public static T CursorPosition<T>(this T self,
            int cursorPosition)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.CursorPositionProperty, cursorPosition);
            return self;
        }
        
        public static T CursorPosition<T>(this T self, Func<PropertyContext<int>, IPropertyBuilder<int>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<int>(self, Microsoft.Maui.Controls.Editor.CursorPositionProperty);
            configure(context).Build();
            return self;
        }
        
        public static T SelectionLength<T>(this T self,
            int selectionLength)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.SelectionLengthProperty, selectionLength);
            return self;
        }
        
        public static T SelectionLength<T>(this T self, Func<PropertyContext<int>, IPropertyBuilder<int>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<int>(self, Microsoft.Maui.Controls.Editor.SelectionLengthProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontFamily<T>(this T self,
            string fontFamily)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.FontFamilyProperty, fontFamily);
            return self;
        }
        
        public static T FontFamily<T>(this T self, Func<PropertyContext<string>, IPropertyBuilder<string>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<string>(self, Microsoft.Maui.Controls.Editor.FontFamilyProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontSize<T>(this T self,
            double fontSize)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.FontSizeProperty, fontSize);
            return self;
        }
        
        public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Editor.FontSizeProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateFontSizeTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Editor
        {
            double fromValue = self.FontSize;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.FontSize = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateFontSizeTo", transform, callback, length, easing);
        }
        
        public static T HorizontalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment horizontalTextAlignment)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, horizontalTextAlignment);
            return self;
        }
        
        public static T HorizontalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment verticalTextAlignment)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, verticalTextAlignment);
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontAutoScalingEnabled<T>(this T self,
            bool fontAutoScalingEnabled)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.FontAutoScalingEnabledProperty, fontAutoScalingEnabled);
            return self;
        }
        
        public static T FontAutoScalingEnabled<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Editor
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Editor.FontAutoScalingEnabledProperty);
            configure(context).Build();
            return self;
        }
        
        public static T OnCompleted<T>(this T self, System.EventHandler handler)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.Completed += handler;
            return self;
        }
        
        public static T OnCompleted<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.Completed += (o, arg) => action(self);
            return self;
        }
        

        public static T TextCenterHorizontal<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenterVertical<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenter<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextTop<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottom<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor, Microsoft.Maui.ITextAlignment
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextTopStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottomStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextTopEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextBottomEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Editor
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Editor.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        
    }
}

#pragma warning restore CS8601
#nullable restore