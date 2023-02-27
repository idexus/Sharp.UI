using System;
namespace Sharp.UI
{
    public class ValueBuilder<T>
    {
        bool defaultIsSet = false;
        bool newValueIsSet = false;
        T @default;
        T newValue;

        public bool ValueIsSet() => defaultIsSet || newValueIsSet;
        public T GetValue()
        {
            if (defaultIsSet || newValueIsSet)
            {
                if (newValueIsSet)
                    return newValue;
                else
                    return @default;
            }
            throw new ArgumentException("No value definied");
        }

        // -- default ---

        public ValueBuilder<T> Default(T value) { { this.@default = value; this.defaultIsSet = true; } return this; }
        public ValueBuilder<T> Value(T value) { { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- app theme ===

        public ValueBuilder<T> OnLight(T value) { if (Application.Current?.RequestedTheme == AppTheme.Light) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnDark(T value) { if (Application.Current?.RequestedTheme == AppTheme.Dark) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device idiom ---

        public ValueBuilder<T> OnPhone(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnTablet(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnDesktop(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnTV(T value) { if (DeviceInfo.Idiom == DeviceIdiom.TV) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnWatch(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device platform ---

        public ValueBuilder<T> OniOS(T value) { if (DeviceInfo.Platform == DevicePlatform.iOS) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnMacCatalyst(T value) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnAndroid(T value) { if (DeviceInfo.Platform == DevicePlatform.Android) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnWinUI(T value) { if (DeviceInfo.Platform == DevicePlatform.WinUI) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnTizen(T value) { if (DeviceInfo.Platform == DevicePlatform.Tizen) { this.newValue = value; this.newValueIsSet = true; } return this; }

    }
}
