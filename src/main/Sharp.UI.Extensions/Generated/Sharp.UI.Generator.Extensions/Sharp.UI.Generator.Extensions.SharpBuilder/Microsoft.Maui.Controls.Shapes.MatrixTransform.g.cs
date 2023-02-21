﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class MatrixTransformExtension
    {
        public static T Matrix<T>(this T obj,
            Microsoft.Maui.Controls.Shapes.Matrix matrix)
            where T : Microsoft.Maui.Controls.Shapes.MatrixTransform
        {
            obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.MatrixTransform.MatrixProperty, matrix);
            return obj;
        }
        
        public static T Matrix<T>(this T obj,
            System.Func<ValueBuilder<Microsoft.Maui.Controls.Shapes.Matrix>, ValueBuilder<Microsoft.Maui.Controls.Shapes.Matrix>> buidValue)
            where T : Microsoft.Maui.Controls.Shapes.MatrixTransform
        {
            var builder = buidValue(new ValueBuilder<Microsoft.Maui.Controls.Shapes.Matrix>());
            if (builder.ValueIsSet()) obj.SetValueOrSetter(Microsoft.Maui.Controls.Shapes.MatrixTransform.MatrixProperty, builder.GetValue());
            return obj;
        }
        
        public static T Matrix<T>(this T obj,
            System.Func<BindingBuilder<Microsoft.Maui.Controls.Shapes.Matrix>, BindingBuilder<Microsoft.Maui.Controls.Shapes.Matrix>> buidBinding)
            where T : Microsoft.Maui.Controls.Shapes.MatrixTransform
        {
            var builder = buidBinding(new BindingBuilder<Microsoft.Maui.Controls.Shapes.Matrix>(obj, Microsoft.Maui.Controls.Shapes.MatrixTransform.MatrixProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore