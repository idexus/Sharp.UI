﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI.Internal;
    
    public static partial class DataTriggerExtension
    {
        public static Microsoft.Maui.Controls.DataTrigger Binding(this Microsoft.Maui.Controls.DataTrigger self,
            Microsoft.Maui.Controls.BindingBase binding)
        {
            if (FluentStyling.Setters != null) throw new ArgumentException("Fluent styling not available for property Binding");
            self.Binding = binding;
            return self;
        }
        
        public static Microsoft.Maui.Controls.DataTrigger Setters(this Microsoft.Maui.Controls.DataTrigger self,
            IList<Microsoft.Maui.Controls.Setter> setters)
        {
            foreach (var item in setters)
                self.Setters.Add(item);
            return self;
        }

        public static Microsoft.Maui.Controls.DataTrigger Setters(this Microsoft.Maui.Controls.DataTrigger self,
            params Microsoft.Maui.Controls.Setter[] setters)
        {
            foreach (var item in setters)
                self.Setters.Add(item);
            return self;
        }
        
        public static Microsoft.Maui.Controls.DataTrigger Value(this Microsoft.Maui.Controls.DataTrigger self,
            object value)
        {
            if (FluentStyling.Setters != null) throw new ArgumentException("Fluent styling not available for property Value");
            self.Value = value;
            return self;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
