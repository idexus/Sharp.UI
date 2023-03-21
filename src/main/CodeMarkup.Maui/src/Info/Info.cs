namespace CodeMarkup.Maui
{
    public partial struct Info
    {
        public static AppTheme RequestedTheme => Application.Current?.RequestedTheme switch
        {
            var t when t == Microsoft.Maui.ApplicationModel.AppTheme.Light => AppTheme.Light,
            var t when t == Microsoft.Maui.ApplicationModel.AppTheme.Dark => AppTheme.Dark,
            _ => AppTheme.Unspecified,
        };

        public static DeviceIdiom CurrentIdiom { get; } = DeviceInfo.Idiom switch
        {
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Phone => DeviceIdiom.Phone,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Tablet => DeviceIdiom.Tablet,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Desktop => DeviceIdiom.Desktop,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.TV => DeviceIdiom.TV,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Watch => DeviceIdiom.Watch,
            _ => DeviceIdiom.Unknown,
        };

        public static DevicePlatform CurrentPlatform { get; } = DeviceInfo.Platform switch
        {
            var t when t == Microsoft.Maui.Devices.DevicePlatform.iOS => DevicePlatform.iOS,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst => DevicePlatform.MacCatalyst,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.Android => DevicePlatform.Android,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.WinUI => DevicePlatform.WinUI,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.Tizen => DevicePlatform.Tizen,
            _ => DevicePlatform.Unknown,
        };
    }    
}
