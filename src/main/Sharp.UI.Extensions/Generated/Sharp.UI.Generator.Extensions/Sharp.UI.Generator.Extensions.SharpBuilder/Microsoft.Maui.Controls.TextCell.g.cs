﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class TextCellExtension
    {
        public static T Command<T>(this T obj,
            System.Windows.Input.ICommand command)
            where T : Microsoft.Maui.Controls.TextCell
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.CommandProperty, command);
            return obj;
        }
        
        public static T Command<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buidValue)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.CommandProperty, builder.GetValue());
            return obj;
        }
        
        public static T Command<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buidBinding)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidBinding(new BindingBuilder<System.Windows.Input.ICommand>(obj, Microsoft.Maui.Controls.TextCell.CommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T CommandParameter<T>(this T obj,
            object commandParameter)
            where T : Microsoft.Maui.Controls.TextCell
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.CommandParameterProperty, commandParameter);
            return obj;
        }
        
        public static T CommandParameter<T>(this T obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buidValue)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.CommandParameterProperty, builder.GetValue());
            return obj;
        }
        
        public static T CommandParameter<T>(this T obj,
            System.Func<BindingBuilder<object>, BindingBuilder<object>> buidBinding)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidBinding(new BindingBuilder<object>(obj, Microsoft.Maui.Controls.TextCell.CommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Detail<T>(this T obj,
            string detail)
            where T : Microsoft.Maui.Controls.TextCell
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.DetailProperty, detail);
            return obj;
        }
        
        public static T Detail<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.DetailProperty, builder.GetValue());
            return obj;
        }
        
        public static T Detail<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, Microsoft.Maui.Controls.TextCell.DetailProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T DetailColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color detailColor)
            where T : Microsoft.Maui.Controls.TextCell
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.DetailColorProperty, detailColor);
            return obj;
        }
        
        public static T DetailColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.DetailColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T DetailColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buidBinding)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(obj, Microsoft.Maui.Controls.TextCell.DetailColorProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Text<T>(this T obj,
            string text)
            where T : Microsoft.Maui.Controls.TextCell
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.TextProperty, text);
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buidValue)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.TextProperty, builder.GetValue());
            return obj;
        }
        
        public static T Text<T>(this T obj,
            System.Func<BindingBuilder<string>, BindingBuilder<string>> buidBinding)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidBinding(new BindingBuilder<string>(obj, Microsoft.Maui.Controls.TextCell.TextProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color textColor)
            where T : Microsoft.Maui.Controls.TextCell
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.TextColorProperty, textColor);
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Graphics.Color>, ValueBuilder<Microsoft.Maui.Graphics.Color>> buidValue)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Graphics.Color>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.TextCell.TextColorProperty, builder.GetValue());
            return obj;
        }
        
        public static T TextColor<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Graphics.Color>, BindingBuilder<Microsoft.Maui.Graphics.Color>> buidBinding)
            where T : Microsoft.Maui.Controls.TextCell
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Graphics.Color>(obj, Microsoft.Maui.Controls.TextCell.TextColorProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore
