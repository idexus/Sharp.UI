namespace Sharp.UI
{
    public struct DevicePlatform
    {
        public enum Enum
        {
            Unknown,
            iOS,
            MacCatalyst,
            Android,
            WinUI,
            Tizen
        }

        public const Enum Unknown = Enum.Unknown;
        public const Enum iOS = Enum.iOS;
        public const Enum MacCatalyst = Enum.MacCatalyst;
        public const Enum Android = Enum.Android;
        public const Enum WinUI = Enum.WinUI;
        public const Enum Tizen = Enum.Tizen;

        public static Enum Current => DeviceInfo.Platform switch
        {
            var t when t == Microsoft.Maui.Devices.DevicePlatform.iOS => Enum.iOS,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.MacCatalyst => Enum.MacCatalyst,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.Android => Enum.Android,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.WinUI => Enum.WinUI,
            var t when t == Microsoft.Maui.Devices.DevicePlatform.Tizen => Enum.Tizen,
            _ => Enum.Unknown,
        };
    }
}
