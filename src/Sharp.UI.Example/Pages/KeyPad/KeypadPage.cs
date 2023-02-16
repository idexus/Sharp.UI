using System;
namespace ExampleApp;

using Sharp.UI;

public class KeypadPage : ContentPage
{
	string[] labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "*", "0", "#" };

	public KeypadPage(KeypadViewModel vm)
	{		
		BindingContext = vm;
		Content =
			new Grid(e => e
				.RowDefinitions(e => e.Absolute(80, count: 5))
				.ColumnDefinitions(e => e.Absolute(100, count: 3))
				.HorizontalOptions(LayoutOptions.Center)
				.VerticalOptions(LayoutOptions.Center)
				.ColumnSpacing(10)
				.RowSpacing(10))
			{
				new Label()
					.ColumnSpan(2)
					.Text(e => e.Path("DisplayText"))
					.LineBreakMode(LineBreakMode.HeadTruncation)
					.VerticalTextAlignment(TextAlignment.Center)
					.HorizontalTextAlignment(TextAlignment.End)
					.Margin(new Thickness(0,0,10,0)),

				new Button("\x21E6").Command(vm.DeleteCharCommand).Column(2),

				labels.Select((label, i) =>
					new Button(label)
						//.HeightRequest(70)
                        .Row(i/3+1).Column(i%3)
                        .Command(vm.AddCharCommand).CommandParameter(label))
			};
	}
}