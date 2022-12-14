//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class SwipeItemGeneratedExtension
    {
        public static T BackgroundColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color backgroundColor)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            mauiObject.BackgroundColor = (Microsoft.Maui.Graphics.Color)backgroundColor;
            return obj;
        }
        
        public static T BackgroundColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.BackgroundColor = builder.GetValue();
            return obj;
        }
        
        public static T BackgroundColor<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Graphics.Color>, LazyValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.BackgroundColor = builder.GetValue();
            return obj;
        }
        
        public static T BackgroundColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buildBinding)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.SwipeItem.BackgroundColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IsVisible<T>(this T obj,
            bool isVisible)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            mauiObject.IsVisible = (bool)isVisible;
            return obj;
        }
        
        public static T IsVisible<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IsVisible = builder.GetValue();
            return obj;
        }
        
        public static T IsVisible<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IsVisible = builder.GetValue();
            return obj;
        }
        
        public static T IsVisible<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.SwipeItem.IsVisibleProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T OnInvoked<T>(this T obj, System.EventHandler<System.EventArgs> handler)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            mauiObject.Invoked += handler;
            return obj;
        }
        
        public static T OnInvoked<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.ISwipeItem
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.SwipeItem>(obj);
            mauiObject.Invoked += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
