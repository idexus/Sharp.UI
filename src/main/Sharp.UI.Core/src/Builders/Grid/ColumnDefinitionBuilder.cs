using System.Collections;

namespace Sharp.UI
{
    public class ColumnDefinitionBuilder
    {
        public List<ColumnDefinition> Items { get; } = new List<ColumnDefinition>();

        public ColumnDefinitionBuilder Auto(int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new ColumnDefinition(new GridLength (0, GridUnitType.Auto)));
            return this;
        }

        public ColumnDefinitionBuilder Star(double width = 1, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new ColumnDefinition(new GridLength(width, GridUnitType.Star)));
            return this;
        }

        public ColumnDefinitionBuilder Absolute(double width, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new ColumnDefinition(new GridLength(width, GridUnitType.Absolute)));
            return this;
        }
    }
}
