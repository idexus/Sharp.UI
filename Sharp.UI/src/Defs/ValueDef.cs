using System;
namespace Sharp.UI
{
    public class ValueDef<T>
    {
        internal bool defaultIsSet = false;
        internal bool newValueIsSet = false;
        internal T @default;
        internal T newValue;

        public ValueDef<T> Default(T value) { { this.@default = value; this.defaultIsSet = true; } return this; }
        public ValueDef<T> Value(T value) { { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- app theme ===

        public ValueDef<T> Light(T value) { if (Application.Current?.RequestedTheme == AppTheme.Light) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> Dark(T value) { if (Application.Current?.RequestedTheme == AppTheme.Dark) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device idiom ---

        public ValueDef<T> OnPhone(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnTablet(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnDesktop(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnTV(T value) { if (DeviceInfo.Idiom == DeviceIdiom.TV) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnWatch(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device platform ---

        public ValueDef<T> OniOS(T value) { if (DeviceInfo.Platform == DevicePlatform.iOS) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnMacCatalyst(T value) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnAndroid(T value) { if (DeviceInfo.Platform == DevicePlatform.Android) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnWinUI(T value) { if (DeviceInfo.Platform == DevicePlatform.WinUI) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public ValueDef<T> OnTizen(T value) { if (DeviceInfo.Platform == DevicePlatform.Tizen) { this.newValue = value; this.newValueIsSet = true; } return this; }

        public bool ValueIsSet() => defaultIsSet || newValueIsSet;
        public T GetValue()
        {
            if (newValueIsSet) return newValue;
            return @default;
        }

        public static implicit operator T(ValueDef<T> def) => def.GetValue();
    }
}
