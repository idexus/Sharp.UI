using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public sealed class PropertyPlatformBuilder<T> : IPropertyBuilder<T>
    {
        public PropertyContext<T> Context { get; set; }

        T newValue;
        T defaultValue;
        Func<PropertyContext<T>, IPropertyBuilder<T>> defaultConfigure;

        bool isSet;
        bool defaultIsSet;
        bool buildValue;

        public PropertyPlatformBuilder(PropertyContext<T> context)
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

        public PropertyPlatformBuilder<T> Default(T value)
        {
            if (!defaultIsSet)
            {
                this.defaultValue = value;
                this.defaultIsSet = true;
            }
            return this;
        }

        public PropertyPlatformBuilder<T> Default(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!defaultIsSet)
            {
                this.defaultConfigure = configure;
                this.defaultIsSet = true;
            }
            return this;
        }

        // MacCatalyst

        public PropertyPlatformBuilder<T> OnMacCatalyst(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyPlatformBuilder<T> OnMacCatalyst(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst)
                isSet = configure(Context).Build();
            return this;
        }

        // iOS

        public PropertyPlatformBuilder<T> OniOS(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyPlatformBuilder<T> OniOS(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS)
                isSet = configure(Context).Build();
            return this;
        }

        // Android

        public PropertyPlatformBuilder<T> OnAndroid(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyPlatformBuilder<T> OnAndroid(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android)
                isSet = configure(Context).Build();
            return this;
        }

        // WinUI

        public PropertyPlatformBuilder<T> OnWinUI(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyPlatformBuilder<T> OnWinUI(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
                isSet = configure(Context).Build();
            return this;
        }

        // WinUI

        public PropertyPlatformBuilder<T> OnTizen(T value)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Tizen)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyPlatformBuilder<T> OnTizen(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Tizen)
                isSet = configure(Context).Build();
            return this;
        }
    }
}
