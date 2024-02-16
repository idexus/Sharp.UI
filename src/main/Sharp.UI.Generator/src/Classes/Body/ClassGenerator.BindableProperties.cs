//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using Microsoft.CodeAnalysis;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Sharp.UI.Generator.Classes
{
    public partial class ClassGenerator
    {
        // ---- generate bindable properties ----

        void GenerateBindableProperties()
        {
            if (Helpers.IsBindableObject(mainSymbol))
            {
                var bindableInterfaces = mainSymbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(SharpAttributes.BindablePropertiesAttributeString, StringComparison.Ordinal)) != null);

                if (bindableInterfaces.Count() > 0)
                    builder.AppendLine($@"
        // ----- bindable properties -----");

                foreach (var inter in bindableInterfaces)
                {
                    var properties = inter
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Property);

                    foreach (var prop in properties)
                        GeneratePropertyForField((IPropertySymbol)prop);
                }
            }
        }

        void GeneratePropertyForField(IPropertySymbol propertySymbol)
        {
            var name = propertySymbol.Name;
            var typeName = propertySymbol.Type.ToDisplayString();
            var callbacks = SharpAttributes.GetPropertyCallbacks(propertySymbol);
            var defaultValueString = SharpAttributes.GetDefaultValueString(propertySymbol, typeName);
            var callbacksString = "";

            var newKeyword = Helpers.FindInBasePropertySymbolWithName(mainSymbol, name) != null ? " new" : "";

            foreach (var callback in callbacks)
            {
                callbacksString = $@",
                {callback.Key}: {callback.Value}";
            }

            builder.Append($@"
        public static{newKeyword} readonly Microsoft.Maui.Controls.BindableProperty {name}Property =
            Microsoft.Maui.Controls.BindableProperty.Create(
                nameof({name}),
                typeof({typeName}),
                typeof({mainSymbol.ToDisplayString()}),
                {(defaultValueString != null ? $"({typeName}){defaultValueString}" : $"default({typeName})")}{callbacksString});

        public{newKeyword} {typeName} {name}
        {{
            get => ({typeName})GetValue({name}Property);
            set => SetValue({name}Property, value);
        }}
        ");
        }
    }
}
