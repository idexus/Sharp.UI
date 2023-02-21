using System.Collections;

namespace Sharp.UI
{
    public class ColumnDefinitionBuilder : IEnumerable<ColumnDefinition>
    {
        List<ColumnDefinition> items = new List<ColumnDefinition>();

        public IEnumerator<ColumnDefinition> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public ColumnDefinitionBuilder Auto(int count = 1)
        {
            for (int i = 0; i < count; i++)
                items.Add(new ColumnDefinition(new GridLength (0, GridUnitType.Auto)));
            return this;
        }

        public ColumnDefinitionBuilder Star(double width = 1, int count = 1)
        {
            for (int i = 0; i < count; i++)
                items.Add(new ColumnDefinition(new GridLength(width, GridUnitType.Star)));
            return this;
        }

        public ColumnDefinitionBuilder Absolute(double width, int count = 1)
        {
            for (int i = 0; i < count; i++)
                items.Add(new ColumnDefinition(new GridLength(width, GridUnitType.Absolute)));
            return this;
        }
    }
}
