﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class EntryExtension
    {
        public static T HorizontalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment horizontalTextAlignment)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, horizontalTextAlignment);
            return self;
        }
        
        public static T HorizontalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment verticalTextAlignment)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, verticalTextAlignment);
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T IsPassword<T>(this T self,
            bool isPassword)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.IsPasswordProperty, isPassword);
            return self;
        }
        
        public static T IsPassword<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Entry.IsPasswordProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontAttributes<T>(this T self,
            Microsoft.Maui.Controls.FontAttributes fontAttributes)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.FontAttributesProperty, fontAttributes);
            return self;
        }
        
        public static T FontAttributes<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.FontAttributes>, IPropertyBuilder<Microsoft.Maui.Controls.FontAttributes>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.FontAttributes>(self, Microsoft.Maui.Controls.Entry.FontAttributesProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontFamily<T>(this T self,
            string fontFamily)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.FontFamilyProperty, fontFamily);
            return self;
        }
        
        public static T FontFamily<T>(this T self, Func<PropertyContext<string>, IPropertyBuilder<string>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<string>(self, Microsoft.Maui.Controls.Entry.FontFamilyProperty);
            configure(context).Build();
            return self;
        }
        
        public static T FontSize<T>(this T self,
            double fontSize)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.FontSizeProperty, fontSize);
            return self;
        }
        
        public static T FontSize<T>(this T self, Func<PropertyContext<double>, IPropertyBuilder<double>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<double>(self, Microsoft.Maui.Controls.Entry.FontSizeProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateFontSizeTo<T>(this T self, double value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.Entry
        {
            double fromValue = self.FontSize;
            var transform = (double t) => Transformations.DoubleTransform(fromValue, value, t);
            var callback = (double actValue) => { self.FontSize = actValue; };
            return Transformations.AnimateAsync<double>(self, "AnimateFontSizeTo", transform, callback, length, easing);
        }
        
        public static T FontAutoScalingEnabled<T>(this T self,
            bool fontAutoScalingEnabled)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.FontAutoScalingEnabledProperty, fontAutoScalingEnabled);
            return self;
        }
        
        public static T FontAutoScalingEnabled<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Entry.FontAutoScalingEnabledProperty);
            configure(context).Build();
            return self;
        }
        
        public static T IsTextPredictionEnabled<T>(this T self,
            bool isTextPredictionEnabled)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.IsTextPredictionEnabledProperty, isTextPredictionEnabled);
            return self;
        }
        
        public static T IsTextPredictionEnabled<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Entry.IsTextPredictionEnabledProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ReturnType<T>(this T self,
            Microsoft.Maui.ReturnType returnType)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.ReturnTypeProperty, returnType);
            return self;
        }
        
        public static T ReturnType<T>(this T self, Func<PropertyContext<Microsoft.Maui.ReturnType>, IPropertyBuilder<Microsoft.Maui.ReturnType>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.ReturnType>(self, Microsoft.Maui.Controls.Entry.ReturnTypeProperty);
            configure(context).Build();
            return self;
        }
        
        public static T CursorPosition<T>(this T self,
            int cursorPosition)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.CursorPositionProperty, cursorPosition);
            return self;
        }
        
        public static T CursorPosition<T>(this T self, Func<PropertyContext<int>, IPropertyBuilder<int>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<int>(self, Microsoft.Maui.Controls.Entry.CursorPositionProperty);
            configure(context).Build();
            return self;
        }
        
        public static T SelectionLength<T>(this T self,
            int selectionLength)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.SelectionLengthProperty, selectionLength);
            return self;
        }
        
        public static T SelectionLength<T>(this T self, Func<PropertyContext<int>, IPropertyBuilder<int>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<int>(self, Microsoft.Maui.Controls.Entry.SelectionLengthProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ReturnCommand<T>(this T self,
            System.Windows.Input.ICommand returnCommand)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.ReturnCommandProperty, returnCommand);
            return self;
        }
        
        public static T ReturnCommand<T>(this T self, Func<PropertyContext<System.Windows.Input.ICommand>, IPropertyBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<System.Windows.Input.ICommand>(self, Microsoft.Maui.Controls.Entry.ReturnCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ReturnCommandParameter<T>(this T self,
            object returnCommandParameter)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.ReturnCommandParameterProperty, returnCommandParameter);
            return self;
        }
        
        public static T ReturnCommandParameter<T>(this T self, Func<PropertyContext<object>, IPropertyBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<object>(self, Microsoft.Maui.Controls.Entry.ReturnCommandParameterProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ClearButtonVisibility<T>(this T self,
            Microsoft.Maui.ClearButtonVisibility clearButtonVisibility)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.ClearButtonVisibilityProperty, clearButtonVisibility);
            return self;
        }
        
        public static T ClearButtonVisibility<T>(this T self, Func<PropertyContext<Microsoft.Maui.ClearButtonVisibility>, IPropertyBuilder<Microsoft.Maui.ClearButtonVisibility>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.ClearButtonVisibility>(self, Microsoft.Maui.Controls.Entry.ClearButtonVisibilityProperty);
            configure(context).Build();
            return self;
        }
        
        public static T OnCompleted<T>(this T self, System.EventHandler handler)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.Completed += handler;
            return self;
        }
        
        public static T OnCompleted<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.Completed += (o, arg) => action(self);
            return self;
        }
        

        public static T TextCenterHorizontal<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenterVertical<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenter<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextTop<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottom<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry, Microsoft.Maui.ITextAlignment
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextTopStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottomStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextTopEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextBottomEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        
    }
}

#pragma warning restore CS8601
#nullable restore