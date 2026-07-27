using Sharp.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public sealed class PropertyBindingBuilder<T> : IPropertyBuilder<T>
    {
        // A single sub-binding opened by Path().
        // Each call to Path() always creates a new entry; modifiers
        // (Source, StringFormat, BindingMode, Parameter, Converter) act
        // on the most recently opened entry.
        sealed class Entry
        {
            public string Path;
            public BindingMode Mode = Microsoft.Maui.Controls.BindingMode.Default;
            public IValueConverter Converter;
            public string ConverterParameter;
            public string StringFormat;
            public object Source;

            public Microsoft.Maui.Controls.Binding ToBinding() =>
                new Microsoft.Maui.Controls.Binding(
                    path: Path,
                    mode: Mode,
                    converter: Converter,
                    converterParameter: ConverterParameter,
                    stringFormat: StringFormat,
                    source: Source);
        }

        // Converter for a single binding (Path() called once).
        public class ValueConverter : IValueConverter
        {
            internal Func<object, object> ConvertFunction = null;
            internal Func<object, object> ConvertBackFunction = null;

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

        // Converter for a MultiBinding: N raw values <-> T.
        // Used both by the generic Convert<Q1,Q2,...> overloads (fixed arity)
        // and by ConvertRaw (arbitrary, dynamic arity).
        sealed class MultiValueConverter : IMultiValueConverter
        {
            internal Func<object[], T> ConvertFunction;
            internal Func<T, object[]> ConvertBackFunction;

            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values == null || values.Any(v => v == null) || ConvertFunction == null) return null;
                return ConvertFunction(values);
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                if (value == null || ConvertBackFunction == null) return null;
                return ConvertBackFunction((T)value);
            }
        }

        public PropertyContext<T> Context { get; set; }

        readonly List<Entry> entries = new();
        Entry current;

        MultiValueConverter multiConverter;
        int multiArity = -1;
        bool arityIsDynamic = false;
        BindingMode multiMode = Microsoft.Maui.Controls.BindingMode.Default;

        public PropertyBindingBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (entries.Count == 0) return false;

            // Exactly one Path() and no multi-value Convert/ConvertRaw
            // -> behaves exactly like the original, single-binding version.
            if (entries.Count == 1 && multiConverter == null)
            {
                Context.BindableObject.SetBinding(Context.Property, entries[0].ToBinding());
                return true;
            }

            if (multiConverter == null)
                throw new InvalidOperationException(
                    $"Path() was called {entries.Count} times without a multi-value Convert() or ConvertRaw(). " +
                    "Calling Path() more than once requires Convert<Q1,Q2,...>(...) or ConvertRaw(...).");

            // With fixed arity (Convert<Q1,Q2,...>) the number of Path() calls must match.
            // With ConvertRaw the arity is intentionally dynamic and this check is skipped.
            if (!arityIsDynamic && multiArity != entries.Count)
                throw new InvalidOperationException(
                    $"The number of Path() calls ({entries.Count}) does not match the Convert arity ({multiArity}).");

            var multiBinding = new Microsoft.Maui.Controls.MultiBinding
            {
                Bindings = entries.Select(e => (Microsoft.Maui.Controls.BindingBase)e.ToBinding()).ToList(),
                Converter = multiConverter,
                Mode = multiMode
            };

            Context.BindableObject.SetBinding(Context.Property, multiBinding);
            return true;
        }

        public PropertyBindingBuilder<T> Path(string path)
        {
            current = new Entry { Path = path };
            entries.Add(current);
            return this;
        }

        Entry RequireCurrent()
        {
            if (current == null)
                throw new InvalidOperationException(
                    "Call Path() before using Source/StringFormat/BindingMode/Parameter/Converter.");
            return current;
        }

        MultiValueConverter RequireMultiConverter(int arity)
        {
            if (multiConverter == null)
                throw new InvalidOperationException(
                    "ConvertBack for multiple values requires a preceding call to Convert<Q1,Q2,...>, " +
                    "which defines the forward direction and the number of bindings.");
            if (arityIsDynamic)
                throw new InvalidOperationException(
                    "This builder uses ConvertRaw (dynamic arity) — pass convertBack " +
                    "directly as the second argument of ConvertRaw(...) instead of calling ConvertBack<Q1,Q2,...>.");
            if (multiArity != arity)
                throw new InvalidOperationException(
                    $"The ConvertBack arity ({arity}) does not match the previously called Convert arity ({multiArity}).");
            return multiConverter;
        }

        public PropertyBindingBuilder<T> StringFormat(string stringFormat) { RequireCurrent().StringFormat = stringFormat; return this; }

        // Sets the Mode of the currently (most recently) opened sub-binding.
        public PropertyBindingBuilder<T> BindingMode(BindingMode bindingMode) { RequireCurrent().Mode = bindingMode; return this; }

        public PropertyBindingBuilder<T> Converter(IValueConverter converter) { RequireCurrent().Converter = converter; return this; }
        public PropertyBindingBuilder<T> Parameter(string converterParameter) { RequireCurrent().ConverterParameter = converterParameter; return this; }
        public PropertyBindingBuilder<T> Source(object source) { RequireCurrent().Source = source; return this; }

        // Sets the Mode of the whole MultiBinding (default for all sub-bindings,
        // unless overridden individually via BindingMode() on a specific Path()).
        public PropertyBindingBuilder<T> MultiMode(BindingMode mode) { multiMode = mode; return this; }

        // ===================== Single binding (unchanged) =====================

        public PropertyBindingBuilder<T> Convert<Q, R>(Func<Q, R> convert)
        {
            var vc = RequireCurrent().Converter as ValueConverter ?? new ValueConverter();
            vc.ConvertFunction = e => convert((Q)e);
            RequireCurrent().Converter = vc;
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q, R>(Func<Q, R> convertBack)
        {
            var vc = RequireCurrent().Converter as ValueConverter ?? new ValueConverter();
            vc.ConvertBackFunction = e => convertBack((Q)e);
            RequireCurrent().Converter = vc;
            return this;
        }

        // ================ Fixed-arity multi binding: forward ================

        public PropertyBindingBuilder<T> Convert<Q1, Q2>(Func<Q1, Q2, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1]) };
            multiArity = 2;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3>(Func<Q1, Q2, Q3, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2]) };
            multiArity = 3;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4>(Func<Q1, Q2, Q3, Q4, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2], (Q4)v[3]) };
            multiArity = 4;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5>(Func<Q1, Q2, Q3, Q4, Q5, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2], (Q4)v[3], (Q5)v[4]) };
            multiArity = 5;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6>(Func<Q1, Q2, Q3, Q4, Q5, Q6, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2], (Q4)v[3], (Q5)v[4], (Q6)v[5]) };
            multiArity = 6;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6, Q7>(Func<Q1, Q2, Q3, Q4, Q5, Q6, Q7, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2], (Q4)v[3], (Q5)v[4], (Q6)v[5], (Q7)v[6]) };
            multiArity = 7;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8>(Func<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2], (Q4)v[3], (Q5)v[4], (Q6)v[5], (Q7)v[6], (Q8)v[7]) };
            multiArity = 8;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9>(Func<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, T> convert)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = v => convert((Q1)v[0], (Q2)v[1], (Q3)v[2], (Q4)v[3], (Q5)v[4], (Q6)v[5], (Q7)v[6], (Q8)v[7], (Q9)v[8]) };
            multiArity = 9;
            arityIsDynamic = false;
            return this;
        }

        // ================ Fixed-arity multi binding: backward ================

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2>(Func<T, (Q1, Q2)> convertBack)
        {
            var mc = RequireMultiConverter(2);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2) = convertBack(value);
                return new object[] { q1, q2 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3>(Func<T, (Q1, Q2, Q3)> convertBack)
        {
            var mc = RequireMultiConverter(3);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3) = convertBack(value);
                return new object[] { q1, q2, q3 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3, Q4>(Func<T, (Q1, Q2, Q3, Q4)> convertBack)
        {
            var mc = RequireMultiConverter(4);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3, q4) = convertBack(value);
                return new object[] { q1, q2, q3, q4 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3, Q4, Q5>(Func<T, (Q1, Q2, Q3, Q4, Q5)> convertBack)
        {
            var mc = RequireMultiConverter(5);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3, q4, q5) = convertBack(value);
                return new object[] { q1, q2, q3, q4, q5 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3, Q4, Q5, Q6>(Func<T, (Q1, Q2, Q3, Q4, Q5, Q6)> convertBack)
        {
            var mc = RequireMultiConverter(6);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3, q4, q5, q6) = convertBack(value);
                return new object[] { q1, q2, q3, q4, q5, q6 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3, Q4, Q5, Q6, Q7>(Func<T, (Q1, Q2, Q3, Q4, Q5, Q6, Q7)> convertBack)
        {
            var mc = RequireMultiConverter(7);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3, q4, q5, q6, q7) = convertBack(value);
                return new object[] { q1, q2, q3, q4, q5, q6, q7 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8>(Func<T, (Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8)> convertBack)
        {
            var mc = RequireMultiConverter(8);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3, q4, q5, q6, q7, q8) = convertBack(value);
                return new object[] { q1, q2, q3, q4, q5, q6, q7, q8 };
            };
            return this;
        }

        public PropertyBindingBuilder<T> ConvertBack<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9>(Func<T, (Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9)> convertBack)
        {
            var mc = RequireMultiConverter(9);
            mc.ConvertBackFunction = value =>
            {
                var (q1, q2, q3, q4, q5, q6, q7, q8, q9) = convertBack(value);
                return new object[] { q1, q2, q3, q4, q5, q6, q7, q8, q9 };
            };
            return this;
        }

        // ===================== Dynamic-arity multi binding =====================

        /// <summary>
        /// Low-level entry point for a multi-binding with an arbitrary, not-known-in-advance
        /// number of Path() calls (e.g. aggregate converters: ConvertAll, ConvertAny, ConvertAtLeast).
        /// Unlike the generic Convert Q1,Q2,...; overloads, the number of Path() calls
        /// is NOT validated against a fixed arity in Build().
        /// convert receives the raw value array in the order Path() was called.
        /// convertBack (optional) must return an array of the same length and order.
        /// </summary>
        public PropertyBindingBuilder<T> ConvertRaw(Func<object[], T> convert, Func<T, object[]> convertBack = null)
        {
            multiConverter = new MultiValueConverter { ConvertFunction = convert, ConvertBackFunction = convertBack };
            arityIsDynamic = true;
            return this;
        }
    }
}


