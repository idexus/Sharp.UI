using System.Collections;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.AbsoluteLayout))]
    public partial class AbsoluteLayout
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.FlexLayout))]
    public partial class FlexLayout
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Grid))] //OK
    public partial class Grid
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.HorizontalStackLayout))] //OK
    public partial class HStack
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.StackLayout))] //OK
    public partial class StackLayout
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.VerticalStackLayout))] //OK
    public partial class VStack
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentPresenter))] //OK
    public partial class ContentPresenter { }
}
