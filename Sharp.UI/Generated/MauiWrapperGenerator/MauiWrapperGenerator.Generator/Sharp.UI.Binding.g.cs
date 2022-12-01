﻿//
// <auto-generated>
//

#pragma warning disable CS0108
#pragma warning disable CS8625
#pragma warning disable CS8669


namespace Sharp.UI
{
    public partial class Binding : Sharp.UI.IBinding, ISealedMauiWrapper
    {
        // ----- maui object -----

        public object _maui_RawObject { get; set; }

        public Microsoft.Maui.Controls.Binding MauiObject { get => (Microsoft.Maui.Controls.Binding)_maui_RawObject; set => _maui_RawObject = value; }

        // ----- constructors -----
        

        public Binding(Microsoft.Maui.Controls.Binding binding)
        {
            MauiObject = binding;
        }

        public Binding()
        {
            MauiObject = new Microsoft.Maui.Controls.Binding();
        }

        // ----- operators -----

        public static implicit operator Binding(Microsoft.Maui.Controls.Binding mauiObject) => new Binding(mauiObject);
        public static implicit operator Microsoft.Maui.Controls.Binding(Binding obj) => obj.MauiObject;

        // ----- bindable properties -----


        // ----- properties / events -----

        public Microsoft.Maui.Controls.IValueConverter Converter { get => MauiObject.Converter; set => MauiObject.Converter = value; }
        public object ConverterParameter { get => MauiObject.ConverterParameter; set => MauiObject.ConverterParameter = value; }
        public string Path { get => MauiObject.Path; set => MauiObject.Path = value; }
        public object Source { get => MauiObject.Source; set => MauiObject.Source = value; }
        public string UpdateSourceEventName { get => MauiObject.UpdateSourceEventName; set => MauiObject.UpdateSourceEventName = value; }
        public Microsoft.Maui.Controls.BindingMode Mode { get => MauiObject.Mode; set => MauiObject.Mode = value; }
        public string StringFormat { get => MauiObject.StringFormat; set => MauiObject.StringFormat = value; }
        public object TargetNullValue { get => MauiObject.TargetNullValue; set => MauiObject.TargetNullValue = value; }
        public object FallbackValue { get => MauiObject.FallbackValue; set => MauiObject.FallbackValue = value; }
    }
    
}

#pragma warning restore CS0108
#pragma warning restore CS8625
#pragma warning restore CS8669