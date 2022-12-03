using System;
namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.PanGestureRecognizer))]
    public partial class PanGestureRecognizer { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.TapGestureRecognizer))]
    public partial class TapGestureRecognizer { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.PinchGestureRecognizer))]
    public partial class PinchGestureRecognizer { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.PointerGestureRecognizer))]
    public partial class PointerGestureRecognizer { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.SwipeGestureRecognizer),
        constructorWithProperties: new[] { "Direction" })]
    public partial class SwipeGestureRecognizer { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DragGestureRecognizer))]
    public partial class DragGestureRecognizer { }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.DropGestureRecognizer))]
    public partial class DropGestureRecognizer { }
}
