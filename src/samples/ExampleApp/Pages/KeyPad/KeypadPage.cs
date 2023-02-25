using System;
namespace ExampleApp;

using Sharp.UI;

public class KeypadPage : ContentPage
{
	string[] labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "*", "0", "#" };

	public KeypadPage(KeypadViewModel vm)
	{		
		BindingContext = vm;

		Content = new Grid
		{
			// ---- properties ----

            e => e 
                .RowDefinitions(e => e.Absolute(80, count: 5))
				.ColumnDefinitions(e => e.Absolute(100, count: 3))
				.CenterHorizontally()
				.CenterVertically()
				.ColumnSpacing(10)
				.RowSpacing(10),

			// ---- content here ----

            new Label()
				.ColumnSpan(2)
				.Text(e => e.Path("DisplayText"))
				.LineBreakMode(LineBreakMode.HeadTruncation)
				.VerticalTextAlignment(TextAlignment.Center)
				.HorizontalTextAlignment(TextAlignment.End)
				.Margin(new Thickness(0,0,10,0)),

			new Button("\x21E6").Command(vm.DeleteCharCommand).Column(2),

			// using LINQ inside

			grid =>
			{
				for(int i = 0; i < labels.Length; i++)
				{
					var label = labels[i];
					grid.Add(new Button(label)
						.Row(i/3+1).Column(i%3)
						.Command(vm.AddCharCommand).CommandParameter(label));
				}
			}

			//labels.Select((label, i) =>
			//	new Button(label)
   //                 .Row(i/3+1).Column(i%3)
   //                 .Command(vm.AddCharCommand).CommandParameter(label))
		};
	}
}