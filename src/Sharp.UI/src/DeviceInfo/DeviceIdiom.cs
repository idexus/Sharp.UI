namespace Sharp.UI
{
    public struct DeviceIdiom
    {
        public enum Enum
        {
            Unknown,
            Phone,
            Tablet,
            Desktop,
            TV,
            Watch
        }

        public const Enum Unknown = Enum.Unknown;
        public const Enum Phone = Enum.Phone;
        public const Enum Tablet = Enum.Tablet;
        public const Enum Desktop = Enum.Desktop;
        public const Enum TV = Enum.TV;
        public const Enum Watch = Enum.Watch;

        public static Enum Current => DeviceInfo.Idiom switch
        {
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Phone => Enum.Phone,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Tablet => Enum.Tablet,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Desktop => Enum.Desktop,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.TV => Enum.TV,
            var t when t == Microsoft.Maui.Devices.DeviceIdiom.Watch => Enum.Watch,
            _ => Enum.Unknown,
        };
    }
}
