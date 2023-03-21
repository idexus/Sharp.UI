using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarkup.Maui
{
    public sealed class PropertyBindingBuilder<T> : IPropertyBuilder<T>
    {
        public class ValueConverter : IValueConverter
        {
            internal System.Func<object, T> ConvertFunction = null;
            internal System.Func<T, object> ConvertBackFunction = null;

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null && ConvertFunction != null) return ConvertFunction(value);
                return null;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null && ConvertBackFunction != null) return ConvertBackFunction((T)value);
                return null;
            }
        }

        public PropertyContext<T> Context { get; set; }

        string path = null;
        BindingMode bindingMode = Microsoft.Maui.Controls.BindingMode.Default;
        IValueConverter converter = null;
        ValueConverter valueConverter = null;
        string converterParameter = null;
        string stringFormat = null;
        object source = null;

        public PropertyBindingBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (path != null)
            {
                Context.BindableObject.SetBinding(
                    targetProperty: Context.Property,
                    binding: new Microsoft.Maui.Controls.Binding(
                        path: path,
                        mode: bindingMode,
                        converter: converter,
                        converterParameter: converterParameter,
                        stringFormat: stringFormat,
                        source: source));
                return true;
            }
            return false;
        }

        public PropertyBindingBuilder<T> Path(string path) { this.path = path; return this; }
        public PropertyBindingBuilder<T> StringFormat(string stringFormat) { this.stringFormat = stringFormat; return this; }
        public PropertyBindingBuilder<T> BindingMode(BindingMode bindingMode) { this.bindingMode = bindingMode; return this; }
        public PropertyBindingBuilder<T> Converter(IValueConverter converter) { this.converter = converter; return this; }
        public PropertyBindingBuilder<T> Parameter(string converterParameter) { this.converterParameter = converterParameter; return this; }
        public PropertyBindingBuilder<T> Source(object source) { this.source = source; return this; }

        public PropertyBindingBuilder<T> Convert<Q>(Func<Q, T> convert)
        {
            if (valueConverter == null) valueConverter = new ValueConverter();
            valueConverter.ConvertFunction = e => convert((Q)e);
            this.converter = valueConverter;
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q>(Func<T, Q> convert)
        {
            if (valueConverter == null) valueConverter = new ValueConverter();
            valueConverter.ConvertBackFunction = e => convert((T)e);
            this.converter = valueConverter;
            return this;
        }
    }
}
