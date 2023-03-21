
namespace ExampleApp;

using CodeMarkup.Maui;

public class ListViewPage : ContentPage
{
    ListViewPageViewModel viewModel => BindingContext as ListViewPageViewModel;

    public ListViewPage(ListViewPageViewModel viewModel)
	{
        BindingContext = viewModel;

        Content = new ScrollView(e => e.Margin(new Thickness(0, 30, 0, 0)))
        {
            new VStack
            {
                new Label("EntryCell")
                    .FontSize(40)
                    .TextColor(AppColors.Gray400)
                    .BackgroundColor(AppColors.Gray900),

                new ListView()
                    .ItemsSource(e => e.Path(nameof(ListViewPageViewModel.SimpleData)))
                    .ItemTemplate(() => 
                        new EntryCell()
                            .Text(e => e.Path(nameof(DataModel.Name)))),
                
                new Label("SwitchCell")
                    .FontSize(40)
                    .TextColor(AppColors.Gray400)
                    .BackgroundColor(AppColors.Gray900),

                new ListView()
                    .ItemsSource(e => e.Path(nameof(ListViewPageViewModel.SimpleData)))
                    .ItemTemplate(() => 
                        new SwitchCell()
                            .Text(e => e.Path(nameof(DataModel.Name)))
                            .On(e => e.Path(nameof(DataModel.Admin)))),
                
                new Label("TextCell")
                    .FontSize(40)
                    .TextColor(AppColors.Gray400)
                    .BackgroundColor(AppColors.Gray900),

                new ListView()
                    .ItemsSource(e => e.Path(nameof(ListViewPageViewModel.SimpleData)))
                    .ItemTemplate(() => 
                        new TextCell()
                            .Text(e => e.Path(nameof(DataModel.Name)))
                            .Detail(e => e.Path(nameof(DataModel.Id)).StringFormat("id: {0}"))),
                
                new Label("ViewCell")
                    .FontSize(40)
                    .TextColor(AppColors.Gray400)
                    .BackgroundColor(AppColors.Gray900),

                new ListView()
                    .ItemsSource(e => e.Path(nameof(ListViewPageViewModel.SimpleData)))
                    .ItemTemplate(() => 
                        new ViewCell
                        {
                            new HStack
                            {
                                new Label()
                                    .Text(e => e.Path("Id").StringFormat("Id: {0}, "))
                                    .FontSize(30)
                                    .TextColor(AppColors.Gray400),
                                new Label()
                                    .Text(e => e.Path("Name").StringFormat("Name: {0} "))
                                    .FontSize(30)
                            }
                        })                
            }
        };
    }
}