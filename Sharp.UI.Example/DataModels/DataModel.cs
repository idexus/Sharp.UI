using System.Collections.ObjectModel;

namespace Sharp.UI.Example
{
    [BindableProperties]
    public interface IDataModelProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
    }

    [SharpObject]
    public partial class DataModel : BindableObject, IDataModelProperties
    {
        public DataModel(int id, string name, bool admin)
        {
            this.Id = id;
            this.Name = name;
            this.Admin = admin;
        }

        static List<DataModel> _simpleData;
        public static List<DataModel> SimpleData
        {
            get
            {
                if (_simpleData == null)
                {
                    _simpleData = new List<DataModel>
                    {
                        new DataModel(1, "paul", true),
                        new DataModel(2, "julian", false),
                        new DataModel(3, "luciano", false),
                        new DataModel(4, "john", false),
                        new DataModel(5, "alice", false),
                    };
                }
                return _simpleData;
            }
        }
    }
}