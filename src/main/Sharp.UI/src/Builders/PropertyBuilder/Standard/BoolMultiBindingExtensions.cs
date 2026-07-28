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
        public static PropertyBindingBuilder<bool> MultiAll(this PropertyBindingBuilder<bool> b) =>
            b.MultiConvertRaw<bool>(values =>
            {
                for (var i = 0; i < values.Count; i++) if (!values[i]) return false;
                return true;
            });

        public static PropertyBindingBuilder<bool> MultiAny(this PropertyBindingBuilder<bool> b) =>
            b.MultiConvertRaw<bool>(values =>
            {
                for (var i = 0; i < values.Count; i++) if (values[i]) return true;
                return false;
            });

        public static PropertyBindingBuilder<bool> MultiNone(this PropertyBindingBuilder<bool> b) =>
            b.MultiConvertRaw<bool>(values =>
            {
                for (var i = 0; i < values.Count; i++) if (values[i]) return false;
                return true;
            });

        public static PropertyBindingBuilder<bool> MultiAtLeast(this PropertyBindingBuilder<bool> b, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            return b.MultiConvertRaw<bool>(values => CountTrue(values) >= count);
        }

        public static PropertyBindingBuilder<bool> MultiExactly(this PropertyBindingBuilder<bool> b, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            return b.MultiConvertRaw<bool>(values => CountTrue(values) == count);
        }

        static int CountTrue(IReadOnlyList<bool> values)
        {
            var n = 0;
            for (var i = 0; i < values.Count; i++) if (values[i]) n++;
            return n;
        }
    }
}
