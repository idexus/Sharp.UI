using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMarkup.Maui
{
    public sealed class PropertySettersPlatformBuilder<T> : IPropertySettersBuilder<T>
    {
        public PropertySettersContext<T> Context { get; set; }

        T newValue;
        T defaultValue;
        Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> defaultConfigure;

        bool isSet;
        bool defaultIsSet;
        bool buildValue;

        public PropertySettersPlatformBuilder(PropertySettersContext<T> context)
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

        public PropertySettersPlatformBuilder<T> Default(T value)
        {
            if (!defaultIsSet)
            {
                this.defaultValue = value;
                this.defaultIsSet = true;
            }
            return this;
        }

        public PropertySettersPlatformBuilder<T> Default(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!defaultIsSet)
            {
                this.defaultConfigure = configure;
                this.defaultIsSet = true;
            }
            return this;
        }

        // MacCatalyst

        public PropertySettersPlatformBuilder<T> OnMacCatalyst(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersPlatformBuilder<T> OnMacCatalyst(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst)
                isSet = configure(Context).Build();
            return this;
        }

        // iOS

        public PropertySettersPlatformBuilder<T> OniOS(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersPlatformBuilder<T> OniOS(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS)
                isSet = configure(Context).Build();
            return this;
        }

        // Android

        public PropertySettersPlatformBuilder<T> OnAndroid(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersPlatformBuilder<T> OnAndroid(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android)
                isSet = configure(Context).Build();
            return this;
        }

        // WinUI

        public PropertySettersPlatformBuilder<T> OnWinUI(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersPlatformBuilder<T> OnWinUI(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
                isSet = configure(Context).Build();
            return this;
        }

        // WinUI

        public PropertySettersPlatformBuilder<T> OnTizen(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Tizen)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertySettersPlatformBuilder<T> OnTizen(Func<PropertySettersContext<T>, IPropertySettersBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Tizen)
                isSet = configure(Context).Build();
            return this;
        }
    }
}
