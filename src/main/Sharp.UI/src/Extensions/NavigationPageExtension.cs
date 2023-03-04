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
        public static async Task PushAsync<TPage>(this NavigationPage navigation)
           where TPage : Page
        {
            await Task.Delay(1);
            await navigation.PushAsync(DataTemplate.Activate<TPage>());
        }
    }
}
