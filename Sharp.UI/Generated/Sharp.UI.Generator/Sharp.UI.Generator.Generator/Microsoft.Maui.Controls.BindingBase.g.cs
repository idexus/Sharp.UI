﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class BindingBaseGeneratedExtension
    {
        public static T Mode<T>(this T obj,
            Microsoft.Maui.Controls.BindingMode mode)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.Mode = (Microsoft.Maui.Controls.BindingMode)mode;
            return obj;
        }
        
        public static T Mode<T>(this T obj,
            Microsoft.Maui.Controls.BindingMode mode,
            System.Func<ValueDef<Microsoft.Maui.Controls.BindingMode>, ValueDef<Microsoft.Maui.Controls.BindingMode>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.Mode = (Microsoft.Maui.Controls.BindingMode)mode;
            var def = definition(new ValueDef<Microsoft.Maui.Controls.BindingMode>());
            if (def.ValueIsSet()) mauiObject.Mode = def.GetValue();
            return obj;
        }
        
        public static T Mode<T>(this T obj,
            System.Func<ValueDef<Microsoft.Maui.Controls.BindingMode>, ValueDef<Microsoft.Maui.Controls.BindingMode>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            var def = definition(new ValueDef<Microsoft.Maui.Controls.BindingMode>());
            if (def.ValueIsSet()) mauiObject.Mode = def.GetValue();
            return obj;
        }
        
        public static T StringFormat<T>(this T obj,
            string stringFormat)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.StringFormat = (string)stringFormat;
            return obj;
        }
        
        public static T StringFormat<T>(this T obj,
            string stringFormat,
            System.Func<ValueDef<string>, ValueDef<string>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.StringFormat = (string)stringFormat;
            var def = definition(new ValueDef<string>());
            if (def.ValueIsSet()) mauiObject.StringFormat = def.GetValue();
            return obj;
        }
        
        public static T StringFormat<T>(this T obj,
            System.Func<ValueDef<string>, ValueDef<string>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            var def = definition(new ValueDef<string>());
            if (def.ValueIsSet()) mauiObject.StringFormat = def.GetValue();
            return obj;
        }
        
        public static T TargetNullValue<T>(this T obj,
            object targetNullValue)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.TargetNullValue = (object)targetNullValue;
            return obj;
        }
        
        public static T TargetNullValue<T>(this T obj,
            object targetNullValue,
            System.Func<ValueDef<object>, ValueDef<object>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.TargetNullValue = (object)targetNullValue;
            var def = definition(new ValueDef<object>());
            if (def.ValueIsSet()) mauiObject.TargetNullValue = def.GetValue();
            return obj;
        }
        
        public static T TargetNullValue<T>(this T obj,
            System.Func<ValueDef<object>, ValueDef<object>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            var def = definition(new ValueDef<object>());
            if (def.ValueIsSet()) mauiObject.TargetNullValue = def.GetValue();
            return obj;
        }
        
        public static T FallbackValue<T>(this T obj,
            object fallbackValue)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.FallbackValue = (object)fallbackValue;
            return obj;
        }
        
        public static T FallbackValue<T>(this T obj,
            object fallbackValue,
            System.Func<ValueDef<object>, ValueDef<object>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            mauiObject.FallbackValue = (object)fallbackValue;
            var def = definition(new ValueDef<object>());
            if (def.ValueIsSet()) mauiObject.FallbackValue = def.GetValue();
            return obj;
        }
        
        public static T FallbackValue<T>(this T obj,
            System.Func<ValueDef<object>, ValueDef<object>> definition)
            where T : Sharp.UI.IBindingBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingBase>(obj);
            var def = definition(new ValueDef<object>());
            if (def.ValueIsSet()) mauiObject.FallbackValue = def.GetValue();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669