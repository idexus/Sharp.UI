using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public sealed class PropertyContext<T>
    {
        public PropertyContext(BindableObject bindableObject, BindableProperty property)
        {
            BindableObject = bindableObject;
            Property = property;
        }

        public BindableObject BindableObject { get; set; }
        public BindableProperty Property { get; set; }
    }
}
