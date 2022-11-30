using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sharp.UI.Example
{
    public partial class DataModel : ObservableObject
    {
        [ObservableProperty] public int _id;
        [ObservableProperty] public string _name;
        [ObservableProperty] public bool _admin;

        public DataModel(int id, string name, bool admin)
        {
            Id = id;
            Name = name;
            Admin = admin;
        }

        public static ObservableCollection<DataModel> SimpleData = new ObservableCollection<DataModel>
        {
            new DataModel(1, "paul", true),
            new DataModel(2, "julian", false),
            new DataModel(3, "luciano", false),
            new DataModel(4, "john", false),
            new DataModel(5, "alice", false),
        };
    }
}