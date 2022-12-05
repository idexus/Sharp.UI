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

    [MauiWrapper(typeof(Microsoft.Maui.Controls.Grid))] 
    public partial class Grid
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.HorizontalStackLayout))] 
    public partial class HStack
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.StackLayout))] 
    public partial class StackLayout
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.VerticalStackLayout))] 
    public partial class VStack
    {
        public void Add(View view) => this.Children.Add(view);
    }

    [MauiWrapper(typeof(Microsoft.Maui.Controls.ContentPresenter))] 
    public partial class ContentPresenter { }
}
