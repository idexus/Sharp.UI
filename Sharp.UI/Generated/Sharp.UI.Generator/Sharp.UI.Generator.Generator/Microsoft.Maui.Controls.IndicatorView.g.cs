﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class IndicatorViewGeneratedExtension
    {
        public static T IndicatorsShape<T>(this T obj,
            Microsoft.Maui.Controls.IndicatorShape? indicatorsShape)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorsShape != null) mauiObject.IndicatorsShape = (Microsoft.Maui.Controls.IndicatorShape)indicatorsShape;
            return obj;
        }
        
        public static T IndicatorsShape<T>(this T obj,
            Microsoft.Maui.Controls.IndicatorShape? indicatorsShape,
            Func<BindableDef<Microsoft.Maui.Controls.IndicatorShape>, BindableDef<Microsoft.Maui.Controls.IndicatorShape>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorsShape != null) mauiObject.IndicatorsShape = (Microsoft.Maui.Controls.IndicatorShape)indicatorsShape;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.IndicatorShape>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorsShapeProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorsShape = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorsShape<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.IndicatorShape>, BindableDef<Microsoft.Maui.Controls.IndicatorShape>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.IndicatorShape>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorsShapeProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorsShape = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorLayout<T>(this T obj,
            Microsoft.Maui.Controls.IBindableLayout? indicatorLayout)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorLayout != null) mauiObject.IndicatorLayout = (Microsoft.Maui.Controls.IBindableLayout)indicatorLayout;
            return obj;
        }
        
        public static T IndicatorLayout<T>(this T obj,
            Microsoft.Maui.Controls.IBindableLayout? indicatorLayout,
            Func<ValueDef<Microsoft.Maui.Controls.IBindableLayout>, ValueDef<Microsoft.Maui.Controls.IBindableLayout>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorLayout != null) mauiObject.IndicatorLayout = (Microsoft.Maui.Controls.IBindableLayout)indicatorLayout;
            var def = definition(new ValueDef<Microsoft.Maui.Controls.IBindableLayout>());
            if (def.ValueIsSet()) mauiObject.IndicatorLayout = def.GetValue();
            return obj;
        }
        
        public static T IndicatorLayout<T>(this T obj,
            Func<ValueDef<Microsoft.Maui.Controls.IBindableLayout>, ValueDef<Microsoft.Maui.Controls.IBindableLayout>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new ValueDef<Microsoft.Maui.Controls.IBindableLayout>());
            if (def.ValueIsSet()) mauiObject.IndicatorLayout = def.GetValue();
            return obj;
        }
        
        public static T Position<T>(this T obj,
            int? position)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (position != null) mauiObject.Position = (int)position;
            return obj;
        }
        
        public static T Position<T>(this T obj,
            int? position,
            Func<BindableDef<int>, BindableDef<int>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (position != null) mauiObject.Position = (int)position;
            var def = definition(new BindableDef<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.PositionProperty));
            if (def.ValueIsSet()) mauiObject.Position = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Position<T>(this T obj,
            Func<BindableDef<int>, BindableDef<int>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.PositionProperty));
            if (def.ValueIsSet()) mauiObject.Position = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Count<T>(this T obj,
            int? count)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (count != null) mauiObject.Count = (int)count;
            return obj;
        }
        
        public static T Count<T>(this T obj,
            int? count,
            Func<BindableDef<int>, BindableDef<int>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (count != null) mauiObject.Count = (int)count;
            var def = definition(new BindableDef<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.CountProperty));
            if (def.ValueIsSet()) mauiObject.Count = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Count<T>(this T obj,
            Func<BindableDef<int>, BindableDef<int>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.CountProperty));
            if (def.ValueIsSet()) mauiObject.Count = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            int? maximumVisible)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (maximumVisible != null) mauiObject.MaximumVisible = (int)maximumVisible;
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            int? maximumVisible,
            Func<BindableDef<int>, BindableDef<int>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (maximumVisible != null) mauiObject.MaximumVisible = (int)maximumVisible;
            var def = definition(new BindableDef<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.MaximumVisibleProperty));
            if (def.ValueIsSet()) mauiObject.MaximumVisible = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T MaximumVisible<T>(this T obj,
            Func<BindableDef<int>, BindableDef<int>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<int>(mauiObject, Microsoft.Maui.Controls.IndicatorView.MaximumVisibleProperty));
            if (def.ValueIsSet()) mauiObject.MaximumVisible = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate? indicatorTemplate)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorTemplate != null) mauiObject.IndicatorTemplate = (Microsoft.Maui.Controls.DataTemplate)indicatorTemplate;
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            Microsoft.Maui.Controls.DataTemplate? indicatorTemplate,
            Func<BindableDef<Microsoft.Maui.Controls.DataTemplate>, BindableDef<Microsoft.Maui.Controls.DataTemplate>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorTemplate != null) mauiObject.IndicatorTemplate = (Microsoft.Maui.Controls.DataTemplate)indicatorTemplate;
            var def = definition(new BindableDef<Microsoft.Maui.Controls.DataTemplate>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorTemplateProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorTemplate = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Controls.DataTemplate>, BindableDef<Microsoft.Maui.Controls.DataTemplate>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Controls.DataTemplate>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorTemplateProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorTemplate = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorTemplate<T>(this T obj, Func<object> loadTemplate) where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            mauiObject.IndicatorTemplate = new Microsoft.Maui.Controls.DataTemplate(loadTemplate);
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            bool? hideSingle)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (hideSingle != null) mauiObject.HideSingle = (bool)hideSingle;
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            bool? hideSingle,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (hideSingle != null) mauiObject.HideSingle = (bool)hideSingle;
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.IndicatorView.HideSingleProperty));
            if (def.ValueIsSet()) mauiObject.HideSingle = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T HideSingle<T>(this T obj,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.IndicatorView.HideSingleProperty));
            if (def.ValueIsSet()) mauiObject.HideSingle = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? indicatorColor)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorColor != null) mauiObject.IndicatorColor = (Microsoft.Maui.Graphics.Color)indicatorColor;
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? indicatorColor,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorColor != null) mauiObject.IndicatorColor = (Microsoft.Maui.Graphics.Color)indicatorColor;
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorColorProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorColor<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorColorProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? selectedIndicatorColor)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (selectedIndicatorColor != null) mauiObject.SelectedIndicatorColor = (Microsoft.Maui.Graphics.Color)selectedIndicatorColor;
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? selectedIndicatorColor,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (selectedIndicatorColor != null) mauiObject.SelectedIndicatorColor = (Microsoft.Maui.Graphics.Color)selectedIndicatorColor;
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.IndicatorView.SelectedIndicatorColorProperty));
            if (def.ValueIsSet()) mauiObject.SelectedIndicatorColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T SelectedIndicatorColor<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.IndicatorView.SelectedIndicatorColorProperty));
            if (def.ValueIsSet()) mauiObject.SelectedIndicatorColor = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            double? indicatorSize)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorSize != null) mauiObject.IndicatorSize = (double)indicatorSize;
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            double? indicatorSize,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (indicatorSize != null) mauiObject.IndicatorSize = (double)indicatorSize;
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorSizeProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorSize = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IndicatorSize<T>(this T obj,
            Func<BindableDef<double>, BindableDef<double>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<double>(mauiObject, Microsoft.Maui.Controls.IndicatorView.IndicatorSizeProperty));
            if (def.ValueIsSet()) mauiObject.IndicatorSize = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Collections.IEnumerable? itemsSource)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (itemsSource != null) mauiObject.ItemsSource = (System.Collections.IEnumerable)itemsSource;
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            System.Collections.IEnumerable? itemsSource,
            Func<BindableDef<System.Collections.IEnumerable>, BindableDef<System.Collections.IEnumerable>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            if (itemsSource != null) mauiObject.ItemsSource = (System.Collections.IEnumerable)itemsSource;
            var def = definition(new BindableDef<System.Collections.IEnumerable>(mauiObject, Microsoft.Maui.Controls.IndicatorView.ItemsSourceProperty));
            if (def.ValueIsSet()) mauiObject.ItemsSource = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T ItemsSource<T>(this T obj,
            Func<BindableDef<System.Collections.IEnumerable>, BindableDef<System.Collections.IEnumerable>> definition)
            where T : Sharp.UI.IIndicatorView
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.IndicatorView>(obj);
            var def = definition(new BindableDef<System.Collections.IEnumerable>(mauiObject, Microsoft.Maui.Controls.IndicatorView.ItemsSourceProperty));
            if (def.ValueIsSet()) mauiObject.ItemsSource = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669