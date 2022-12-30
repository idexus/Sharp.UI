namespace Sharp.UI
{
    public static class SetterExtension
    {
        public static Setter OnLight(this Setter setter, object value) { if (Application.Current?.RequestedTheme == AppTheme.Light) setter.Value = value; return setter; }
        public static Setter OnDark(this Setter setter, object value) { if (Application.Current?.RequestedTheme == AppTheme.Dark) setter.Value = value; return setter; }

        public static Setter OnPhone(this Setter setter, object value) { if (DeviceInfo.Idiom == DeviceIdiom.Phone) setter.Value = value; return setter; }
        public static Setter OnTablet(this Setter setter, object value) { if (DeviceInfo.Idiom == DeviceIdiom.Tablet) setter.Value = value; return setter; }
        public static Setter OnDesktop(this Setter setter, object value) { if (DeviceInfo.Idiom == DeviceIdiom.Desktop) setter.Value = value; return setter; }
        public static Setter OnTV(this Setter setter, object value) { if (DeviceInfo.Idiom == DeviceIdiom.TV) setter.Value = value; return setter; }
        public static Setter OnWatch(this Setter setter, object value) { if (DeviceInfo.Idiom == DeviceIdiom.Watch) setter.Value = value; return setter; }

        public static Setter OniOS(this Setter setter, object value) { if (DeviceInfo.Platform == DevicePlatform.iOS) setter.Value = value; return setter; }
        public static Setter OnMacCatalyst(this Setter setter, object value) { if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) setter.Value = value; return setter; }
        public static Setter OnAndroid(this Setter setter, object value) { if (DeviceInfo.Platform == DevicePlatform.Android) setter.Value = value; return setter; }
        public static Setter OnWinUI(this Setter setter, object value) { if (DeviceInfo.Platform == DevicePlatform.WinUI) setter.Value = value; return setter; }
        public static Setter OnTizen(this Setter setter, object value) { if (DeviceInfo.Platform == DevicePlatform.Tizen) setter.Value = value; return setter; }

        public static Setter TargetName(this Setter setter, string targetName) { setter.TargetName = targetName; return setter; }
    }
}