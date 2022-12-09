using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;

namespace Sharp.UI
{
    public static class IBindableObjectExtension
    {
        public static T SetProperty<T>(this T obj,
            BindableProperty property,
            object value)
            where T : IBindableObject
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.BindableObject>(obj);
            mauiObject.SetValue(property, value);
            return obj;
        }

        public static T Bind<T>(this T obj,
            BindableProperty property,
            string sourcePath,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            string converterParameter = null,
            string stringFormat = null,
            object source = null) where T : IBindableObject
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.BindableObject>(obj);
            mauiObject.SetBinding(
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
            string stringFormat = null) where T : IBindableObject
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.BindableObject>(obj);
            mauiObject.SetBinding(
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

        public static T RegisterName<T>(this T obj, string name, IBindableObject scopedElement)
            where T : IBindableObject
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.BindableObject>(obj);
            var mauiScopedElement = MauiWrapper.GetObject<Microsoft.Maui.Controls.BindableObject>(scopedElement);

            var nameScope = NameScope.GetNameScope(mauiScopedElement);
            if (nameScope == null)
            {
                nameScope = new NameScope();
                NameScope.SetNameScope(mauiScopedElement, nameScope);
            }
            nameScope.RegisterName(name, mauiObject);
            return obj;
        }
    }
}