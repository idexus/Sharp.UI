using System.Collections;
using Microsoft.Maui.Controls;

namespace Sharp.UI
{
    public static partial class CompareStateTriggerExtension
    {
        public static Microsoft.Maui.Controls.CompareStateTrigger Binding(this Microsoft.Maui.Controls.CompareStateTrigger self,
            Func<Binding, Binding> bindingBuilder)
        {            
            self.SetValueOrAddSetter(Microsoft.Maui.Controls.CompareStateTrigger.PropertyProperty, bindingBuilder(new Binding()));
            return self;
        }
    }
}
