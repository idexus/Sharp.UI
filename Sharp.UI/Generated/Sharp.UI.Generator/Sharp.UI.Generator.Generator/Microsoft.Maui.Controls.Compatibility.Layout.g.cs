﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class CompatibilityLayoutGeneratedExtension
    {
        public static T IsClippedToBounds<T>(this T obj,
            bool? isClippedToBounds)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            if (isClippedToBounds != null) mauiObject.IsClippedToBounds = (bool)isClippedToBounds;
            return obj;
        }
        
        public static T IsClippedToBounds<T>(this T obj,
            bool? isClippedToBounds,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            if (isClippedToBounds != null) mauiObject.IsClippedToBounds = (bool)isClippedToBounds;
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.Compatibility.Layout.IsClippedToBoundsProperty));
            if (def.ValueIsSet()) mauiObject.IsClippedToBounds = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T IsClippedToBounds<T>(this T obj,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.Compatibility.Layout.IsClippedToBoundsProperty));
            if (def.ValueIsSet()) mauiObject.IsClippedToBounds = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            Microsoft.Maui.Thickness? padding)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            if (padding != null) mauiObject.Padding = (Microsoft.Maui.Thickness)padding;
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            Microsoft.Maui.Thickness? padding,
            Func<BindableDef<Microsoft.Maui.Thickness>, BindableDef<Microsoft.Maui.Thickness>> definition)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            if (padding != null) mauiObject.Padding = (Microsoft.Maui.Thickness)padding;
            var def = definition(new BindableDef<Microsoft.Maui.Thickness>(mauiObject, Microsoft.Maui.Controls.Compatibility.Layout.PaddingProperty));
            if (def.ValueIsSet()) mauiObject.Padding = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T Padding<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Thickness>, BindableDef<Microsoft.Maui.Thickness>> definition)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Thickness>(mauiObject, Microsoft.Maui.Controls.Compatibility.Layout.PaddingProperty));
            if (def.ValueIsSet()) mauiObject.Padding = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            bool? cascadeInputTransparent)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            if (cascadeInputTransparent != null) mauiObject.CascadeInputTransparent = (bool)cascadeInputTransparent;
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            bool? cascadeInputTransparent,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            if (cascadeInputTransparent != null) mauiObject.CascadeInputTransparent = (bool)cascadeInputTransparent;
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.Compatibility.Layout.CascadeInputTransparentProperty));
            if (def.ValueIsSet()) mauiObject.CascadeInputTransparent = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T CascadeInputTransparent<T>(this T obj,
            Func<BindableDef<bool>, BindableDef<bool>> definition)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            var def = definition(new BindableDef<bool>(mauiObject, Microsoft.Maui.Controls.Compatibility.Layout.CascadeInputTransparentProperty));
            if (def.ValueIsSet()) mauiObject.CascadeInputTransparent = def.GetValue();
            def.BindProperty();
            return obj;
        }
        
        public static T OnLayoutChanged<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.ICompatibilityLayout
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Compatibility.Layout>(obj);
            mauiObject.LayoutChanged += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669