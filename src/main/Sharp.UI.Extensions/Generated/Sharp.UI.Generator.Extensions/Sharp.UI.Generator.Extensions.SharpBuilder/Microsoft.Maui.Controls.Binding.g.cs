﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class BindingExtension
    {
        public static Microsoft.Maui.Controls.Binding Converter(this Microsoft.Maui.Controls.Binding obj,
            Microsoft.Maui.Controls.IValueConverter converter)
        {
            obj.Converter = converter;
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding Converter(this Microsoft.Maui.Controls.Binding obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.IValueConverter>, ValueBuilder<Microsoft.Maui.Controls.IValueConverter>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.IValueConverter>());
            if (builder.ValueIsSet()) obj.Converter = builder.GetValue();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding ConverterParameter(this Microsoft.Maui.Controls.Binding obj,
            object converterParameter)
        {
            obj.ConverterParameter = converterParameter;
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding ConverterParameter(this Microsoft.Maui.Controls.Binding obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) obj.ConverterParameter = builder.GetValue();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding Path(this Microsoft.Maui.Controls.Binding obj,
            string path)
        {
            obj.Path = path;
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding Path(this Microsoft.Maui.Controls.Binding obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.Path = builder.GetValue();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding Source(this Microsoft.Maui.Controls.Binding obj,
            object source)
        {
            obj.Source = source;
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding Source(this Microsoft.Maui.Controls.Binding obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) obj.Source = builder.GetValue();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding UpdateSourceEventName(this Microsoft.Maui.Controls.Binding obj,
            string updateSourceEventName)
        {
            obj.UpdateSourceEventName = updateSourceEventName;
            return obj;
        }
        
        public static Microsoft.Maui.Controls.Binding UpdateSourceEventName(this Microsoft.Maui.Controls.Binding obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.UpdateSourceEventName = builder.GetValue();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore