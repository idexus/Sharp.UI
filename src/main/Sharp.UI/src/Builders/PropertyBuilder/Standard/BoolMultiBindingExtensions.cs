using Sharp.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public static class BoolMultiBindingExtensions
    {
        public static PropertyBindingBuilder<bool> ConvertAll(this PropertyBindingBuilder<bool> b) =>
            b.ConvertRaw(values => values.All(v => (bool)v));

        public static PropertyBindingBuilder<bool> ConvertAny(this PropertyBindingBuilder<bool> b) =>
            b.ConvertRaw(values => values.Any(v => (bool)v));

        public static PropertyBindingBuilder<bool> ConvertNone(this PropertyBindingBuilder<bool> b) =>
            b.ConvertRaw(values => values.All(v => !(bool)v));

        public static PropertyBindingBuilder<bool> ConvertAtLeast(this PropertyBindingBuilder<bool> b, int count) =>
            b.ConvertRaw(values => values.Count(v => (bool)v) >= count);

        public static PropertyBindingBuilder<bool> ConvertExactly(this PropertyBindingBuilder<bool> b, int count) =>
            b.ConvertRaw(values => values.Count(v => (bool)v) == count);
    }
}
