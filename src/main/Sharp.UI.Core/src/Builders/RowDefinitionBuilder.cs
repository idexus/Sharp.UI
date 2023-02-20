using System.Collections;

namespace Sharp.UI
{
    public class RowDefinitionBuilder : IEnumerable<RowDefinition>
    {
        List<RowDefinition> items = new List<RowDefinition>();

        public IEnumerator<RowDefinition> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public RowDefinitionBuilder Auto(int count = 1)
        {
            for (int i = 0; i < count; i++)
                items.Add(new RowDefinition(new GridLength(0, GridUnitType.Auto)));
            return this;
        }

        public RowDefinitionBuilder Star(double height = 1, int count = 1)
        {
            for (int i = 0; i < count; i++)
                items.Add(new RowDefinition(new GridLength(height, GridUnitType.Star)));
            return this;
        }

        public RowDefinitionBuilder Absolute(double height, int count = 1)
        {
            for (int i = 0; i < count; i++)
                items.Add(new RowDefinition(new GridLength(height, GridUnitType.Absolute)));
            return this;
        }
    }
}
