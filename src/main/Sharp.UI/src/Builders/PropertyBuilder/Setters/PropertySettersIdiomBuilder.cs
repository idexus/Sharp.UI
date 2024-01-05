using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public sealed class PropertySettersIdiomBuilder<T> : IPropertySettersBuilder<T>
    {
        public PropertySettersContext<T> Context { get; set; }

        T newValue;
        T defaultValue;
        Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> defaultConfigure;

        bool isSet;
        bool defaultIsSet;
        bool buildValue;

        public PropertySettersIdiomBuilder(PropertySettersContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (buildValue)
                Context.XamlSetters.Add(new Setter { Property = Context.Property, Value = newValue });
            else if (!isSet)
            {
                if (defaultIsSet)
                {
                    if (defaultConfigure != null)
                        isSet = defaultConfigure(Context).Build();
                    else
                        Context.XamlSetters.Add(new Setter { Property = Context.Property, Value = defaultValue });
                }

            }
            return isSet;
        }

        // Default

        public PropertySettersIdiomBuilder<T> Default(T value)
        {
            if (!defaultIsSet)
            {
                this.defaultValue = value;
                this.defaultIsSet = true;
            }
            return this;
        }

        public PropertySettersIdiomBuilder<T> Default(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!defaultIsSet)
            {
                this.defaultConfigure = configure;
                this.defaultIsSet = true;
            }
            return this;
        }

        // OnPhone

        public PropertySettersIdiomBuilder<T> OnPhone(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Phone)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersIdiomBuilder<T> OnPhone(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Phone)
                isSet = configure(Context).Build();
            return this;
        }

        // OnTablet

        public PropertySettersIdiomBuilder<T> OnTablet(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Tablet)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersIdiomBuilder<T> OnTablet(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Tablet)
                isSet = configure(Context).Build();
            return this;
        }

        // OnDesktop

        public PropertySettersIdiomBuilder<T> OnDesktop(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Desktop)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersIdiomBuilder<T> OnDesktop(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Desktop)
                isSet = configure(Context).Build();
            return this;
        }

        // OnTV

        public PropertySettersIdiomBuilder<T> OnTV(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.TV)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersIdiomBuilder<T> OnTV(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.TV)
                isSet = configure(Context).Build();
            return this;
        }

        // OnWatch

        public PropertySettersIdiomBuilder<T> OnWatch(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Watch)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersIdiomBuilder<T> OnWatch(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Watch)
                isSet = configure(Context).Build();
            return this;
        }
    }
}
