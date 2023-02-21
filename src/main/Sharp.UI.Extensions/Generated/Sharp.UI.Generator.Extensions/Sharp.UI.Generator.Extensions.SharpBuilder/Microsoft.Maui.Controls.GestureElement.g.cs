﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class GestureElementExtension
    {
        public static T GestureRecognizers<T>(this T obj,
            IList<Microsoft.Maui.Controls.IGestureRecognizer> gestureRecognizers)
            where T : Microsoft.Maui.Controls.GestureElement
        {
            foreach (var item in gestureRecognizers)
                obj.GestureRecognizers.Add(item);
            return obj;
        }

        public static T GestureRecognizers<T>(this T obj,
            params Microsoft.Maui.Controls.IGestureRecognizer[] gestureRecognizers)
            where T : Microsoft.Maui.Controls.GestureElement
        {
            foreach (var item in gestureRecognizers)
                obj.GestureRecognizers.Add(item);
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore