namespace Sharp.UI
{
    public static partial class BindingConditionExtension // TODO: sealed
    {
        public static Microsoft.Maui.Controls.BindingCondition Binding(this Microsoft.Maui.Controls.BindingCondition obj,
            Func<Binding, Binding> bindingBuilder)
        {
            obj.Binding = bindingBuilder(new Binding());
            return obj;
        }
    }
}