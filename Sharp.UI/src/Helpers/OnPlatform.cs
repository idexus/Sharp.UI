#nullable enable

namespace Sharp.UI
{
    public class OnPlatform<T>
    {
        public T? Default { get; set; }
        public T? iOS { get; set; }
        public T? MacCatalyst { get; set; }
        public T? Android { get; set; }
        public T? WinUI { get; set; }
        public T? Tizen { get; set; }

        public OnPlatform(
            T? Default = default,
            T? iOS = default,
            T? MacCatalyst = default,
            T? Android = default,
            T? WinUI = default,
            T? Tizen = default)
        {
            this.Default = Default;
            this.iOS = iOS;
            this.MacCatalyst = MacCatalyst;
            this.Android = Android;
            this.WinUI = WinUI;
            this.Tizen = Tizen;
        }

        public static implicit operator T?(OnPlatform<T> onPlatform)
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS && onPlatform.iOS != null) return onPlatform.iOS;
            if (DeviceInfo.Platform == DevicePlatform.MacCatalyst && onPlatform.MacCatalyst != null) return onPlatform.MacCatalyst;
            if (DeviceInfo.Platform == DevicePlatform.Android && onPlatform.Android != null) return onPlatform.Android;
            if (DeviceInfo.Platform == DevicePlatform.WinUI && onPlatform.WinUI != null) return onPlatform.WinUI;
            if (DeviceInfo.Platform == DevicePlatform.Tizen && onPlatform.Tizen != null) return onPlatform.Tizen;

            return onPlatform.Default;
        }
    }
}

#nullable restore
