using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public sealed class PropertyIdiomBuilder<T> : IPropertyBuilder<T>
    {
        public PropertyContext<T> Context { get; set; }

        T newValue;
        T defaultValue;
        Func<PropertyContext<T>, IPropertyBuilder<T>> defaultConfigure;

        bool isSet;
        bool defaultIsSet;
        bool buildValue;

        public PropertyIdiomBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (buildValue)
                Context.BindableObject.SetValue(Context.Property, newValue);
            else if (!isSet)
            {
                if (defaultIsSet)
                {
                    if (defaultConfigure != null)
                        isSet = defaultConfigure(Context).Build();
                    else
                        Context.BindableObject.SetValue(Context.Property, defaultValue);
                }

            }
            return isSet;
        }

        // Default

        public PropertyIdiomBuilder<T> Default(T value)
        {
            if (!defaultIsSet)
            {
                this.defaultValue = value;
                this.defaultIsSet = true;
            }
            return this;
        }

        public PropertyIdiomBuilder<T> Default(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!defaultIsSet)
            {
                this.defaultConfigure = configure;
                this.defaultIsSet = true;
            }
            return this;
        }

        // OnPhone

        public PropertyIdiomBuilder<T> OnPhone(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Phone)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyIdiomBuilder<T> OnPhone(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Phone)
                isSet = configure(Context).Build();
            return this;
        }

        // OnTablet

        public PropertyIdiomBuilder<T> OnTablet(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Tablet)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyIdiomBuilder<T> OnTablet(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Tablet)
                isSet = configure(Context).Build();
            return this;
        }

        // OnDesktop

        public PropertyIdiomBuilder<T> OnDesktop(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Desktop)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyIdiomBuilder<T> OnDesktop(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Desktop)
                isSet = configure(Context).Build();
            return this;
        }

        // OnTV

        public PropertyIdiomBuilder<T> OnTV(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.TV)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyIdiomBuilder<T> OnTV(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.TV)
                isSet = configure(Context).Build();
            return this;
        }

        // OnWatch

        public PropertyIdiomBuilder<T> OnWatch(T value)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Watch)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyIdiomBuilder<T> OnWatch(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Info.CurrentIdiom == DeviceIdiom.Watch)
                isSet = configure(Context).Build();
            return this;
        }
    }
}
