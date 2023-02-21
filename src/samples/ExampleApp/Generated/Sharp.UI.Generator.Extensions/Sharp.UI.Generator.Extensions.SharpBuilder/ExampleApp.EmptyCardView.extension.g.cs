﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace ExampleApp
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class EmptyCardViewExtension
    {
        public static T CardTitle<T>(this T obj,
            string cardTitle)
            where T : ExampleApp.EmptyCardView
        {
            obj.SetValueOrSetter(ExampleApp.EmptyCardView.CardTitleProperty, cardTitle);
            return obj;
        }
        
        public static T CardTitle<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(ExampleApp.EmptyCardView.CardTitleProperty, builder.GetValue());
            return obj;
        }
        
        public static T CardTitle<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, ExampleApp.EmptyCardView.CardTitleProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T CardDescription<T>(this T obj,
            string cardDescription)
            where T : ExampleApp.EmptyCardView
        {
            obj.SetValueOrSetter(ExampleApp.EmptyCardView.CardDescriptionProperty, cardDescription);
            return obj;
        }
        
        public static T CardDescription<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(ExampleApp.EmptyCardView.CardDescriptionProperty, builder.GetValue());
            return obj;
        }
        
        public static T CardDescription<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, ExampleApp.EmptyCardView.CardDescriptionProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T CardColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color cardColor)
            where T : ExampleApp.EmptyCardView
        {
            obj.SetValueOrSetter(ExampleApp.EmptyCardView.CardColorProperty, cardColor);
            return obj;
        }
        
        public static T CardColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(ExampleApp.EmptyCardView.CardColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T CardColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buidBinding)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(obj, ExampleApp.EmptyCardView.CardColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color borderColor)
            where T : ExampleApp.EmptyCardView
        {
            obj.SetValueOrSetter(ExampleApp.EmptyCardView.BorderColorProperty, borderColor);
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(ExampleApp.EmptyCardView.BorderColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buidBinding)
            where T : ExampleApp.EmptyCardView
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(obj, ExampleApp.EmptyCardView.BorderColorProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
