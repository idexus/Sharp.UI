
namespace ExampleApp;

using Sharp.UI;

[BindableProperties]
public interface ListViewPageViewModelProperties
{
    List<DataModel> SimpleData { get; set; }
}

[SharpObject]
public partial class ListViewPageViewModel : BindableObject, ListViewPageViewModelProperties
{
    public ListViewPageViewModel()
    {
        SimpleData = DataModel.SimpleData;
        var test = SimpleData.First().Name;
    }
}
