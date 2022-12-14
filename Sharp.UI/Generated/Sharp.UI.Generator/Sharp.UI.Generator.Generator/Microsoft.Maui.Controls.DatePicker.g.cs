//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class DatePickerGeneratedExtension
    {
        public static T Date<T>(this T obj,
            System.DateTime date)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.Date = (System.DateTime)date;
            return obj;
        }
        
        public static T Date<T>(this T obj,
            System.Func<ValueBuilder<System.DateTime>, ValueBuilder<System.DateTime>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<System.DateTime>());
            if (builder.ValueIsSet()) mauiObject.Date = builder.GetValue();
            return obj;
        }
        
        public static T Date<T>(this T obj,
            System.Func<LazyValueBuilder<System.DateTime>, LazyValueBuilder<System.DateTime>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<System.DateTime>());
            if (builder.ValueIsSet()) mauiObject.Date = builder.GetValue();
            return obj;
        }
        
        public static T Date<T>(this T obj,
            System.Func<BindingBuilder<System.DateTime>, BindingBuilder<System.DateTime>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<System.DateTime>(mauiObject, Microsoft.Maui.Controls.DatePicker.DateProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Format<T>(this T obj,
            string format)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.Format = (string)format;
            return obj;
        }
        
        public static T Format<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Format = builder.GetValue();
            return obj;
        }
        
        public static T Format<T>(this T obj,
            System.Func<LazyValueBuilder<string>, LazyValueBuilder<string>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Format = builder.GetValue();
            return obj;
        }
        
        public static T Format<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<string>(mauiObject, Microsoft.Maui.Controls.DatePicker.FormatProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T MaximumDate<T>(this T obj,
            System.DateTime maximumDate)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.MaximumDate = (System.DateTime)maximumDate;
            return obj;
        }
        
        public static T MaximumDate<T>(this T obj,
            System.Func<ValueBuilder<System.DateTime>, ValueBuilder<System.DateTime>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<System.DateTime>());
            if (builder.ValueIsSet()) mauiObject.MaximumDate = builder.GetValue();
            return obj;
        }
        
        public static T MaximumDate<T>(this T obj,
            System.Func<LazyValueBuilder<System.DateTime>, LazyValueBuilder<System.DateTime>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<System.DateTime>());
            if (builder.ValueIsSet()) mauiObject.MaximumDate = builder.GetValue();
            return obj;
        }
        
        public static T MaximumDate<T>(this T obj,
            System.Func<BindingBuilder<System.DateTime>, BindingBuilder<System.DateTime>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<System.DateTime>(mauiObject, Microsoft.Maui.Controls.DatePicker.MaximumDateProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T MinimumDate<T>(this T obj,
            System.DateTime minimumDate)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.MinimumDate = (System.DateTime)minimumDate;
            return obj;
        }
        
        public static T MinimumDate<T>(this T obj,
            System.Func<ValueBuilder<System.DateTime>, ValueBuilder<System.DateTime>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<System.DateTime>());
            if (builder.ValueIsSet()) mauiObject.MinimumDate = builder.GetValue();
            return obj;
        }
        
        public static T MinimumDate<T>(this T obj,
            System.Func<LazyValueBuilder<System.DateTime>, LazyValueBuilder<System.DateTime>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<System.DateTime>());
            if (builder.ValueIsSet()) mauiObject.MinimumDate = builder.GetValue();
            return obj;
        }
        
        public static T MinimumDate<T>(this T obj,
            System.Func<BindingBuilder<System.DateTime>, BindingBuilder<System.DateTime>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<System.DateTime>(mauiObject, Microsoft.Maui.Controls.DatePicker.MinimumDateProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color textColor)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.TextColor = (Microsoft.Maui.Graphics.Color)textColor;
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.TextColor = builder.GetValue();
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Graphics.Color>, LazyValueBuilder<Microsoft.Maui.Graphics.Color>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) mauiObject.TextColor = builder.GetValue();
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(mauiObject, Microsoft.Maui.Controls.DatePicker.TextColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T CharacterSpacing<T>(this T obj,
            double characterSpacing)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.CharacterSpacing = (double)characterSpacing;
            return obj;
        }
        
        public static T CharacterSpacing<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.CharacterSpacing = builder.GetValue();
            return obj;
        }
        
        public static T CharacterSpacing<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.CharacterSpacing = builder.GetValue();
            return obj;
        }
        
        public static T CharacterSpacing<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.DatePicker.CharacterSpacingProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FontAttributes<T>(this T obj,
            Microsoft.Maui.Controls.FontAttributes fontAttributes)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.FontAttributes = (Microsoft.Maui.Controls.FontAttributes)fontAttributes;
            return obj;
        }
        
        public static T FontAttributes<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.FontAttributes>, ValueBuilder<Microsoft.Maui.Controls.FontAttributes>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<Microsoft.Maui.Controls.FontAttributes>());
            if (builder.ValueIsSet()) mauiObject.FontAttributes = builder.GetValue();
            return obj;
        }
        
        public static T FontAttributes<T>(this T obj,
            System.Func<LazyValueBuilder<Microsoft.Maui.Controls.FontAttributes>, LazyValueBuilder<Microsoft.Maui.Controls.FontAttributes>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<Microsoft.Maui.Controls.FontAttributes>());
            if (builder.ValueIsSet()) mauiObject.FontAttributes = builder.GetValue();
            return obj;
        }
        
        public static T FontAttributes<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.FontAttributes>, BindingBuilder<Microsoft.Maui.Controls.FontAttributes>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<Microsoft.Maui.Controls.FontAttributes>(mauiObject, Microsoft.Maui.Controls.DatePicker.FontAttributesProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            string fontFamily)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.FontFamily = (string)fontFamily;
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.FontFamily = builder.GetValue();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            System.Func<LazyValueBuilder<string>, LazyValueBuilder<string>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.FontFamily = builder.GetValue();
            return obj;
        }
        
        public static T FontFamily<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<string>(mauiObject, Microsoft.Maui.Controls.DatePicker.FontFamilyProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FontSize<T>(this T obj,
            double fontSize)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.FontSize = (double)fontSize;
            return obj;
        }
        
        public static T FontSize<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.FontSize = builder.GetValue();
            return obj;
        }
        
        public static T FontSize<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.FontSize = builder.GetValue();
            return obj;
        }
        
        public static T FontSize<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.DatePicker.FontSizeProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            bool fontAutoScalingEnabled)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.FontAutoScalingEnabled = (bool)fontAutoScalingEnabled;
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.FontAutoScalingEnabled = builder.GetValue();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.FontAutoScalingEnabled = builder.GetValue();
            return obj;
        }
        
        public static T FontAutoScalingEnabled<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.DatePicker.FontAutoScalingEnabledProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T OnDateSelected<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.DateChangedEventArgs> handler)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.DateSelected += handler;
            return obj;
        }
        
        public static T OnDateSelected<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IDatePicker
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DatePicker>(obj);
            mauiObject.DateSelected += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
