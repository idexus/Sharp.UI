//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class LayoutGeneratedExtension
    {
        public static T Children<T>(this T obj,
            System.Collections.Generic.IList<Microsoft.Maui.IView> children)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            foreach (var item in children)
            {
                var mauiItem = MauiWrapper.Value<Microsoft.Maui.IView>(item);
                mauiObject.Children.Add(mauiItem);
            }
            return obj;
        }

        public static T Children<T>(this T obj,
            params Microsoft.Maui.IView[] children)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            foreach (var item in children)
            {
                var mauiItem = MauiWrapper.Value<Microsoft.Maui.IView>(item);
                mauiObject.Children.Add(mauiItem);
            }
            return obj;
        }

        public static T Children<T>(this T obj,
            System.Func<LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.IView>>, LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.IView>>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.IView>>());
            if (builder.ValueIsSet())
            {
                var items = builder.GetValue();
                foreach (var item in items) 
                {
                    var mauiItem = MauiWrapper.Value<Microsoft.Maui.IView>(item);
                    mauiObject.Children.Add(mauiItem);
                }
            }
            return obj;
        }
        
        public static T IsClippedToBounds<T>(this T obj,
            bool isClippedToBounds)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            mauiObject.IsClippedToBounds = (bool)isClippedToBounds;
            return obj;
        }
        
        public static T IsClippedToBounds<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IsClippedToBounds = builder.GetValue();
            return obj;
        }
        
        public static T IsClippedToBounds<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IsClippedToBounds = builder.GetValue();
            return obj;
        }
        
        public static T IsClippedToBounds<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.Layout.IsClippedToBoundsProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            Microsoft.Maui.Thickness padding)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            mauiObject.Padding = (Microsoft.Maui.Thickness)padding;
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Thickness>, ValueBuilder<Microsoft.Maui.Thickness>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Thickness>());
            if (builder.ValueIsSet()) mauiObject.Padding = builder.GetValue();
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Thickness>, LazyValueBuilder<Microsoft.Maui.Thickness>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Thickness>());
            if (builder.ValueIsSet()) mauiObject.Padding = builder.GetValue();
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Thickness>, BindingBuilder<Microsoft.Maui.Thickness>> buildBinding)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Thickness>(mauiObject, Microsoft.Maui.Controls.Layout.PaddingProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IgnoreSafeArea<T>(this T obj,
            bool ignoreSafeArea)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            mauiObject.IgnoreSafeArea = (bool)ignoreSafeArea;
            return obj;
        }
        
        public static T IgnoreSafeArea<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IgnoreSafeArea = builder.GetValue();
            return obj;
        }
        
        public static T IgnoreSafeArea<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.IgnoreSafeArea = builder.GetValue();
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            bool cascadeInputTransparent)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            mauiObject.CascadeInputTransparent = (bool)cascadeInputTransparent;
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.CascadeInputTransparent = builder.GetValue();
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.CascadeInputTransparent = builder.GetValue();
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.ILayout
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Layout>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.Layout.CascadeInputTransparentProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
