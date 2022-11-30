
#nullable enable

namespace Sharp.UI
{
    public class OnTheme<T>
    {
        public T? Light { get; set; }
        public T? Dark { get; set; }

        public OnTheme(T? light = default, T? dark = default)
        {

            this.Light = light;
            this.Dark = dark;
        }

        public static implicit operator T?(OnTheme<T> themeValue)
        {
            if (Application.Current?.RequestedTheme == AppTheme.Light && themeValue.Light != null) return themeValue.Light;
            if (Application.Current?.RequestedTheme == AppTheme.Dark && themeValue.Dark != null) return themeValue.Dark;
            return default;
        }
    }
}

#nullable restore
