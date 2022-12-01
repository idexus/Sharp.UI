namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Trigger),
        generateAdditionalConstructors: false,
        generateNoParamConstructor: false)]
    public partial class Trigger
    {
        public Trigger(BindableProperty property, object value) : this(new Microsoft.Maui.Controls.Trigger(property.DeclaringType))
        {
            Property = property; Value = value;
        }
    }
}