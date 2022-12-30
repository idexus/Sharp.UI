namespace Sharp.UI
{
    public class BindingBuilder<T>
    {
        //--- bindable ---

        public BindingBuilder<T> Path(string path) { this.path = path; return this; }
        public BindingBuilder<T> StringFormat(string stringFormat) { this.stringFormat = stringFormat; return this; }
        public BindingBuilder<T> BindingMode(BindingMode bindingMode) { this.bindingMode = bindingMode; return this; }
        public BindingBuilder<T> Converter(IValueConverter converter) { this.converter = converter; return this; }
        public BindingBuilder<T> Parameter(string converterParameter) { this.converterParameter = converterParameter; return this; }
        public BindingBuilder<T> Source(object source) { this.source = source; return this; }

        private string path = null;
        private BindingMode bindingMode = Microsoft.Maui.Controls.BindingMode.Default;
        private IValueConverter converter = null;
        private string converterParameter = null;
        private string stringFormat = null;
        private object source = null;

        private BindableObject obj;
        private BindableProperty property;

        public BindingBuilder(BindableObject obj, BindableProperty property)
        {
            this.obj = obj;
            this.property = property;
        }

        public void BindProperty()
        {
            if (path != null)
            {
                obj.SetBinding(
                    targetProperty: property,
                    binding: new Microsoft.Maui.Controls.Binding(
                        path: path,
                        mode: bindingMode,
                        converter: converter,
                        converterParameter: converterParameter,
                        stringFormat: stringFormat,
                        source: source));
            }
        }
    }
}
