using System.Collections;

namespace CodeMarkup.Maui
{
    public class RowDefinitionBuilder
    {
        public List<RowDefinition> Items { get; } = new List<RowDefinition>();

        public RowDefinitionBuilder Auto(int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new RowDefinition(new GridLength(0, GridUnitType.Auto)));
            return this;
        }

        public RowDefinitionBuilder Star(double height = 1, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new RowDefinition(new GridLength(height, GridUnitType.Star)));
            return this;
        }

        public RowDefinitionBuilder Absolute(double height, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new RowDefinition(new GridLength(height, GridUnitType.Absolute)));
            return this;
        }
    }
}
