using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public static class PropertyContextExtension
    {
        // --- PropertyBindingBuilder ---

        public static PropertyBindingBuilder<T> Path<T>(this PropertyContext<T> self, string path)
            => new PropertyBindingBuilder<T>(self).Path(path);

        // --- PropertyIdiomBuilder ---

        public static PropertyIdiomBuilder<T> OnPhone<T>(this PropertyContext<T> self, T value)
            => new PropertyIdiomBuilder<T>(self).OnPhone(value);

        public static PropertyIdiomBuilder<T> OnPhone<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyIdiomBuilder<T>(self).OnPhone(configure);

        public static PropertyIdiomBuilder<T> OnTablet<T>(this PropertyContext<T> self, T value)
            => new PropertyIdiomBuilder<T>(self).OnTablet(value);

        public static PropertyIdiomBuilder<T> OnTablet<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyIdiomBuilder<T>(self).OnTablet(configure);

        public static PropertyIdiomBuilder<T> OnDesktop<T>(this PropertyContext<T> self, T value)
            => new PropertyIdiomBuilder<T>(self).OnDesktop(value);

        public static PropertyIdiomBuilder<T> OnDesktop<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyIdiomBuilder<T>(self).OnDesktop(configure);

        public static PropertyIdiomBuilder<T> OnTV<T>(this PropertyContext<T> self, T value)
            => new PropertyIdiomBuilder<T>(self).OnTV(value);

        public static PropertyIdiomBuilder<T> OnTV<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyIdiomBuilder<T>(self).OnTV(configure);

        public static PropertyIdiomBuilder<T> OnWatch<T>(this PropertyContext<T> self, T value)
            => new PropertyIdiomBuilder<T>(self).OnWatch(value);

        public static PropertyIdiomBuilder<T> OnWatch<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyIdiomBuilder<T>(self).OnWatch(configure);

        // --- PropertyPlatformBuilder ---

        public static PropertyPlatformBuilder<T> OnMacCatalyst<T>(this PropertyContext<T> self, T value)
            => new PropertyPlatformBuilder<T>(self).OnMacCatalyst(value);

        public static PropertyPlatformBuilder<T> OnMacCatalyst<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyPlatformBuilder<T>(self).OnMacCatalyst(configure);

        public static PropertyPlatformBuilder<T> OniOS<T>(this PropertyContext<T> self, T value)
            => new PropertyPlatformBuilder<T>(self).OniOS(value);

        public static PropertyPlatformBuilder<T> OniOS<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyPlatformBuilder<T>(self).OniOS(configure);

        public static PropertyPlatformBuilder<T> OnAndroid<T>(this PropertyContext<T> self, T value)
            => new PropertyPlatformBuilder<T>(self).OnAndroid(value);

        public static PropertyPlatformBuilder<T> OnAndroid<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyPlatformBuilder<T>(self).OnAndroid(configure);

        public static PropertyPlatformBuilder<T> OnWinUI<T>(this PropertyContext<T> self, T value)
            => new PropertyPlatformBuilder<T>(self).OnWinUI(value);

        public static PropertyPlatformBuilder<T> OnWinUI<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyPlatformBuilder<T>(self).OnWinUI(configure);

        public static PropertyPlatformBuilder<T> OnTizen<T>(this PropertyContext<T> self, T value)
            => new PropertyPlatformBuilder<T>(self).OnTizen(value);

        public static PropertyPlatformBuilder<T> OnTizen<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyPlatformBuilder<T>(self).OnTizen(configure);

        // -- PropertyThemeBuilder --

        public static PropertyThemeBuilder<T> OnLight<T>(this PropertyContext<T> self, T value)
            => new PropertyThemeBuilder<T>(self).OnLight(value);

        public static PropertyThemeBuilder<T> OnLight<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyThemeBuilder<T>(self).OnLight(configure);

        public static PropertyThemeBuilder<T> OnDark<T>(this PropertyContext<T> self, T value)
            => new PropertyThemeBuilder<T>(self).OnDark(value);

        public static PropertyThemeBuilder<T> OnDark<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyThemeBuilder<T>(self).OnDark(configure);

        // -- PropertyDynamicResourcesBuilder --

        public static PropertyDynamicResourcesBuilder<T> DynamicResource<T>(this PropertyContext<T> self, string key)
            => new PropertyDynamicResourcesBuilder<T>(self).DynamicResource(key);
    }
}
