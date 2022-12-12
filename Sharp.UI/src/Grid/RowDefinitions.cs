using System.Collections;

namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.RowDefinition))]
    public partial class RowDefinition
    {
        public static RowDefinition Auto = new RowDefinition(0, GridUnitType.Auto);
        public static RowDefinition Star(double height = 1) => new RowDefinition(height, GridUnitType.Star);
        public static RowDefinition Absolute(double height) => new RowDefinition(height, GridUnitType.Absolute);

        public RowDefinition(double height) : this()
        {
            this.Height = new GridLength(height);
        }

        public RowDefinition(double height, GridUnitType unitType) : this()
        {
            this.Height = new GridLength(height, unitType);
        }
    }

    public class RowDefinitions : IEnumerable<RowDefinition>
    {
        List<RowDefinition> items = new List<RowDefinition>();

        public IEnumerator<RowDefinition> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public RowDefinitions Auto()
        {
            items.Add(RowDefinition.Auto);
            return this;
        }

        public RowDefinitions Star(double height = 1)
        {
            items.Add(RowDefinition.Star(height));
            return this;
        }

        public RowDefinitions Absolute(double height)
        {
            items.Add(RowDefinition.Absolute(height));
            return this;
        }
    }
}
