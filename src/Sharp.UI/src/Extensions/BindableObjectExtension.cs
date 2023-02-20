using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;

namespace Sharp.UI
{
    public static partial class BindableObjectExtension
    {
        public static T SetProperty<T>(this T obj, BindableProperty property, object value) where T : BindableObject
        {
            obj.SetValue(property, value);
            return obj;
        }

        public static T Bind<T>(this T obj,
            BindableProperty property,
            string sourcePath,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            string converterParameter = null,
            string stringFormat = null,
            object source = null) where T : BindableObject
        {
            obj.SetBinding(
                targetProperty: property,
                binding: new Microsoft.Maui.Controls.Binding(
                    path: sourcePath,
                    mode: mode,
                    converter: converter,
                    converterParameter: converterParameter,
                    stringFormat: stringFormat,
                    source: source));
            return obj;
        }

        public static T BindTemplatedParent<T>(this T obj,
            BindableProperty property,
            string sourcePath,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            string converterParameter = null,
            string stringFormat = null) where T : BindableObject
        {
            obj.SetBinding(
                targetProperty: property,
                binding: new Microsoft.Maui.Controls.Binding(
                    path: sourcePath,
                    mode: mode,
                    converter: converter,
                    converterParameter: converterParameter,
                    stringFormat: stringFormat,
                    source: RelativeBindingSource.TemplatedParent));
            return obj;
        }

        public static T RegisterName<T>(this T obj, string name, BindableObject scopedElement) where T : BindableObject
        {
            var nameScope = NameScope.GetNameScope(scopedElement);
            if (nameScope == null)
            {
                nameScope = new NameScope();
                NameScope.SetNameScope(scopedElement, nameScope);
            }
            nameScope.RegisterName(name, obj);
            return obj;
        }
    }
}