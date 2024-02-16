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
        // ------------------------
        // ----- constructors -----
        // ------------------------

        // no params constructor

        void GenerateNoParamConstructor()
        {
            builder.AppendLine($@"
        public {mainSymbol.Name}() {{ }}");
        }

        // additional constructors

        void GenerateConstructors()
        {
            var argsString = "";
            var baseArgsString = "";
            var thisTail = ": this()";
            var objectTail = "";
            var camelCaseName = Helpers.CamelCase(mainSymbol.Name);

            var buildAdditionalConstructor = () =>
            {
                builder.AppendLine($@"
        public {mainSymbol.Name}({argsString}out {fullSymbolName} {camelCaseName}{objectTail}) {thisTail}
        {{
            {camelCaseName}{objectTail} = this;
        }}");

                if (containerOfTypeName != null || isAlreadyContainerOfThis)
                    builder.AppendLine($@"
        public {mainSymbol.Name}({argsString}System.Func<{mainSymbol.Name}, {mainSymbol.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {mainSymbol.Name}({argsString}out {mainSymbol.Name} {camelCaseName}, System.Func<{mainSymbol.Name}, {mainSymbol.Name}> configure) {thisTail}
        {{
            {Helpers.CamelCase(mainSymbol.Name)} = this;
            configure(this);
        }}");
            };

            builder.AppendLine($@"
        // ----- constructors -----");

            var isNoParamInParent = mainSymbol.BaseType.Constructors.FirstOrDefault(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() == 0) != null;

            var isExplicitlyDeclared = mainSymbol.Constructors.FirstOrDefault(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null;
            var isImplicitlyDeclared = mainSymbol.Constructors.FirstOrDefault(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() == 0 && e.IsImplicitlyDeclared) != null;

            // this() constructor
            if (isImplicitlyDeclared || (isNoParamInParent && !isExplicitlyDeclared))
            {
                GenerateNoParamConstructor();
                thisTail = "";
            }
            if (isImplicitlyDeclared || isExplicitlyDeclared || (isNoParamInParent && !isExplicitlyDeclared))
                buildAdditionalConstructor();

            // this(...) constructors
            var constructors = mainSymbol.Constructors.Where(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() > 0 && !e.IsImplicitlyDeclared);
            foreach (var constructor in constructors)
            {
                argsString = "";
                baseArgsString = "";

                var argsList = new List<string>();
                foreach (var argument in constructor.Parameters)
                {
                    var camelCaseArgName = Helpers.CamelCase(argument.Name);
                    argsList.Add(camelCaseArgName);

                    argsString += $"{argument.Type.ToDisplayString()} {camelCaseArgName}, ";

                    if (!string.IsNullOrEmpty(baseArgsString))
                        baseArgsString += ", ";
                    baseArgsString += $"{camelCaseArgName}";
                }

                thisTail = $": this({baseArgsString})";
                objectTail = argsList.Contains(camelCaseName, StringComparer.Ordinal) ? "Object" : "";
                buildAdditionalConstructor();
            }
        }
    }
}