﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.Builder
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
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, horizontalTextAlignment);
            return self;
        }
        
        public static T HorizontalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> HorizontalTextAlignment<T>(this SettersContext<T> self,
            Microsoft.Maui.TextAlignment horizontalTextAlignment)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, Value = horizontalTextAlignment });
            return self;
        }
        
        public static SettersContext<T> HorizontalTextAlignment<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.TextAlignment>, IPropertySettersBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<Microsoft.Maui.TextAlignment>(self.XamlSetters, Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self,
            Microsoft.Maui.TextAlignment verticalTextAlignment)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, verticalTextAlignment);
            return self;
        }
        
        public static T VerticalTextAlignment<T>(this T self, Func<PropertyContext<Microsoft.Maui.TextAlignment>, IPropertyBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.TextAlignment>(self, Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> VerticalTextAlignment<T>(this SettersContext<T> self,
            Microsoft.Maui.TextAlignment verticalTextAlignment)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, Value = verticalTextAlignment });
            return self;
        }
        
        public static SettersContext<T> VerticalTextAlignment<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.TextAlignment>, IPropertySettersBuilder<Microsoft.Maui.TextAlignment>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<Microsoft.Maui.TextAlignment>(self.XamlSetters, Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty);
            configure(context).Build();
            return self;
        }
        
        public static T IsPassword<T>(this T self,
            bool isPassword)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.IsPasswordProperty, isPassword);
            return self;
        }
        
        public static T IsPassword<T>(this T self, Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<bool>(self, Microsoft.Maui.Controls.Entry.IsPasswordProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> IsPassword<T>(this SettersContext<T> self,
            bool isPassword)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.IsPasswordProperty, Value = isPassword });
            return self;
        }
        
        public static SettersContext<T> IsPassword<T>(this SettersContext<T> self, Func<PropertySettersContext<bool>, IPropertySettersBuilder<bool>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<bool>(self.XamlSetters, Microsoft.Maui.Controls.Entry.IsPasswordProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ReturnType<T>(this T self,
            Microsoft.Maui.ReturnType returnType)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.ReturnTypeProperty, returnType);
            return self;
        }
        
        public static T ReturnType<T>(this T self, Func<PropertyContext<Microsoft.Maui.ReturnType>, IPropertyBuilder<Microsoft.Maui.ReturnType>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.ReturnType>(self, Microsoft.Maui.Controls.Entry.ReturnTypeProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> ReturnType<T>(this SettersContext<T> self,
            Microsoft.Maui.ReturnType returnType)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.ReturnTypeProperty, Value = returnType });
            return self;
        }
        
        public static SettersContext<T> ReturnType<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.ReturnType>, IPropertySettersBuilder<Microsoft.Maui.ReturnType>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<Microsoft.Maui.ReturnType>(self.XamlSetters, Microsoft.Maui.Controls.Entry.ReturnTypeProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ReturnCommand<T>(this T self,
            System.Windows.Input.ICommand returnCommand)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.ReturnCommandProperty, returnCommand);
            return self;
        }
        
        public static T ReturnCommand<T>(this T self, Func<PropertyContext<System.Windows.Input.ICommand>, IPropertyBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<System.Windows.Input.ICommand>(self, Microsoft.Maui.Controls.Entry.ReturnCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> ReturnCommand<T>(this SettersContext<T> self,
            System.Windows.Input.ICommand returnCommand)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.ReturnCommandProperty, Value = returnCommand });
            return self;
        }
        
        public static SettersContext<T> ReturnCommand<T>(this SettersContext<T> self, Func<PropertySettersContext<System.Windows.Input.ICommand>, IPropertySettersBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<System.Windows.Input.ICommand>(self.XamlSetters, Microsoft.Maui.Controls.Entry.ReturnCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ReturnCommandParameter<T>(this T self,
            object returnCommandParameter)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.ReturnCommandParameterProperty, returnCommandParameter);
            return self;
        }
        
        public static T ReturnCommandParameter<T>(this T self, Func<PropertyContext<object>, IPropertyBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<object>(self, Microsoft.Maui.Controls.Entry.ReturnCommandParameterProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> ReturnCommandParameter<T>(this SettersContext<T> self,
            object returnCommandParameter)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.ReturnCommandParameterProperty, Value = returnCommandParameter });
            return self;
        }
        
        public static SettersContext<T> ReturnCommandParameter<T>(this SettersContext<T> self, Func<PropertySettersContext<object>, IPropertySettersBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<object>(self.XamlSetters, Microsoft.Maui.Controls.Entry.ReturnCommandParameterProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ClearButtonVisibility<T>(this T self,
            Microsoft.Maui.ClearButtonVisibility clearButtonVisibility)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.ClearButtonVisibilityProperty, clearButtonVisibility);
            return self;
        }
        
        public static T ClearButtonVisibility<T>(this T self, Func<PropertyContext<Microsoft.Maui.ClearButtonVisibility>, IPropertyBuilder<Microsoft.Maui.ClearButtonVisibility>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertyContext<Microsoft.Maui.ClearButtonVisibility>(self, Microsoft.Maui.Controls.Entry.ClearButtonVisibilityProperty);
            configure(context).Build();
            return self;
        }
        
        public static SettersContext<T> ClearButtonVisibility<T>(this SettersContext<T> self,
            Microsoft.Maui.ClearButtonVisibility clearButtonVisibility)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.XamlSetters.Add(new Setter { Property = Microsoft.Maui.Controls.Entry.ClearButtonVisibilityProperty, Value = clearButtonVisibility });
            return self;
        }
        
        public static SettersContext<T> ClearButtonVisibility<T>(this SettersContext<T> self, Func<PropertySettersContext<Microsoft.Maui.ClearButtonVisibility>, IPropertySettersBuilder<Microsoft.Maui.ClearButtonVisibility>> configure)
            where T : Microsoft.Maui.Controls.Entry
        {
            var context = new PropertySettersContext<Microsoft.Maui.ClearButtonVisibility>(self.XamlSetters, Microsoft.Maui.Controls.Entry.ClearButtonVisibilityProperty);
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
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenterVertical<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextCenter<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Center);
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Center);
            return self;
        }

        public static T TextTop<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottom<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry, Microsoft.Maui.ITextAlignment
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextTopStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextBottomStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextTopEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.Start);
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextBottomEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.VerticalTextAlignmentProperty, TextAlignment.End);
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        public static T TextStart<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.Start);
            return self;
        }

        public static T TextEnd<T>(this T self)
            where T : Microsoft.Maui.Controls.Entry
        {
            self.SetValue(Microsoft.Maui.Controls.Entry.HorizontalTextAlignmentProperty, TextAlignment.End);
            return self;
        }

        
    }
}

#pragma warning restore CS8601
#nullable restore