using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.UI
{
    public static partial class NavigationPageExtension
    {
        public static Task PushAsync<TNavigation>(this TNavigation navigation, Type pageType)
            where TNavigation : NavigationPage
        {
            return navigation.PushAsync(DataTemplate.Activate<Page>(pageType));
        }
    }
}
