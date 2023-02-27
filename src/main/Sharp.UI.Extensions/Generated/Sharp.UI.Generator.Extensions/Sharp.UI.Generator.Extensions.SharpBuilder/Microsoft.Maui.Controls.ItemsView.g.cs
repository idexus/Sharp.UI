﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class ItemsViewExtension
    {
        public static T EmptyView<T>(this T self,
            object emptyView)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.EmptyViewProperty, emptyView);
            return self;
        }
        
        public static T EmptyView<T>(this T self, Func<PropertyContext<object>, IPropertyBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<object>(self, Microsoft.Maui.Controls.ItemsView.EmptyViewProperty);
            configure(context).Build();
            return self;
        }
        
        public static T EmptyViewTemplate<T>(this T self,
            Microsoft.Maui.Controls.DataTemplate emptyViewTemplate)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.EmptyViewTemplateProperty, emptyViewTemplate);
            return self;
        }
        
        public static T EmptyViewTemplate<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.DataTemplate>, IPropertyBuilder<Microsoft.Maui.Controls.DataTemplate>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.DataTemplate>(self, Microsoft.Maui.Controls.ItemsView.EmptyViewTemplateProperty);
            configure(context).Build();
            return self;
        }
        
        public static T EmptyViewTemplate<T>(this T self, System.Func<object> loadTemplate)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.EmptyViewTemplateProperty, new DataTemplate(loadTemplate));
            return self;
        }
        
        public static T ItemsSource<T>(this T self,
            System.Collections.IEnumerable itemsSource)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.ItemsSourceProperty, itemsSource);
            return self;
        }
        
        public static T ItemsSource<T>(this T self, Func<PropertyContext<System.Collections.IEnumerable>, IPropertyBuilder<System.Collections.IEnumerable>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<System.Collections.IEnumerable>(self, Microsoft.Maui.Controls.ItemsView.ItemsSourceProperty);
            configure(context).Build();
            return self;
        }
        
        public static T RemainingItemsThresholdReachedCommand<T>(this T self,
            System.Windows.Input.ICommand remainingItemsThresholdReachedCommand)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.RemainingItemsThresholdReachedCommandProperty, remainingItemsThresholdReachedCommand);
            return self;
        }
        
        public static T RemainingItemsThresholdReachedCommand<T>(this T self, Func<PropertyContext<System.Windows.Input.ICommand>, IPropertyBuilder<System.Windows.Input.ICommand>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<System.Windows.Input.ICommand>(self, Microsoft.Maui.Controls.ItemsView.RemainingItemsThresholdReachedCommandProperty);
            configure(context).Build();
            return self;
        }
        
        public static T RemainingItemsThresholdReachedCommandParameter<T>(this T self,
            object remainingItemsThresholdReachedCommandParameter)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.RemainingItemsThresholdReachedCommandParameterProperty, remainingItemsThresholdReachedCommandParameter);
            return self;
        }
        
        public static T RemainingItemsThresholdReachedCommandParameter<T>(this T self, Func<PropertyContext<object>, IPropertyBuilder<object>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<object>(self, Microsoft.Maui.Controls.ItemsView.RemainingItemsThresholdReachedCommandParameterProperty);
            configure(context).Build();
            return self;
        }
        
        public static T HorizontalScrollBarVisibility<T>(this T self,
            Microsoft.Maui.ScrollBarVisibility horizontalScrollBarVisibility)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.HorizontalScrollBarVisibilityProperty, horizontalScrollBarVisibility);
            return self;
        }
        
        public static T HorizontalScrollBarVisibility<T>(this T self, Func<PropertyContext<Microsoft.Maui.ScrollBarVisibility>, IPropertyBuilder<Microsoft.Maui.ScrollBarVisibility>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<Microsoft.Maui.ScrollBarVisibility>(self, Microsoft.Maui.Controls.ItemsView.HorizontalScrollBarVisibilityProperty);
            configure(context).Build();
            return self;
        }
        
        public static T VerticalScrollBarVisibility<T>(this T self,
            Microsoft.Maui.ScrollBarVisibility verticalScrollBarVisibility)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.VerticalScrollBarVisibilityProperty, verticalScrollBarVisibility);
            return self;
        }
        
        public static T VerticalScrollBarVisibility<T>(this T self, Func<PropertyContext<Microsoft.Maui.ScrollBarVisibility>, IPropertyBuilder<Microsoft.Maui.ScrollBarVisibility>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<Microsoft.Maui.ScrollBarVisibility>(self, Microsoft.Maui.Controls.ItemsView.VerticalScrollBarVisibilityProperty);
            configure(context).Build();
            return self;
        }
        
        public static T RemainingItemsThreshold<T>(this T self,
            int remainingItemsThreshold)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.RemainingItemsThresholdProperty, remainingItemsThreshold);
            return self;
        }
        
        public static T RemainingItemsThreshold<T>(this T self, Func<PropertyContext<int>, IPropertyBuilder<int>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<int>(self, Microsoft.Maui.Controls.ItemsView.RemainingItemsThresholdProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ItemTemplate<T>(this T self,
            Microsoft.Maui.Controls.DataTemplate itemTemplate)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.ItemTemplateProperty, itemTemplate);
            return self;
        }
        
        public static T ItemTemplate<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.DataTemplate>, IPropertyBuilder<Microsoft.Maui.Controls.DataTemplate>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.DataTemplate>(self, Microsoft.Maui.Controls.ItemsView.ItemTemplateProperty);
            configure(context).Build();
            return self;
        }
        
        public static T ItemTemplate<T>(this T self, System.Func<object> loadTemplate)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.ItemTemplateProperty, new DataTemplate(loadTemplate));
            return self;
        }
        
        public static T ItemsUpdatingScrollMode<T>(this T self,
            Microsoft.Maui.Controls.ItemsUpdatingScrollMode itemsUpdatingScrollMode)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.ItemsView.ItemsUpdatingScrollModeProperty, itemsUpdatingScrollMode);
            return self;
        }
        
        public static T ItemsUpdatingScrollMode<T>(this T self, Func<PropertyContext<Microsoft.Maui.Controls.ItemsUpdatingScrollMode>, IPropertyBuilder<Microsoft.Maui.Controls.ItemsUpdatingScrollMode>> configure)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            var context = new PropertyContext<Microsoft.Maui.Controls.ItemsUpdatingScrollMode>(self, Microsoft.Maui.Controls.ItemsView.ItemsUpdatingScrollModeProperty);
            configure(context).Build();
            return self;
        }
        
        public static T OnScrollToRequested<T>(this T self, System.EventHandler<Microsoft.Maui.Controls.ScrollToRequestEventArgs> handler)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.ScrollToRequested += handler;
            return self;
        }
        
        public static T OnScrollToRequested<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.ScrollToRequested += (o, arg) => action(self);
            return self;
        }
        
        public static T OnScrolled<T>(this T self, System.EventHandler<Microsoft.Maui.Controls.ItemsViewScrolledEventArgs> handler)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.Scrolled += handler;
            return self;
        }
        
        public static T OnScrolled<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.Scrolled += (o, arg) => action(self);
            return self;
        }
        
        public static T OnRemainingItemsThresholdReached<T>(this T self, System.EventHandler handler)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.RemainingItemsThresholdReached += handler;
            return self;
        }
        
        public static T OnRemainingItemsThresholdReached<T>(this T self, System.Action<T> action)
            where T : Microsoft.Maui.Controls.ItemsView
        {
            self.RemainingItemsThresholdReached += (o, arg) => action(self);
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
