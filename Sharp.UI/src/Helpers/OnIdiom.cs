#nullable enable

namespace Sharp.UI
{
    public class OnIdiom<T>
    {
        public T? Default { get; set; }
        public T? Phone { get; set; }
        public T? Tablet { get; set; }
        public T? Desktop { get; set; }
        public T? TV { get; set; }
        public T? Watch { get; set; }

        public OnIdiom(
            T? Default = default,
            T? Phone = default,
            T? Tablet = default,
            T? Desktop = default,
            T? TV = default,
            T? Watch = default)
        {
            this.Default = Default;
            this.Phone = Phone;
            this.Tablet = Tablet;
            this.Desktop = Desktop;
            this.TV = TV;
            this.Watch = Watch;
        }

        public static implicit operator T?(OnIdiom<T> onPlatform)
        {
            if (DeviceInfo.Idiom == DeviceIdiom.Phone && onPlatform.Phone != null) return onPlatform.Phone;
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet && onPlatform.Tablet != null) return onPlatform.Tablet;
            if (DeviceInfo.Idiom == DeviceIdiom.Phone && onPlatform.Desktop != null) return onPlatform.Desktop;
            if (DeviceInfo.Idiom == DeviceIdiom.TV && onPlatform.TV != null) return onPlatform.TV;
            if (DeviceInfo.Idiom == DeviceIdiom.Watch && onPlatform.Watch != null) return onPlatform.Watch;

            return onPlatform.Default;
        }
    }
}

#nullable restore
