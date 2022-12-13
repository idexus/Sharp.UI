using System.Collections;

namespace Sharp.UI
{
    [SharpObject(typeof(Microsoft.Maui.Controls.ColumnDefinition))]
    public partial class ColumnDefinition
    {
        public static ColumnDefinition Auto = new ColumnDefinition(0, GridUnitType.Auto);
        public static ColumnDefinition Star(double width = 1) => new ColumnDefinition(width, GridUnitType.Star);
        public static ColumnDefinition Absolute(double width) => new ColumnDefinition(width, GridUnitType.Absolute);

        public ColumnDefinition(double width) : this()
        {
            this.Width = new GridLength(width);
        }

        public ColumnDefinition(double width, GridUnitType unitType) : this()
        {
            this.Width = new GridLength(width, unitType);
        }
    }

    public class ColumnDefinitions : IEnumerable<ColumnDefinition>
    {
        List<ColumnDefinition> items = new List<ColumnDefinition>();

        public IEnumerator<ColumnDefinition> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public ColumnDefinitions Auto()
        {
            items.Add(ColumnDefinition.Auto);
            return this;
        }

        public ColumnDefinitions Star(double width = 1)
        {
            items.Add(ColumnDefinition.Star(width));
            return this;
        }

        public ColumnDefinitions Absolute(double width)
        {
            items.Add(ColumnDefinition.Absolute(width));
            return this;
        }
    }
}
