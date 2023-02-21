﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class TapGestureRecognizerExtension
    {
        public static Microsoft.Maui.Controls.TapGestureRecognizer Command(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Windows.Input.ICommand? command)
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.CommandProperty, command);
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer Command(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand?>, ValueBuilder<System.Windows.Input.ICommand?>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<System.Windows.Input.ICommand?>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.CommandProperty, builder.GetValue());
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer Command(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand?>, BindingBuilder<System.Windows.Input.ICommand?>> buidBinding)
        {
            var builder = buidBinding(new BindingBuilder<System.Windows.Input.ICommand?>(obj, Microsoft.Maui.Controls.TapGestureRecognizer.CommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer CommandParameter(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            object? commandParameter)
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.CommandParameterProperty, commandParameter);
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer CommandParameter(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<ValueBuilder<object?>, ValueBuilder<object?>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<object?>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.CommandParameterProperty, builder.GetValue());
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer CommandParameter(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<BindingBuilder<object?>, BindingBuilder<object?>> buidBinding)
        {
            var builder = buidBinding(new BindingBuilder<object?>(obj, Microsoft.Maui.Controls.TapGestureRecognizer.CommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer NumberOfTapsRequired(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            int numberOfTapsRequired)
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.NumberOfTapsRequiredProperty, numberOfTapsRequired);
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer NumberOfTapsRequired(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.NumberOfTapsRequiredProperty, builder.GetValue());
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer NumberOfTapsRequired(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<BindingBuilder<int>, BindingBuilder<int>> buidBinding)
        {
            var builder = buidBinding(new BindingBuilder<int>(obj, Microsoft.Maui.Controls.TapGestureRecognizer.NumberOfTapsRequiredProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer Buttons(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            Microsoft.Maui.Controls.ButtonsMask buttons)
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.ButtonsProperty, buttons);
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer Buttons(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.ButtonsMask>, ValueBuilder<Microsoft.Maui.Controls.ButtonsMask>> buidValue)
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.ButtonsMask>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TapGestureRecognizer.ButtonsProperty, builder.GetValue());
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer Buttons(this Microsoft.Maui.Controls.TapGestureRecognizer obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.ButtonsMask>, BindingBuilder<Microsoft.Maui.Controls.ButtonsMask>> buidBinding)
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.ButtonsMask>(obj, Microsoft.Maui.Controls.TapGestureRecognizer.ButtonsProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer OnTapped(this Microsoft.Maui.Controls.TapGestureRecognizer obj, System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs>? handler)
        {
            obj.Tapped += handler;
            return obj;
        }
        
        public static Microsoft.Maui.Controls.TapGestureRecognizer OnTapped(this Microsoft.Maui.Controls.TapGestureRecognizer obj, System.Action<Microsoft.Maui.Controls.TapGestureRecognizer> action)
        {
            obj.Tapped += (o, arg) => action(obj);
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
