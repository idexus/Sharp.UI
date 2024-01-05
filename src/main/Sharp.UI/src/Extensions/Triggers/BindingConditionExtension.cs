namespace Sharp.UI
{
    public static partial class BindingConditionExtension
    {
        public static Microsoft.Maui.Controls.BindingCondition Binding(this Microsoft.Maui.Controls.BindingCondition self,
            Func<Binding, Binding> bindingBuilder)
        {
            self.Binding = bindingBuilder(new Binding());
            return self;
        }
    }
}