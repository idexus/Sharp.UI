namespace Sharp.UI
{
    public class LazyValueBuilder<T>
    {
        private readonly Func<T, T> configure = null;

        public LazyValueBuilder() { }
        public LazyValueBuilder(Func<T, T> configure)
        {
            this.configure = configure;
        }

        public Func<T> LoadDefault = null;
        public Func<T> LoadValue = null;

        public bool ValueIsSet() => LoadValue != null || LoadDefault != null;
        public T GetValue()
        {
            if (LoadDefault != null || LoadValue != null)
            {
                T value;
                if (LoadValue != null)
                    value = LoadValue();
                else
                    value = LoadDefault();
                if (configure != null)
                    value = configure(value);
                return value;
            }
            throw new ArgumentException("No value definied");
        }

        public LazyValueBuilder<T> Default(Func<T> loadValue) { this.LoadDefault = loadValue; return this; }
        public LazyValueBuilder<T> Value(Func<T> loadValue) { this.LoadValue = loadValue; return this; }

        // --- app theme ===

        public LazyValueBuilder<T> OnLight(Func<T> loadValue) { if (Application.Current?.RequestedTheme == AppTheme.Light) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnDark(Func<T> loadValue) { if (Application.Current?.RequestedTheme == AppTheme.Dark) { this.LoadValue = loadValue; } return this; }

        // --- device idiom ---

        public LazyValueBuilder<T> OnPhone(Func<T> loadValue) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnTablet(Func<T> loadValue) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnDesktop(Func<T> loadValue) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnTV(Func<T> loadValue) { if (DeviceInfo.Idiom == DeviceIdiom.TV) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnWatch(Func<T> loadValue) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) { this.LoadValue = loadValue; } return this; }

        // --- device platform ---

        public LazyValueBuilder<T> OniOS(Func<T> loadValue) { if (DeviceInfo.Platform == DevicePlatform.iOS) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnMacCatalyst(Func<T> loadValue) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnAndroid(Func<T> loadValue) { if (DeviceInfo.Platform == DevicePlatform.Android) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnWinUI(Func<T> loadValue) { if (DeviceInfo.Platform == DevicePlatform.WinUI) { this.LoadValue = loadValue; } return this; }
        public LazyValueBuilder<T> OnTizen(Func<T> loadValue) { if (DeviceInfo.Platform == DevicePlatform.Tizen) { this.LoadValue = loadValue; } return this; }
    }
}