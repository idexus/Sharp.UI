using Sharp.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    /// <summary>
    /// Identifies which fluent step of a binding pipeline raised an exception.
    /// </summary>
    public enum ConverterStage
    {
        /// <summary>Intermediate per-path transformation, source to target direction.</summary>
        Map,

        /// <summary>Intermediate per-path transformation, target to source direction.</summary>
        MapBack,

        /// <summary>Terminal step producing the target property value.</summary>
        Convert,

        /// <summary>Terminal step producing the source value(s).</summary>
        ConvertBack,
    }

    /// <summary>
    /// Thrown when a fluent converter step receives a value that does not match the type
    /// declared by the caller (the Q / R type arguments of Map, MapBack or Convert).
    ///
    /// The binding infrastructure does not catch converter exceptions, so this surfaces as
    /// an unhandled exception with a stack trace pointing into Microsoft.Maui.Controls -
    /// the message therefore has to be self-explanatory on its own.
    /// </summary>
    public sealed class SharpUIConverterException : InvalidOperationException
    {
        /// <summary>Type of the object that owns the bound property, e.g. Label.</summary>
        public Type OwnerType { get; }

        /// <summary>Name of the bound target property, e.g. "Text".</summary>
        public string TargetProperty { get; }

        /// <summary>ReturnType of the bound BindableProperty.</summary>
        public Type PropertyType { get; }

        /// <summary>Binding path of the failing sub-binding, when known.</summary>
        public string BindingPath { get; }

        /// <summary>Type the caller declared on the delegate parameter.</summary>
        public Type ExpectedType { get; }

        /// <summary>Runtime type the binding actually supplied, or null.</summary>
        public Type ActualType { get; }

        /// <summary>
        /// The type MAUI asked the converter to produce in this call. Its meaning depends on
        /// direction: the target property type when converting forward, the source property
        /// type when converting back.
        /// </summary>
        public Type RequestedType { get; }

        /// <summary>The fluent step that failed.</summary>
        public ConverterStage Stage { get; }

        /// <summary>Zero-based value index inside a multi-binding, or null for single bindings.</summary>
        public int? ValueIndex { get; }

        internal SharpUIConverterException(
            Type ownerType,
            string targetProperty,
            Type propertyType,
            string bindingPath,
            Type expectedType,
            Type actualType,
            Type requestedType,
            ConverterStage stage,
            int? valueIndex)
            : base(BuildMessage(ownerType, targetProperty, bindingPath, expectedType, actualType, stage, valueIndex))
        {
            OwnerType = ownerType;
            TargetProperty = targetProperty;
            PropertyType = propertyType;
            BindingPath = bindingPath;
            ExpectedType = expectedType;
            ActualType = actualType;
            RequestedType = requestedType;
            Stage = stage;
            ValueIndex = valueIndex;
        }

        static string BuildMessage(
            Type ownerType, string targetProperty, string bindingPath,
            Type expectedType, Type actualType, ConverterStage stage, int? valueIndex)
        {
            var target = ownerType is null ? targetProperty : $"{ownerType.Name}.{targetProperty}";
            var where = bindingPath is null ? string.Empty : $" (Path=\"{bindingPath}\")";
            var slot = valueIndex is null ? string.Empty : $", value #{valueIndex}";
            var actual = actualType is null ? "null" : actualType.FullName;

            // The hint has to stay actionable: it may only suggest changing something the
            // caller actually controls, which is the type argument of this very step.
            var hint = stage switch
            {
                ConverterStage.Map =>
                    "Declare the Map parameter with the type that reaches this step - the raw source " +
                    "type for the first Map, or the result type of the preceding Map.",
                ConverterStage.Convert =>
                    "Declare the Convert parameter with the type that reaches this step - the raw source " +
                    $"type, or insert a Map(...) step producing '{expectedType.FullName}'.",
                ConverterStage.MapBack =>
                    "Declare the MapBack parameter with the result type of the Map(...) step it inverts.",
                _ =>
                    "Declare the parameter with the type actually supplied by the binding.",
            };

            return
                $"Sharp.UI: the {stage} delegate bound to {target}{where}{slot} expects " +
                $"'{expectedType.FullName}', but the binding supplied '{actual}'. {hint}";
        }
    }

    /// <summary>
    /// Thrown when the value of a bound property cannot be represented as T, the generic
    /// argument of the builder.
    ///
    /// T is not chosen by the caller: it is emitted by the generated fluent extension method
    /// from the CLR property type, while the binding value comes from the registered
    /// BindableProperty. When the two disagree there is nothing the caller can fix in a
    /// delegate signature, so this is reported separately from
    /// <see cref="SharpUIConverterException"/>.
    /// </summary>
    public sealed class SharpUIBindingTypeMismatchException : InvalidOperationException
    {
        /// <summary>Type of the object that owns the bound property.</summary>
        public Type OwnerType { get; }

        /// <summary>Name of the bound target property.</summary>
        public string TargetProperty { get; }

        /// <summary>Binding path of the failing sub-binding, when known.</summary>
        public string BindingPath { get; }

        /// <summary>The builder's T - the CLR property type seen by the generator.</summary>
        public Type BuilderType { get; }

        /// <summary>ReturnType of the registered BindableProperty.</summary>
        public Type PropertyType { get; }

        /// <summary>Runtime type of the value that could not be unboxed, or null.</summary>
        public Type ActualType { get; }

        /// <summary>The fluent step that failed.</summary>
        public ConverterStage Stage { get; }

        internal SharpUIBindingTypeMismatchException(
            Type ownerType,
            string targetProperty,
            string bindingPath,
            Type builderType,
            Type propertyType,
            Type actualType,
            ConverterStage stage)
            : base(BuildMessage(ownerType, targetProperty, bindingPath, builderType, propertyType, actualType, stage))
        {
            OwnerType = ownerType;
            TargetProperty = targetProperty;
            BindingPath = bindingPath;
            BuilderType = builderType;
            PropertyType = propertyType;
            ActualType = actualType;
            Stage = stage;
        }

        static string BuildMessage(
            Type ownerType, string targetProperty, string bindingPath,
            Type builderType, Type propertyType, Type actualType, ConverterStage stage)
        {
            var target = ownerType is null ? targetProperty : $"{ownerType.Name}.{targetProperty}";
            var where = bindingPath is null ? string.Empty : $" (Path=\"{bindingPath}\")";
            var actual = actualType is null ? "null" : actualType.FullName;
            var declared = propertyType is null ? "unknown" : propertyType.FullName;

            return
                $"Sharp.UI: cannot hand the value of {target}{where} to the {stage} delegate. " +
                $"The builder is typed as '{builderType.FullName}' (CLR property type), the registered " +
                $"BindableProperty returns '{declared}', and the value is '{actual}'. " +
                "These have to agree - this is a property/BindableProperty registration mismatch, " +
                "not a problem with the delegate signature.";
        }
    }

    /// <summary>
    /// Fluent binding builder.
    ///
    /// The chain is a pipeline built from two kinds of steps:
    ///
    ///   Map / MapBack         - intermediate, attached to the most recently opened Path().
    ///                           The result type is free, because the value travels further
    ///                           down the pipeline. Several Map steps can be stacked.
    ///
    ///   Convert / ConvertBack - terminal, produces the value of the target property.
    ///                           The result type is pinned to T, so a mismatch is a
    ///                           compile-time error rather than a runtime surprise.
    ///
    /// A single Path() plus a terminal step produces a plain Binding.
    /// Several Path() calls plus a multi-value terminal step produce a MultiBinding.
    /// </summary>
    public sealed class PropertyBindingBuilder<T> : IPropertyBuilder<T>
    {
        // =====================================================================
        // Internal model
        // =====================================================================

        // A single sub-binding opened by Path().
        // Each call to Path() always creates a new entry; modifiers
        // (Source, StringFormat, BindingMode, Parameter, Converter, Map, MapBack)
        // act on the most recently opened entry.
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

        // Everything a converter lambda needs for diagnostics, snapshotted at build time.
        // Deliberately a separate object: capturing 'this' or 'Context' in a converter lambda
        // would keep the builder and its entry list alive for as long as the binding lives.
        sealed class BindingSite
        {
            public Type OwnerType;
            public string PropertyName;
            public Type PropertyType;   // BindableProperty.ReturnType
            public string Path;         // single binding
            public string[] Paths;      // multi binding, in Path() order

            public string PathAt(int? index)
            {
                if (index is null) return Path;
                if (Paths is null || index.Value < 0 || index.Value >= Paths.Length) return null;
                return Paths[index.Value];
            }
        }

        /// <summary>
        /// Converter of a single sub-binding. Holds an ordered pipeline of Map stages followed
        /// by an optional terminal stage. A MAUI Binding exposes only one Converter slot, so
        /// the steps are composed here rather than chained by MAUI.
        ///
        /// Forward:  source value -> map[0] -> map[1] -> ... -> terminal -> target property
        /// Backward: target property -> terminal -> ... -> map[1] -> map[0] -> source
        ///
        /// A stage without a function in a given direction is an identity step, so declaring
        /// only ConvertBack (write-side normalisation) is valid and does not break reading.
        ///
        /// Stage delegates receive the Type that MAUI asked for in this call. Its meaning
        /// differs by direction - target property type when converting forward, source property
        /// type when converting back - and it is used for diagnostics only.
        /// </summary>
        public sealed class ValueConverter : IValueConverter
        {
            internal sealed class Stage
            {
                public Func<object, Type, object> Forward;
                public Func<object, Type, object> Backward;
            }

            readonly List<Stage> mapStages = new();
            Stage terminal;

            internal bool HasMapStages => mapStages.Count > 0;
            internal bool HasTerminal => terminal is not null;

            internal Stage AddMapStage()
            {
                var stage = new Stage();
                mapStages.Add(stage);
                return stage;
            }

            internal Stage LastMapStage => mapStages.Count > 0 ? mapStages[mapStages.Count - 1] : null;

            internal Stage Terminal => terminal ??= new Stage();

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                for (var i = 0; i < mapStages.Count; i++)
                    if (mapStages[i].Forward is not null)
                        value = mapStages[i].Forward(value, targetType);

                if (terminal?.Forward is not null)
                    value = terminal.Forward(value, targetType);

                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (terminal?.Backward is not null)
                    value = terminal.Backward(value, targetType);

                for (var i = mapStages.Count - 1; i >= 0; i--)
                    if (mapStages[i].Backward is not null)
                        value = mapStages[i].Backward(value, targetType);

                return value;
            }
        }

        // Converter for a MultiBinding: N raw values <-> T.
        // Used both by the generic Convert<Q1,Q2,...> overloads (fixed arity)
        // and by ConvertRaw (arbitrary, dynamic arity).
        sealed class MultiValueConverter : IMultiValueConverter
        {
            internal Func<object[], Type, T> ConvertFunction;
            internal Func<T, object[]> ConvertBackFunction;
            internal BindingSite Site;

            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values is null || ConvertFunction is null)
                    return Binding.DoNothing;

                // MultiBinding proxies start out as null, so this runs before every
                // sub-binding has resolved. DoNothing leaves the target untouched;
                // returning null would wipe it instead.
                foreach (var value in values)
                    if (value is null || ReferenceEquals(value, BindableProperty.UnsetValue))
                        return Binding.DoNothing;

                return ConvertFunction(values, targetType);
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                if (ConvertBackFunction is null)
                    return null;

                if (!TryUnbox<T>(value, out var typed))
                    throw new SharpUIBindingTypeMismatchException(
                        Site?.OwnerType, Site?.PropertyName, null,
                        typeof(T), Site?.PropertyType, value?.GetType(), ConverterStage.ConvertBack);

                return ConvertBackFunction(typed);
            }
        }

        // =====================================================================
        // State
        // =====================================================================

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

        // =====================================================================
        // Build
        // =====================================================================

        public bool Build()
        {
            if (entries.Count == 0) return false;

            // Single Path() and no multi-value terminal step -> plain Binding.
            if (entries.Count == 1 && multiConverter is null)
            {
                if (entries[0].Converter is ValueConverter single && single.HasMapStages && !single.HasTerminal)
                    throw new InvalidOperationException(
                        "Map() was used without a terminal Convert(). Map() only transforms the value on its " +
                        "way through the pipeline; add Convert(...) to produce the target property value.");

                Context.BindableObject.SetBinding(Context.Property, entries[0].ToBinding());
                return true;
            }

            if (multiConverter is null)
                throw new InvalidOperationException(
                    $"Path() was called {entries.Count} times without a multi-value Convert() or ConvertRaw(). " +
                    "Calling Path() more than once requires Convert<Q1,Q2,...>(...) or ConvertRaw(...).");

            // With fixed arity (Convert<Q1,Q2,...>) the number of Path() calls must match.
            // With ConvertRaw the arity is intentionally dynamic and this check is skipped.
            if (!arityIsDynamic && multiArity != entries.Count)
                throw new InvalidOperationException(
                    $"The number of Path() calls ({entries.Count}) does not match the Convert arity ({multiArity}).");

            // Paths are known only once every Path() has been opened, so the multi-binding
            // diagnostics are completed here rather than in the Convert<...> overload.
            if (multiConverter.Site is not null)
                multiConverter.Site.Paths = entries.Select(e => e.Path).ToArray();

            var multiBinding = new Microsoft.Maui.Controls.MultiBinding
            {
                Bindings = entries.Select(e => (Microsoft.Maui.Controls.BindingBase)e.ToBinding()).ToList(),
                Converter = multiConverter,
                Mode = multiMode
            };

            Context.BindableObject.SetBinding(Context.Property, multiBinding);
            return true;
        }

        // =====================================================================
        // Path and per-path modifiers
        // =====================================================================

        public PropertyBindingBuilder<T> Path(string path)
        {
            current = new Entry { Path = path };
            entries.Add(current);
            return this;
        }

        Entry RequireCurrent()
        {
            if (current is null)
                throw new InvalidOperationException(
                    "Call Path() before using Source/StringFormat/BindingMode/Parameter/Converter/Map/Convert.");
            return current;
        }

        // Returns the pipeline converter of the current entry, creating it on demand.
        // Rejects mixing the fluent pipeline with an externally supplied IValueConverter,
        // which would otherwise be silently overwritten.
        ValueConverter RequirePipeline(Entry entry)
        {
            if (entry.Converter is null)
            {
                var created = new ValueConverter();
                entry.Converter = created;
                return created;
            }

            if (entry.Converter is ValueConverter pipeline)
                return pipeline;

            throw new InvalidOperationException(
                "Map()/Convert() cannot be combined with a converter supplied through Converter(...). " +
                "Use either the fluent pipeline or your own IValueConverter for a given Path().");
        }

        MultiValueConverter RequireMultiConverter(int arity)
        {
            if (multiConverter is null)
                throw new InvalidOperationException(
                    "ConvertBack for multiple values requires a preceding call to Convert<Q1,Q2,...>, " +
                    "which defines the forward direction and the number of bindings.");
            if (arityIsDynamic)
                throw new InvalidOperationException(
                    "This builder uses ConvertRaw (dynamic arity) - pass convertBack directly as the " +
                    "second argument of ConvertRaw(...) instead of calling ConvertBack<Q1,Q2,...>.");
            if (multiArity != arity)
                throw new InvalidOperationException(
                    $"The ConvertBack arity ({arity}) does not match the previously called Convert arity ({multiArity}).");
            return multiConverter;
        }

        BindingSite SiteFor(Entry entry) => new BindingSite
        {
            OwnerType = Context.BindableObject?.GetType(),
            PropertyName = Context.Property?.PropertyName,
            PropertyType = Context.Property?.ReturnType,
            Path = entry.Path,
        };

        BindingSite MultiSite() => new BindingSite
        {
            OwnerType = Context.BindableObject?.GetType(),
            PropertyName = Context.Property?.PropertyName,
            PropertyType = Context.Property?.ReturnType,
            // Paths are filled in by Build(), once all of them are known.
        };

        public PropertyBindingBuilder<T> StringFormat(string stringFormat) { RequireCurrent().StringFormat = stringFormat; return this; }

        // Sets the Mode of the currently (most recently) opened sub-binding.
        public PropertyBindingBuilder<T> BindingMode(BindingMode bindingMode) { RequireCurrent().Mode = bindingMode; return this; }

        public PropertyBindingBuilder<T> Parameter(string converterParameter) { RequireCurrent().ConverterParameter = converterParameter; return this; }

        public PropertyBindingBuilder<T> Source(object source) { RequireCurrent().Source = source; return this; }

        // Attaches a hand-written converter to the current sub-binding.
        // Mutually exclusive with the Map()/Convert() pipeline on the same Path().
        public PropertyBindingBuilder<T> Converter(IValueConverter converter)
        {
            var entry = RequireCurrent();

            if (entry.Converter is ValueConverter)
                throw new InvalidOperationException(
                    "Converter(...) cannot be combined with Map()/Convert() on the same Path(). " +
                    "Use either the fluent pipeline or your own IValueConverter.");

            entry.Converter = converter;
            return this;
        }

        // Sets the Mode of the whole MultiBinding (default for all sub-bindings,
        // unless overridden individually via BindingMode() on a specific Path()).
        public PropertyBindingBuilder<T> MultiMode(BindingMode mode) { multiMode = mode; return this; }

        // =====================================================================
        // Value unboxing
        //
        // Binding values arrive boxed as object. A direct (Q)v cast fails for any numeric
        // mismatch (int source, double parameter) and the binding pipeline does not catch
        // converter exceptions, so the failure would surface as an unhandled crash with a
        // stack trace pointing into Microsoft.Maui.Controls. The IConvertible path absorbs
        // the common, clearly intended widenings; everything else is reported explicitly.
        // =====================================================================

        static bool TryUnbox<TValue>(object value, out TValue result)
        {
            if (value is TValue typed) { result = typed; return true; }

            if (value is null)
            {
                result = default;
                return default(TValue) is null;   // string, Nullable<>, class - yes; int/double/bool - no
            }

            if (value is IConvertible && typeof(IConvertible).IsAssignableFrom(typeof(TValue)))
            {
                try
                {
                    result = (TValue)System.Convert.ChangeType(value, typeof(TValue), CultureInfo.InvariantCulture);
                    return true;
                }
                catch (Exception ex) when (ex is InvalidCastException or FormatException or OverflowException) { }
            }

            result = default;
            return false;
        }

        // For types the caller declared (the Q / R arguments of Map, MapBack, Convert).
        static TValue UnboxDeclared<TValue>(
            object value, BindingSite site, Type requestedType, ConverterStage stage, int? valueIndex = null)
        {
            if (TryUnbox<TValue>(value, out var result))
                return result;

            throw new SharpUIConverterException(
                site?.OwnerType, site?.PropertyName, site?.PropertyType, site?.PathAt(valueIndex),
                typeof(TValue), value?.GetType(), requestedType, stage, valueIndex);
        }

        // For T, which the caller does not choose - it comes from the generated extension method.
        static T UnboxTargetValue(object value, BindingSite site, ConverterStage stage)
        {
            if (TryUnbox<T>(value, out var result))
                return result;

            throw new SharpUIBindingTypeMismatchException(
                site?.OwnerType, site?.PropertyName, site?.Path,
                typeof(T), site?.PropertyType, value?.GetType(), stage);
        }

        // =====================================================================
        // Intermediate steps (per Path)
        // =====================================================================

        /// <summary>
        /// Transforms the value of the current Path() before it reaches the terminal step.
        /// The result type is free: in a MultiBinding it becomes the value handed to
        /// Convert&lt;Q1,Q2,...&gt;, in a single binding it is the input of Convert&lt;Q&gt;.
        /// Multiple Map() calls on one Path() are applied in declaration order.
        /// </summary>
        public PropertyBindingBuilder<T> Map<Q, R>(Func<Q, R> map)
        {
            var entry = RequireCurrent();
            var stage = RequirePipeline(entry).AddMapStage();
            var site = SiteFor(entry);

            stage.Forward = (v, requested) =>
                map(UnboxDeclared<Q>(v, site, requested, ConverterStage.Map));

            return this;
        }

        /// <summary>
        /// Inverse of the most recently declared Map() on the current Path(). Required for
        /// two-way bindings whose path uses Map(); without it the mapped path is effectively
        /// read-only.
        /// </summary>
        public PropertyBindingBuilder<T> MapBack<R, Q>(Func<R, Q> mapBack)
        {
            var entry = RequireCurrent();
            var stage = RequirePipeline(entry).LastMapStage
                ?? throw new InvalidOperationException(
                    "MapBack() requires a preceding Map() on the same Path(), which defines the step being inverted.");
            var site = SiteFor(entry);

            stage.Backward = (v, requested) =>
                mapBack(UnboxDeclared<R>(v, site, requested, ConverterStage.MapBack));

            return this;
        }

        // =====================================================================
        // Terminal step - single binding
        // =====================================================================

        /// <summary>
        /// Produces the value of the target property from a single Path().
        /// The result type is pinned to T, so a mismatch is a compile-time error.
        /// </summary>
        public PropertyBindingBuilder<T> Convert<Q>(Func<Q, T> convert)
        {
            var entry = RequireCurrent();
            var stage = RequirePipeline(entry).Terminal;
            var site = SiteFor(entry);

            stage.Forward = (v, requested) =>
                convert(UnboxDeclared<Q>(v, site, requested, ConverterStage.Convert));

            return this;
        }

        /// <summary>
        /// Produces the source value from the target property value. Valid on its own, without
        /// a preceding Convert(), for write-side normalisation of a value that needs no
        /// conversion when read.
        /// </summary>
        public PropertyBindingBuilder<T> ConvertBack<Q>(Func<T, Q> convertBack)
        {
            var entry = RequireCurrent();
            var stage = RequirePipeline(entry).Terminal;
            var site = SiteFor(entry);

            stage.Backward = (v, _) =>
                convertBack(UnboxTargetValue(v, site, ConverterStage.ConvertBack));

            return this;
        }

        // =====================================================================
        // Terminal step - multi binding, forward
        // =====================================================================

        public PropertyBindingBuilder<T> Convert<Q1, Q2>(Func<Q1, Q2, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1))
            };
            multiArity = 2;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3>(Func<Q1, Q2, Q3, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2))
            };
            multiArity = 3;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4>(Func<Q1, Q2, Q3, Q4, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2),
                    UnboxDeclared<Q4>(v[3], site, requested, ConverterStage.Convert, 3))
            };
            multiArity = 4;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5>(Func<Q1, Q2, Q3, Q4, Q5, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2),
                    UnboxDeclared<Q4>(v[3], site, requested, ConverterStage.Convert, 3),
                    UnboxDeclared<Q5>(v[4], site, requested, ConverterStage.Convert, 4))
            };
            multiArity = 5;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6>(Func<Q1, Q2, Q3, Q4, Q5, Q6, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2),
                    UnboxDeclared<Q4>(v[3], site, requested, ConverterStage.Convert, 3),
                    UnboxDeclared<Q5>(v[4], site, requested, ConverterStage.Convert, 4),
                    UnboxDeclared<Q6>(v[5], site, requested, ConverterStage.Convert, 5))
            };
            multiArity = 6;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6, Q7>(Func<Q1, Q2, Q3, Q4, Q5, Q6, Q7, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2),
                    UnboxDeclared<Q4>(v[3], site, requested, ConverterStage.Convert, 3),
                    UnboxDeclared<Q5>(v[4], site, requested, ConverterStage.Convert, 4),
                    UnboxDeclared<Q6>(v[5], site, requested, ConverterStage.Convert, 5),
                    UnboxDeclared<Q7>(v[6], site, requested, ConverterStage.Convert, 6))
            };
            multiArity = 7;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8>(Func<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2),
                    UnboxDeclared<Q4>(v[3], site, requested, ConverterStage.Convert, 3),
                    UnboxDeclared<Q5>(v[4], site, requested, ConverterStage.Convert, 4),
                    UnboxDeclared<Q6>(v[5], site, requested, ConverterStage.Convert, 5),
                    UnboxDeclared<Q7>(v[6], site, requested, ConverterStage.Convert, 6),
                    UnboxDeclared<Q8>(v[7], site, requested, ConverterStage.Convert, 7))
            };
            multiArity = 8;
            arityIsDynamic = false;
            return this;
        }

        public PropertyBindingBuilder<T> Convert<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9>(Func<Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, T> convert)
        {
            var site = MultiSite();

            multiConverter = new MultiValueConverter
            {
                Site = site,
                ConvertFunction = (v, requested) => convert(
                    UnboxDeclared<Q1>(v[0], site, requested, ConverterStage.Convert, 0),
                    UnboxDeclared<Q2>(v[1], site, requested, ConverterStage.Convert, 1),
                    UnboxDeclared<Q3>(v[2], site, requested, ConverterStage.Convert, 2),
                    UnboxDeclared<Q4>(v[3], site, requested, ConverterStage.Convert, 3),
                    UnboxDeclared<Q5>(v[4], site, requested, ConverterStage.Convert, 4),
                    UnboxDeclared<Q6>(v[5], site, requested, ConverterStage.Convert, 5),
                    UnboxDeclared<Q7>(v[6], site, requested, ConverterStage.Convert, 6),
                    UnboxDeclared<Q8>(v[7], site, requested, ConverterStage.Convert, 7),
                    UnboxDeclared<Q9>(v[8], site, requested, ConverterStage.Convert, 8))
            };
            multiArity = 9;
            arityIsDynamic = false;
            return this;
        }

        // =====================================================================
        // Terminal step - multi binding, backward
        //
        // The tuple returned by convertBack is written back in Path() order.
        // Each element then travels through that path's MapBack steps, if any.
        // =====================================================================

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

        // =====================================================================
        // Dynamic-arity multi binding
        // =====================================================================

        /// <summary>
        /// Low-level terminal step for a multi-binding with an arbitrary, not-known-in-advance
        /// number of Path() calls (e.g. aggregate converters: ConvertAll, ConvertAny,
        /// ConvertAtLeast). Unlike the generic Convert&lt;Q1,Q2,...&gt; overloads, the number of
        /// Path() calls is NOT validated against a fixed arity in Build(), and the values are
        /// not unboxed for you - convert receives the raw value array in the order Path() was
        /// called. convertBack (optional) must return an array of the same length and order.
        /// </summary>
        public PropertyBindingBuilder<T> ConvertRaw(Func<object[], T> convert, Func<T, object[]> convertBack = null)
        {
            multiConverter = new MultiValueConverter
            {
                Site = MultiSite(),
                ConvertFunction = (v, _) => convert(v),
                ConvertBackFunction = convertBack
            };
            arityIsDynamic = true;
            return this;
        }
    }
}
