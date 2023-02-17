namespace Sharp.UI
{
    public struct AppTheme
    {
        public enum Enum
        {
            Unspecified,
            Light,
            Dark
        }

        public const Enum Unspecified = Enum.Unspecified;
        public const Enum Light = Enum.Light;
        public const Enum Dark = Enum.Dark;

        public static Enum Requested => Application.Current?.RequestedTheme switch
        {
            var t when t == Microsoft.Maui.ApplicationModel.AppTheme.Light => Enum.Light,
            var t when t == Microsoft.Maui.ApplicationModel.AppTheme.Dark => Enum.Dark,
            _ => Enum.Unspecified,
        };        
    }    
}
