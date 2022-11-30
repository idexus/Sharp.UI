namespace Sharp.UI
{
    public class CollectionDef<T>
    {
        private Func<T[]> loadDefault;
        private Func<T[]> loadValue;        

        public CollectionDef<T> Default(Func<T[]> load) { this.loadDefault = load; return this; }
        public CollectionDef<T> Value(Func<T[]> load) { this.loadValue = load; return this; }

        public CollectionDef<T> Light(Func<T[]> load) { if (Application.Current?.RequestedTheme == AppTheme.Light) this.loadValue = load; return this; }
        public CollectionDef<T> Dark(Func<T[]> load) { if (Application.Current?.RequestedTheme == AppTheme.Dark) this.loadValue = load; return this; }

        public CollectionDef<T> OnPhone(Func<T[]> load) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) this.loadValue = load; return this; }
        public CollectionDef<T> OnTablet(Func<T[]> load) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) this.loadValue = load; return this; }
        public CollectionDef<T> OnDesktop(Func<T[]> load) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) this.loadValue = load; return this; }
        public CollectionDef<T> OnTV(Func<T[]> load) { if (DeviceInfo.Idiom == DeviceIdiom.TV) this.loadValue = load; return this; }
        public CollectionDef<T> OnWatch(Func<T[]> load) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) this.loadValue = load; return this; }

        public CollectionDef<T> OniOS(Func<T[]> load) { if (DeviceInfo.Platform == DevicePlatform.iOS) this.loadValue = load; return this; }
        public CollectionDef<T> OnMacCatalyst(Func<T[]> load) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) this.loadValue = load; return this; }
        public CollectionDef<T> OnAndroid(Func<T[]> load) { if (DeviceInfo.Platform == DevicePlatform.Android) this.loadValue = load; return this; }
        public CollectionDef<T> OnWinUI(Func<T[]> load) { if (DeviceInfo.Platform == DevicePlatform.WinUI) this.loadValue = load; return this; }
        public CollectionDef<T> OnTizen(Func<T[]> load) { if (DeviceInfo.Platform == DevicePlatform.Tizen) this.loadValue = load; return this; }

        internal bool ValueIsSet() => loadDefault != null || loadValue != null;
        internal T[] GetValue()
        {
            if (loadValue != null) return loadValue();
            return loadDefault();
        }
    }
}