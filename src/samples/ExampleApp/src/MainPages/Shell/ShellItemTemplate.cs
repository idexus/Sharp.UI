namespace ExampleApp;

using Sharp.UI;

public sealed partial class ShellItemTemplate : ContentView
{
    public ShellItemTemplate()
    {
        Content = new Grid
		{
			new Image()
				.Source(e => e.Path("FlyoutIcon"))
				.Margin(5)
				.HeightRequest(45),

			new Label()
                .RegisterName("TitleLabel", scopedElement: this)
                .Column(1)
				.Text(e => e.Path("Title"))
				.Padding(new Thickness(50,0,0,0))
				.FontSize(20)
				.VerticalTextAlignment(TextAlignment.Center)
		}
		.ColumnDefinitions(e => e.Absolute(30).Auto());

        this.VisualStateGroups(new VisualStateGroupList
        {
            new VisualState()
                .Name(VisualStates.VisualElement.Normal)
                .Setters(
                    new Setters<ContentView>(e => e.BackgroundColor(Colors.Transparent)),
                    new Setters<Label>(e => e
                        .TextColor(e => e.OnLight(AppColors.Gray900).OnDark(Colors.White))
                        .FontAttributes(FontAttributes.None)
                    ).TargetName("TitleLabel")
                ),

            new VisualState()
                .Name(VisualStates.CollectionView.Selected)
                .Setters(
                    new Setters<ContentView>(e => e.BackgroundColor(e => e.OnPhone(AppColors.Primary).Default(Colors.Transparent))),
                    new Setters<Label>(e => e
                        .TextColor(Colors.White)
                        .FontAttributes(FontAttributes.Bold)
                    ).TargetName("TitleLabel")
                )
        });
    }
}
