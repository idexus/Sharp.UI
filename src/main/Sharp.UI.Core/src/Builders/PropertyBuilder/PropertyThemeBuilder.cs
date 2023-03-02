using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public sealed class PropertyThemeBuilder<T> : IPropertyBuilder<T>
    {
        public PropertyContext<T> Context { get; set; }

        T newValue;
        T defaultValue;
        Func<PropertyContext<T>, IPropertyBuilder<T>> defaultConfigure;

        bool isSet;
        bool defaultIsSet;
        bool buildValue;

        public PropertyThemeBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (buildValue)
                Context.BindableObject.SetValueOrAddSetter(Context.Property, newValue);
            else if (!isSet)
            {
                if (defaultIsSet)
                {
                    if (defaultConfigure != null)
                        isSet = defaultConfigure(Context).Build();
                    else
                        Context.BindableObject.SetValueOrAddSetter(Context.Property, defaultValue);
                }

            }
            return isSet;
        }

        // Default

        public PropertyThemeBuilder<T> Default(T value)
        {
            if (!defaultIsSet)
            {
                this.defaultValue = value;
                this.defaultIsSet = true;
            }
            return this;
        }

        public PropertyThemeBuilder<T> Default(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!defaultIsSet)
            {
                this.defaultConfigure = configure;
                this.defaultIsSet = true;
            }
            return this;
        }

        // OnLight

        public PropertyThemeBuilder<T> OnLight(T value)
        {
            if (!isSet && Application.Current?.RequestedTheme == AppTheme.Light)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyThemeBuilder<T> OnLight(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Application.Current?.RequestedTheme == AppTheme.Light)
                isSet = configure(Context).Build();
            return this;
        }

        // OnDark

        public PropertyThemeBuilder<T> OnDark(T value)
        {
            if (!isSet && Application.Current?.RequestedTheme == AppTheme.Dark)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyThemeBuilder<T> OnDark(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Application.Current?.RequestedTheme == AppTheme.Dark)
                isSet = configure(Context).Build();
            return this;
        }
    }
}
