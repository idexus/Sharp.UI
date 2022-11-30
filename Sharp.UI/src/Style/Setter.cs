namespace Sharp.UI
{
    [MauiWrapper(typeof(Microsoft.Maui.Controls.Setter),
          generateAdditionalConstructors:false)]
    public partial class Setter
    {        
        public Setter(BindableProperty property, object value) : this()
        {
            if (value != null)
            {
                this.Property = property;
                this.Value = value;
            }
        }

        public Setter(BindableProperty property) : this()
        {
            this.Property = property;
        }
    }
}