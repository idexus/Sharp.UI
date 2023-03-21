
namespace ExampleApp;

using CodeMarkup.Maui;

[BindableProperties]
public interface ListViewPageViewModelProperties
{
    List<DataModel> SimpleData { get; set; }
}

[CodeMarkup]
public partial class ListViewPageViewModel : BindableObject, ListViewPageViewModelProperties
{
    public ListViewPageViewModel()
    {
        SimpleData = DataModel.SimpleData;
        var test = SimpleData.First().Name;
    }
}
