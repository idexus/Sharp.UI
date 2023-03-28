using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarkup.Maui
{
    public sealed class PropertySettersContext<T>
    {
        public PropertySettersContext(List<Setter> xamlSetters, BindableProperty property)
        {
            XamlSetters = xamlSetters;
            Property = property;
        }

        public List<Setter> XamlSetters = new();
        public BindableProperty Property { get; set; }
    }
}
