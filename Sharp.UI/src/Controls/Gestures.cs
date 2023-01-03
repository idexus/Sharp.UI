namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.PanGestureRecognizer))]
    public partial class PanGestureRecognizer { }

    [SharpObject(typeof(Microsoft.Maui.Controls.TapGestureRecognizer))]
    public partial class TapGestureRecognizer { }

    [SharpObject(typeof(Microsoft.Maui.Controls.PinchGestureRecognizer))]
    public partial class PinchGestureRecognizer { }

    [SharpObject(typeof(Microsoft.Maui.Controls.PointerGestureRecognizer))]
    public partial class PointerGestureRecognizer { }

    [SharpObject(typeof(Microsoft.Maui.Controls.SwipeGestureRecognizer))]
    public partial class SwipeGestureRecognizer
    {
        public SwipeGestureRecognizer(SwipeDirection direction) : this()
        {
            this.Direction = direction;
        }
    }

    [SharpObject(typeof(Microsoft.Maui.Controls.DragGestureRecognizer))]
    public partial class DragGestureRecognizer { }

    [SharpObject(typeof(Microsoft.Maui.Controls.DropGestureRecognizer))]
    public partial class DropGestureRecognizer { }
}
