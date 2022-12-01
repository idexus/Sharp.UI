namespace Sharp.UI
{
    public class BindableDef<T>
    {
        internal bool defaultIsSet = false;
        internal bool newValueIsSet = false;
        internal T @default;
        internal T newValue;

        public BindableDef<T> Default(T value) { { this.@default = value; this.defaultIsSet = true; } return this; }
        public BindableDef<T> Value(T value) { { this.newValue = value; this.newValueIsSet = true; } return this; }
        // --- app theme ===

        public BindableDef<T> Light(T value) { if (Application.Current?.RequestedTheme == AppTheme.Light) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> Dark(T value) { if (Application.Current?.RequestedTheme == AppTheme.Dark) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device idiom ---

        public BindableDef<T> OnPhone(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnTablet(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnDesktop(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnTV(T value) { if (DeviceInfo.Idiom == DeviceIdiom.TV) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnWatch(T value) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) { this.newValue = value; this.newValueIsSet = true; } return this; }

        // --- device platform ---

        public BindableDef<T> OniOS(T value) { if (DeviceInfo.Platform == DevicePlatform.iOS) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnMacCatalyst(T value) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnAndroid(T value) { if (DeviceInfo.Platform == DevicePlatform.Android) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnWinUI(T value) { if (DeviceInfo.Platform == DevicePlatform.WinUI) { this.newValue = value; this.newValueIsSet = true; } return this; }
        public BindableDef<T> OnTizen(T value) { if (DeviceInfo.Platform == DevicePlatform.Tizen) { this.newValue = value; this.newValueIsSet = true; } return this; }

        internal bool ValueIsSet() => defaultIsSet || newValueIsSet;
        internal T GetValue()
        {
            if (newValueIsSet) return newValue;
            return @default;
        }

        public static implicit operator T(BindableDef<T> def) => def.GetValue();

        //--- bindable ---

        public BindableDef<T> Path(string path) { this.path = path; return this; }
        public BindableDef<T> StringFormat(string stringFormat) { this.stringFormat = stringFormat; return this; }
        public BindableDef<T> BindingMode(BindingMode bindingMode) { this.bindingMode = bindingMode; return this; }
        public BindableDef<T> Converter(IValueConverter converter) { this.converter = converter; return this; }
        public BindableDef<T> Parameter(string converterParameter) { this.converterParameter = converterParameter; return this; }
        public BindableDef<T> Source(object source) { this.source = source; return this; }

        private string path = null;
        private BindingMode bindingMode = Microsoft.Maui.Controls.BindingMode.Default;
        private IValueConverter converter = null;
        private string converterParameter = null;
        private string stringFormat = null;
        private object source = null;

        private BindableObject obj;
        private BindableProperty property;

        public BindableDef(BindableObject obj, BindableProperty property)
        {
            this.obj = obj;
            this.property = property;
        }

        internal void BindProperty()
        {
            var mauiSource = MauiWrapper.GetObject<object>(source);
            if (path != null)
            {
                obj.SetBinding(
                    targetProperty: property,
                    binding: new Microsoft.Maui.Controls.Binding(
                        path: path,
                        mode: bindingMode,
                        converter: converter,
                        converterParameter: converterParameter,
                        stringFormat: stringFormat,
                        source: mauiSource));
            }
        }
    }
}