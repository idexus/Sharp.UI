namespace Sharp.UI
{
    public static partial class DataTriggerExtension
    {
        public static Microsoft.Maui.Controls.DataTrigger Binding(this Microsoft.Maui.Controls.DataTrigger self,
            Func<Binding, Binding> bindingBuilder)
        {
            self.Binding = bindingBuilder(new Binding());
            return self;
        }
    }
}