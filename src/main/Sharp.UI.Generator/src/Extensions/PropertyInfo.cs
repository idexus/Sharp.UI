//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Extensions
{
    partial class PropertyInfo
    {
        public INamedTypeSymbol MainSymbol { get; set; }
        public IPropertySymbol PropertySymbol { get; set; }
        public List<string> BindableProperties { get; set; }
        public bool IsBindableObject { get; set; }
        public bool IsBindableProperty { get; set; }
        public string BindablePropertyName { get; set; }

        public string propertyName;
        public string accessedWith;
        public string propertyTypeName;
        public string camelCaseName;
        public string symbolTypeName;
        public string valueAssignmentString;
        public string dataTemplateAssignmentString;

        public void Build()
        {
            symbolTypeName = $"{MainSymbol.ToDisplayString()}";

            propertyName = PropertySymbol.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class", StringComparison.Ordinal) ? "@class" : propertyName;

            if (BindablePropertyName == null)
            {
                if (BindableProperties != null) IsBindableProperty = BindableProperties.Contains(propertyName);
                accessedWith = PropertySymbol.IsStatic ? $"{MainSymbol.ToDisplayString()}" : "self";
                BindablePropertyName = $"{MainSymbol.ToDisplayString()}.{propertyName}Property";
            }
            else
                IsBindableObject = true;

            propertyTypeName = PropertySymbol.Type.ToDisplayString();
            camelCaseName = Helpers.CamelCase(propertyName);

            valueAssignmentString = IsBindableProperty ?
                $@"self.SetValue({BindablePropertyName}, {camelCaseName});" :
                $"{accessedWith}.{propertyName} = {camelCaseName};";

            dataTemplateAssignmentString = IsBindableProperty ?
                $@"self.SetValue({BindablePropertyName}, new DataTemplate(loadTemplate));" :
                $@"{accessedWith}.{propertyName} = new DataTemplate(loadTemplate);";

        }
    }
}

