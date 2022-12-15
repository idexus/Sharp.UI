namespace Sharp.UI
{
    public class Def<T>
    {

        private readonly Action<T> configure = null;

        public Def() { }
        public Def(Action<T> configure)
        {
            this.configure = configure;
        }

        private Func<T> loadDefault = null;
        private Func<T> loadValue = null;

        public Def<T> Default(Func<T> load) { this.loadDefault = load; return this; }
        public Def<T> Value(Func<T> load) { this.loadValue = load; return this; }

        // --- app theme ===

        public Def<T> Light(Func<T> load) { if (Application.Current?.RequestedTheme == AppTheme.Light) this.loadValue = load; return this; }
        public Def<T> Dark(Func<T> load) { if (Application.Current?.RequestedTheme == AppTheme.Dark) this.loadValue = load; return this; }

        // --- device idiom ---

        public Def<T> OnPhone(Func<T> load) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) this.loadValue = load; return this; }
        public Def<T> OnTablet(Func<T> load) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) this.loadValue = load; return this; }
        public Def<T> OnDesktop(Func<T> load) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) this.loadValue = load; return this; }
        public Def<T> OnTV(Func<T> load) { if (DeviceInfo.Idiom == DeviceIdiom.TV) this.loadValue = load; return this; }
        public Def<T> OnWatch(Func<T> load) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) this.loadValue = load; return this; }

        // --- device platform ---

        public Def<T> OniOS(Func<T> load) { if (DeviceInfo.Platform == DevicePlatform.iOS) this.loadValue = load; return this; }
        public Def<T> OnMacCatalyst(Func<T> load) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) this.loadValue = load; return this; }
        public Def<T> OnAndroid(Func<T> load) { if (DeviceInfo.Platform == DevicePlatform.Android) this.loadValue = load; return this; }
        public Def<T> OnWinUI(Func<T> load) { if (DeviceInfo.Platform == DevicePlatform.WinUI) this.loadValue = load; return this; }
        public Def<T> OnTizen(Func<T> load) { if (DeviceInfo.Platform == DevicePlatform.Tizen) this.loadValue = load; return this; }

        public bool ValueIsSet() => loadValue != null || loadDefault != null;
        public T GetValue()
        {
            T value = default(T);
            bool isData = false;
            if (loadValue != null) { value = loadValue(); isData = true; }
            if (loadDefault != null) { value = loadDefault(); isData = true; }
            if (isData && configure != null) configure(value);
            return MauiWrapper.Value<T>(value);
        }

        public static implicit operator T(Def<T> def) => def.GetValue();
    }
}