﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.Builder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class SearchBarExtension
    {
        public static T CancelButtonColor<T>(this T self,
            Microsoft.Maui.Graphics.Color cancelButtonColor)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.CancelButtonColorProperty, cancelButtonColor);
            return self;
        }
        
        public static T CancelButtonColor<T>(this T self, Func<PropertyContext<Microsoft.Maui.Graphics.Color>, IPropertyBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertyContext<Microsoft.Maui.Graphics.Color>(self, Microsoft.Maui.Controls.SearchBar.CancelButtonColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> CancelButtonColor<T>(this SettersContext<T> self,
            Microsoft.Maui.Graphics.Color cancelButtonColor)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.SearchBar.CancelButtonColorProperty, Value = cancelButtonColor });
            return self;
        }
        
        public static SettersContext<T> CancelButtonColor<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.Graphics.Color>, IPropertySettersBuilder<Microsoft.Maui.Graphics.Color>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertySettersContext<Microsoft.Maui.Graphics.Color>(self.XamlSetters, Microsoft.Maui.Controls.SearchBar.CancelButtonColorProperty);
            configure(context).Build();
            return self;
        }
        
        public static Task<bool> AnimateCancelButtonColorTo<T>(this T self, Microsoft.Maui.Graphics.Color value, uint length = 250, Easing? easing = null)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            Microsoft.Maui.Graphics.Color fromValue = self.CancelButtonColor;
            var transform = (double t) => Transformations.ColorTransform(fromValue, value, t);
            var callback = (Microsoft.Maui.Graphics.Color actValue) => { self.CancelButtonColor = actValue; };
            return Transformations.AnimateAsync<Microsoft.Maui.Graphics.Color>(self, "AnimateCancelButtonColorTo", transform, callback, length, easing);
        }
        
        public static T HorizontalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment horizontalTextAlignment)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, horizontalTextAlignment);
            return self;
        }
        
        public static T HorizontalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> HorizontalTextAlignment<T>(this SettersContext<T> self,
            Microsoft.Maui.TextAlignment horizontalTextAlignment)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, Value = horizontalTextAlignment });
            return self;
        }
        
        public static SettersContext<T> HorizontalTextAlignment<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.TextAlignment>, IPropertySettersBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertySettersContext<Microsoft.Maui.TextAlignment>(self.XamlSetters, Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment verticalTextAlignment)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, verticalTextAlignment);
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> VerticalTextAlignment<T>(this SettersContext<T> self,
            Microsoft.Maui.TextAlignment verticalTextAlignment)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, Value = verticalTextAlignment });
            return self;
        }
        
        public static SettersContext<T> VerticalTextAlignment<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.TextAlignment>, IPropertySettersBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertySettersContext<Microsoft.Maui.TextAlignment>(self.XamlSetters, Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T SearchCommand<T>(this T self,
            System.Windows.Input.ICommand searchCommand)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.SearchCommandProperty, searchCommand);
            return self;
        }
        
        public static T SearchCommand<T>(this T self, Func<PropertyContext<System.Windows.Input.ICommand>, IPropertyBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertyContext<System.Windows.Input.ICommand>(self, Microsoft.Maui.Controls.SearchBar.SearchCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> SearchCommand<T>(this SettersContext<T> self,
            System.Windows.Input.ICommand searchCommand)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.SearchBar.SearchCommandProperty, Value = searchCommand });
            return self;
        }
        
        public static SettersContext<T> SearchCommand<T>(this SettersContext<T> self, Func<PropertySettersContext<System.Windows.Input.ICommand>, IPropertySettersBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertySettersContext<System.Windows.Input.ICommand>(self.XamlSetters, Microsoft.Maui.Controls.SearchBar.SearchCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static T SearchCommandParameter<T>(this T self,
            object searchCommandParameter)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.SearchCommandParameterProperty, searchCommandParameter);
            return self;
        }
        
        public static T SearchCommandParameter<T>(this T self, Func<PropertyContext<object>, IPropertyBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertyContext<object>(self, Microsoft.Maui.Controls.SearchBar.SearchCommandParameterProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> SearchCommandParameter<T>(this SettersContext<T> self,
            object searchCommandParameter)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.SearchBar.SearchCommandParameterProperty, Value = searchCommandParameter });
            return self;
        }
        
        public static SettersContext<T> SearchCommandParameter<T>(this SettersContext<T> self, Func<PropertySettersContext<object>, IPropertySettersBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            var context = new PropertySettersContext<object>(self.XamlSetters, Microsoft.Maui.Controls.SearchBar.SearchCommandParameterProperty);
            configure(context).Build();
            return self;
        }
        
        public static T OnSearchButtonPressed<T>(this T self, System.EventHandler handler)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SearchButtonPressed += handler;
            return self;
        }
        
        public static T OnSearchButtonPressed<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SearchButtonPressed += (o, arg) => action(self);
            return self;
        }
        

        public static T TextCenterHorizontal<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenterVertical<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenter<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextTop<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottom<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar, Microsoft.Maui.ITextAlignment
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextTopStart<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottomStart<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextTopEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextBottomEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextStart<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.SearchBar
        {
            self.SetValue(Microsoft.Maui.Controls.SearchBar.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        
    }
}

#pragma warning restore CS8601
#nullable restore
