//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class BindingConditionGeneratedExtension
    {
        public static T Binding<T>(this T obj,
            Microsoft.Maui.Controls.BindingBase binding)
            where T : Sharp.UI.IBindingCondition
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingCondition>(obj);
            mauiObject.Binding = (Microsoft.Maui.Controls.BindingBase)binding;
            return obj;
        }
        
        public static T Binding<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.BindingBase>, ValueBuilder<Microsoft.Maui.Controls.BindingBase>> buildValue)
            where T : Sharp.UI.IBindingCondition
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingCondition>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.BindingBase>());
            if (builder.ValueIsSet()) mauiObject.Binding = builder.GetValue();
            return obj;
        }
        
        public static T Binding<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.BindingBase>, LazyValueBuilder<Microsoft.Maui.Controls.BindingBase>> buildValue)
            where T : Sharp.UI.IBindingCondition
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingCondition>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.BindingBase>());
            if (builder.ValueIsSet()) mauiObject.Binding = builder.GetValue();
            return obj;
        }
        
        public static T Value<T>(this T obj,
            object value)
            where T : Sharp.UI.IBindingCondition
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingCondition>(obj);
            mauiObject.Value = (object)value;
            return obj;
        }
        
        public static T Value<T>(this T obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buildValue)
            where T : Sharp.UI.IBindingCondition
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingCondition>(obj);
            var builder = buildValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) mauiObject.Value = builder.GetValue();
            return obj;
        }
        
        public static T Value<T>(this T obj,
            System.Func<LazyValueBuilder<object>, LazyValueBuilder<object>> buildValue)
            where T : Sharp.UI.IBindingCondition
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.BindingCondition>(obj);
            var builder = buildValue(new LazyValueBuilder<object>());
            if (builder.ValueIsSet()) mauiObject.Value = builder.GetValue();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
