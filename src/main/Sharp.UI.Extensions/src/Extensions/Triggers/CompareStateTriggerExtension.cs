using System.Collections;
using Microsoft.Maui.Controls;

namespace Sharp.UI
{
    public static partial class CompareStateTriggerExtension // TODO: sealed
    {
        public static Microsoft.Maui.Controls.CompareStateTrigger Binding(this Microsoft.Maui.Controls.CompareStateTrigger obj,
            Func<Binding, Binding> bindingBuilder)
        {            
            obj.SetValueOrSetter(Microsoft.Maui.Controls.CompareStateTrigger.PropertyProperty, bindingBuilder(new Binding()));
            return obj;
        }
    }
}
