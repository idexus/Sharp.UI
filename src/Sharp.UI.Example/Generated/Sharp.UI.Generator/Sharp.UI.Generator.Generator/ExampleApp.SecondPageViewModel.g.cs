﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace ExampleApp
{  
    using Sharp.UI;

    public partial class SecondPageViewModel
    {
        // ----- constructors -----

        public SecondPageViewModel() { }

        public SecondPageViewModel(out SecondPageViewModel secondPageViewModel) 
        {
            secondPageViewModel = this;
        }

        public SecondPageViewModel(System.Action<SecondPageViewModel> configure) 
        {
            configure(this);
        }

        public SecondPageViewModel(out SecondPageViewModel secondPageViewModel, System.Action<SecondPageViewModel> configure) 
        {
            secondPageViewModel = this;
            configure(this);
        }

        // ----- bindable properties -----

        public static readonly Microsoft.Maui.Controls.BindableProperty TitleProperty =
            BindableProperty.Create(
                nameof(Title),
                typeof(string),
                typeof(ExampleApp.SecondPageViewModel),
                (string)"no title");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly Microsoft.Maui.Controls.BindableProperty AuthorProperty =
            BindableProperty.Create(
                nameof(Author),
                typeof(string),
                typeof(ExampleApp.SecondPageViewModel),
                default(string));

        public string Author
        {
            get => (string)GetValue(AuthorProperty);
            set => SetValue(AuthorProperty, value);
        }

        // ----- set value method -----

        public new void SetValue(Microsoft.Maui.Controls.BindableProperty property, object value)
        {
            var mauiValue = MauiWrapper.Value<object>(value);
            ((Microsoft.Maui.Controls.BindableObject)this).SetValue(property, mauiValue);
        }

        public new void SetValue(Microsoft.Maui.Controls.BindablePropertyKey propertyKey, object value)
        {
            var mauiValue = MauiWrapper.Value<object>(value);
            ((Microsoft.Maui.Controls.BindableObject)this).SetValue(propertyKey, mauiValue);
        }
    }
}

#pragma warning restore CS8669