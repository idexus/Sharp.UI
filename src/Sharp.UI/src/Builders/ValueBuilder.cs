using System;
namespace Sharp.UI
{
    public class ValueBuilder<T>
    {
        internal bool defaultIsSet = false;
        internal bool newValueIsSet = false;
        internal T @default;
        internal T newValue;


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

        public ValueBuilder<T> OnLight(T value) { if (AppTheme.Requested == AppTheme.Light) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnDark(T value) { if (AppTheme.Requested == AppTheme.Dark) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device idiom ---

        public ValueBuilder<T> OnPhone(T value) { if (DeviceIdiom.Current == DeviceIdiom.Phone) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnTablet(T value) { if (DeviceIdiom.Current == DeviceIdiom.Tablet) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnDesktop(T value) { if (DeviceIdiom.Current == DeviceIdiom.Desktop) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnTV(T value) { if (DeviceIdiom.Current == DeviceIdiom.TV) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnWatch(T value) { if (DeviceIdiom.Current == DeviceIdiom.Watch) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device platform ---

        public ValueBuilder<T> OniOS(T value) { if (DevicePlatform.Current == DevicePlatform.iOS) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnMacCatalyst(T value) { if (DevicePlatform.Current == DevicePlatform.MacCatalyst) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnAndroid(T value) { if (DevicePlatform.Current == DevicePlatform.Android) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnWinUI(T value) { if (DevicePlatform.Current == DevicePlatform.WinUI) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueBuilder<T> OnTizen(T value) { if (DevicePlatform.Current == DevicePlatform.Tizen) { this.newValue = value; this.newValueIsSet = true; } return this; }

    }
}
