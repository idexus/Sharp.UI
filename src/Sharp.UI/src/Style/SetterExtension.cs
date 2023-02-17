namespace Sharp.UI
{
    public static class SetterExtension
    {
        public static Setter OnLight(this Setter setter, object value) { if (AppTheme.Requested == AppTheme.Light) setter.Value = value; return setter; }
        public static Setter OnDark(this Setter setter, object value) { if (AppTheme.Requested == AppTheme.Dark) setter.Value = value; return setter; }

        public static Setter OnPhone(this Setter setter, object value) { if (DeviceIdiom.Current == DeviceIdiom.Phone) setter.Value = value; return setter; }
        public static Setter OnTablet(this Setter setter, object value) { if (DeviceIdiom.Current == DeviceIdiom.Tablet) setter.Value = value; return setter; }
        public static Setter OnDesktop(this Setter setter, object value) { if (DeviceIdiom.Current == DeviceIdiom.Desktop) setter.Value = value; return setter; }
        public static Setter OnTV(this Setter setter, object value) { if (DeviceIdiom.Current == DeviceIdiom.TV) setter.Value = value; return setter; }
        public static Setter OnWatch(this Setter setter, object value) { if (DeviceIdiom.Current == DeviceIdiom.Watch) setter.Value = value; return setter; }

        public static Setter OniOS(this Setter setter, object value) { if (DevicePlatform.Current == DevicePlatform.iOS) setter.Value = value; return setter; }
        public static Setter OnMacCatalyst(this Setter setter, object value) { if (DevicePlatform.Current == DevicePlatform.MacCatalyst) setter.Value = value; return setter; }
        public static Setter OnAndroid(this Setter setter, object value) { if (DevicePlatform.Current == DevicePlatform.Android) setter.Value = value; return setter; }
        public static Setter OnWinUI(this Setter setter, object value) { if (DevicePlatform.Current == DevicePlatform.WinUI) setter.Value = value; return setter; }
        public static Setter OnTizen(this Setter setter, object value) { if (DevicePlatform.Current == DevicePlatform.Tizen) setter.Value = value; return setter; }

        public static Setter TargetName(this Setter setter, string targetName) { setter.TargetName = targetName; return setter; }
    }
}