﻿//
// <auto-generated>
//

#nullable enable


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

        // ----- bindable properties -----

        public static readonly Microsoft.Maui.Controls.BindableProperty TitleProperty =
            Microsoft.Maui.Controls.BindableProperty.Create(
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
            Microsoft.Maui.Controls.BindableProperty.Create(
                nameof(Author),
                typeof(string),
                typeof(ExampleApp.SecondPageViewModel),
                default(string));

        public string Author
        {
            get => (string)GetValue(AuthorProperty);
            set => SetValue(AuthorProperty, value);
        }
        
    }
}

#nullable restore