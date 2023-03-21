namespace ExampleApp;

using CodeMarkup.Maui;

public class TableViewPage : ContentPage
{
	public TableViewPage()
	{
        Content = new TableView()
		{
			new TableSection("Chapter 1")
			{
				new TextCell("1. Introduction to .NET MAUI")
					.Detail("Learn about .NET MAUI and what it provides."),

                new TextCell("2. Anatomy of an app")
					.Detail("Learn about .NET MAUI and what it provides."),

				new TextCell("3. Text")
					.Detail("Learn about .NET MAUI and what it provides."),

				new TextCell("4. Dealing with sizes")
					.Detail("Learn about .NET MAUI and what it provides."),

				new TextCell("5. XAML vs code")
					.Detail("Learn about .NET MAUI and what it provides."),
            },

            new TableSection("Chapter 2")
            {
                new TextCell("1. Introduction to .NET MAUI")
                    .Detail("Learn about .NET MAUI and what it provides."),

                new TextCell("2. Anatomy of an app")
                    .Detail("Learn about .NET MAUI and what it provides."),

                new TextCell("3. Text")
                    .Detail("Learn about .NET MAUI and what it provides."),

                new TextCell("4. Dealing with sizes")
                    .Detail("Learn about .NET MAUI and what it provides."),

                new TextCell("5. XAML vs code")
                    .Detail("Learn about .NET MAUI and what it provides."),

            },
        };
	}
}
