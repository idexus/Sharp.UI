//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class IndicatorViewGeneratedExtension
    {
        public static T IndicatorsShape<T>(this T obj,
            Microsoft.Maui.Controls.IndicatorShape indicatorsShape)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorsShape = (Microsoft.Maui.Controls.IndicatorShape)indicatorsShape;
            return obj;
        }
        
        public static T IndicatorsShape<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.IndicatorShape>, ValueBuilder<Microsoft.Maui.Controls.IndicatorShape>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.IndicatorShape>());
            if (builder.ValueIsSet()) mauiObject.IndicatorsShape = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorsShape<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.IndicatorShape>, LazyValueBuilder<Microsoft.Maui.Controls.IndicatorShape>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.IndicatorShape>());
            if (builder.ValueIsSet()) mauiObject.IndicatorsShape = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorsShape<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.IndicatorShape>, BindingBuilder<Microsoft.Maui.Controls.IndicatorShape>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.IndicatorShape>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorsShapeProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IndicatorLayout<T>(this T obj,
            Microsoft.Maui.Controls.IBindableLayout indicatorLayout)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorLayout = (Microsoft.Maui.Controls.IBindableLayout)indicatorLayout;
            return obj;
        }
        
        public static T IndicatorLayout<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.IBindableLayout>, ValueBuilder<Microsoft.Maui.Controls.IBindableLayout>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.IBindableLayout>());
            if (builder.ValueIsSet()) mauiObject.IndicatorLayout = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorLayout<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.IBindableLayout>, LazyValueBuilder<Microsoft.Maui.Controls.IBindableLayout>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.IBindableLayout>());
            if (builder.ValueIsSet()) mauiObject.IndicatorLayout = builder.GetValue();
            return obj;
        }
        
        public static T Position<T>(this T obj,
            int position)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.Position = (int)position;
            return obj;
        }
        
        public static T Position<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.Position = builder.GetValue();
            return obj;
        }
        
        public static T Position<T>(this T obj,
            System.Func<LazyValueBuilder<int>, LazyValueBuilder<int>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.Position = builder.GetValue();
            return obj;
        }
        
        public static T Position<T>(this T obj,
            System.Func<BindingBuilder<int>, BindingBuilder<int>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.PositionProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Count<T>(this T obj,
            int count)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.Count = (int)count;
            return obj;
        }
        
        public static T Count<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.Count = builder.GetValue();
            return obj;
        }
        
        public static T Count<T>(this T obj,
            System.Func<LazyValueBuilder<int>, LazyValueBuilder<int>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.Count = builder.GetValue();
            return obj;
        }
        
        public static T Count<T>(this T obj,
            System.Func<BindingBuilder<int>, BindingBuilder<int>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.CountProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            int maximumVisible)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.MaximumVisible = (int)maximumVisible;
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.MaximumVisible = builder.GetValue();
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            System.Func<LazyValueBuilder<int>, LazyValueBuilder<int>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.MaximumVisible = builder.GetValue();
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            System.Func<BindingBuilder<int>, BindingBuilder<int>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.MaximumVisibleProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate indicatorTemplate)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorTemplate = (Microsoft.Maui.Controls.DataTemplate)indicatorTemplate;
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.DataTemplate>, ValueBuilder<Microsoft.Maui.Controls.DataTemplate>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.DataTemplate>());
            if (builder.ValueIsSet()) mauiObject.IndicatorTemplate = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.DataTemplate>, LazyValueBuilder<Microsoft.Maui.Controls.DataTemplate>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.DataTemplate>());
            if (builder.ValueIsSet()) mauiObject.IndicatorTemplate = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.DataTemplate>, BindingBuilder<Microsoft.Maui.Controls.DataTemplate>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.DataTemplate>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorTemplateProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj, System.Func<object> loadTemplate) where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorTemplate = new DataTemplate(loadTemplate);
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            bool hideSingle)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.HideSingle = (bool)hideSingle;
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.HideSingle = builder.GetValue();
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.HideSingle = builder.GetValue();
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.IndicatorView.HideSingleProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color indicatorColor)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorColor = (Microsoft.Maui.Graphics.Color)indicatorColor;
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.IndicatorColor = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Graphics.Color>, LazyValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.IndicatorColor = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color selectedIndicatorColor)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.SelectedIndicatorColor = (Microsoft.Maui.Graphics.Color)selectedIndicatorColor;
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.SelectedIndicatorColor = builder.GetValue();
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Graphics.Color>, LazyValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.SelectedIndicatorColor = builder.GetValue();
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.IndicatorView.SelectedIndicatorColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            double indicatorSize)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorSize = (double)indicatorSize;
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.IndicatorSize = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.IndicatorSize = builder.GetValue();
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorSizeProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Collections.IEnumerable itemsSource)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.ItemsSource = (System.Collections.IEnumerable)itemsSource;
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Func<ValueBuilder<System.Collections.IEnumerable>, ValueBuilder<System.Collections.IEnumerable>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new ValueBuilder<System.Collections.IEnumerable>());
            if (builder.ValueIsSet()) mauiObject.ItemsSource = builder.GetValue();
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Func<LazyValueBuilder<System.Collections.IEnumerable>, LazyValueBuilder<System.Collections.IEnumerable>> buildValue)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Collections.IEnumerable>());
            if (builder.ValueIsSet()) mauiObject.ItemsSource = builder.GetValue();
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Func<BindingBuilder<System.Collections.IEnumerable>, BindingBuilder<System.Collections.IEnumerable>> buildBinding)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.IndicatorView>(obj);
            var builder = buildBinding(new BindingBuilder<System.Collections.IEnumerable>(mauiObject, Microsoft.Maui.Controls.IndicatorView.ItemsSourceProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
