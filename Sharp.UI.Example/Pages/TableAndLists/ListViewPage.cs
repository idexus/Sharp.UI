
namespace Sharp.UI.Example;

using Sharp.UI;

public class ListViewPage : ContentPage
{
	public ListViewPage()
	{
        Content = new ScrollView {
            new VStack
            {
                new Label("TextCell")
                    .FontSize(40)
                    .TextColor(Colors.Red)
                    .BackgroundColor(AppColors.Gray900),
                new ListView(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new TextCell()
                            .Text(e => e.Path(nameof(DataModel.Name)))
                            .Detail(e => e.Path(nameof(DataModel.Id)).StringFormat("id: {0}"))
                    ),

                new Label("ImageCell")
                    .FontSize(40)
                    .TextColor(Colors.Red)
                    .BackgroundColor(AppColors.Gray900),
                new ListView(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new ImageCell()
                            .ImageSource("dotnet_bot.png")
                            .Text(e => e.Path(nameof(DataModel.Name)))
                            .Detail(e => e.Path(nameof(DataModel.Id)).StringFormat("id: {0}"))
                    ),

                new Label("SwitchCell")
                    .FontSize(40)
                    .TextColor(Colors.Red)
                    .BackgroundColor(AppColors.Gray900),
                new ListView(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new SwitchCell()
                            .Text(e => e.Path(nameof(DataModel.Name)))
                            .On(e => e.Path(nameof(DataModel.Admin)))
                    ),

                new Label("EntryCell")
                    .FontSize(40)
                    .TextColor(Colors.Red)
                    .BackgroundColor(AppColors.Gray900),
                new ListView(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new EntryCell()
                            .Text(e => e.Path(nameof(DataModel.Name)))
                    ),

                new Label("ViewCell")
                    .FontSize(40)
                    .TextColor(Colors.Red)
                    .BackgroundColor(AppColors.Gray900),
                new ListView()
                    .ItemsSource(DataModel.SimpleData)
                    .ItemTemplate(() =>
                        new ViewCell
                        {
                            new HStack
                            {
                                new Label()
                                    .Text(e => e.Path("Id").StringFormat("Id: {0}, "))
                                    .FontSize(30)
                                    .TextColor(Colors.Blue),
                                new Label()
                                    .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                                    .FontSize(30)
                            }
                        })
            }
        }
        .Margin(new Thickness(0,30,0,0));
    }
}
