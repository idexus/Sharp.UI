namespace Sharp.UI
{
    public static partial class DataTriggerExtension // TODO: sealed
    {
        public static Microsoft.Maui.Controls.DataTrigger Binding(this Microsoft.Maui.Controls.DataTrigger obj,
            Func<Binding, Binding> bindingBuilder)
        {
            obj.Binding = bindingBuilder(new Binding());
            return obj;
        }
    }
}