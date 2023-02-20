using System;
using Microsoft.CodeAnalysis;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Sharp.UI.Generator
{
    public class ClassGenerator
    {
        public const string DefaultValueAttributeString = "DefaultValueAttribute";
        public const string PropertyCallbackAttributeString = "PropertyCallbacksAttribute";

        GeneratorExecutionContext context;
        INamedTypeSymbol mainSymbol;

        StringBuilder builder;

        string fullSymbolName = null;
        string contentPropertyName = null;
        bool isSingleItemContainer = false;
        string containerOfTypeName = null;
        bool isNewPropertyContainer = false;
        bool isAlreadyContainerOfThis = false;

        public ClassGenerator(GeneratorExecutionContext context, INamedTypeSymbol symbol)
        {
            this.context = context;
            this.mainSymbol = symbol;

            this.fullSymbolName = symbol.ToDisplayString().Split('.').Last();

            SetupContainerIfNeeded();
        }

        void SetupContainerIfNeeded()
        {
            this.contentPropertyName = GetContentPropertyNameFor(mainSymbol);
            this.isNewPropertyContainer = IsNewPropertyContainer();

            if (mainSymbol.Name.Equals("HelloWorldPage"))
            {

            }

            this.isAlreadyContainerOfThis = Helpers.IsGenericIList(mainSymbol, out var containerOfType);
            if (contentPropertyName != null && isAlreadyContainerOfThis) throw new ArgumentException($"Type {mainSymbol.ToDisplayString()} defines IList interface, you can not use ContentProperty attribute");

            if (isAlreadyContainerOfThis)
            {
                this.containerOfTypeName = containerOfType.ToDisplayString();
                this.contentPropertyName = "this";
                this.isSingleItemContainer = false;
            }
            else
            {
                if (!isNewPropertyContainer && mainSymbol.ContainingNamespace.ToDisplayString().Equals("Sharp.UI"))
                {
                    this.contentPropertyName = FindContentPropertyName();
                }

                if (!string.IsNullOrEmpty(this.contentPropertyName))
                { 
                    IPropertySymbol contentPropertySymbol = FindPropertySymbolWithName(this.contentPropertyName);
                    if (contentPropertySymbol == null) throw new Exception($"No content property for: {mainSymbol.ToDisplayString()}");

                    var contentPropertyType = (INamedTypeSymbol)((contentPropertySymbol).Type);
                    if (Helpers.IsGenericIList(contentPropertyType, out var ofType))
                    {
                        this.containerOfTypeName = ofType.ToDisplayString();
                        this.isSingleItemContainer = false;
                    }
                    else
                    {
                        this.containerOfTypeName = contentPropertyType.ToDisplayString();
                        this.isSingleItemContainer = true;
                    }
                }
            }
        }

        bool IsNewPropertyContainer()
        {
            if (mainSymbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.ContentPropertyAttributeString)) == null)
                return false;

            bool isNewContainer = false;
            Helpers.LoopDownToObject(mainSymbol.BaseType, type =>
            {
                isNewContainer = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.ContentPropertyAttributeString)) != null;
                return isNewContainer;
            });
            return isNewContainer;
        }

        string GetContentPropertyNameFor(INamedTypeSymbol symbol)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.ContentPropertyAttributeString));
            return attributeData != null ? (string)attributeData.ConstructorArguments[0].Value : null;
        }

        string FindContentPropertyName()
        {
            string name = null;
            Helpers.LoopDownToObject(mainSymbol, type =>
            {
                name = GetContentPropertyNameFor(type);
                return name != null;
            });
            return name;
        }

        IPropertySymbol FindPropertySymbolWithName(string propertyName)
        {
            IPropertySymbol propertySymbol = GetPropertyFromInterface(propertyName);
            if (propertySymbol == null)
            {
                Helpers.LoopDownToObject(mainSymbol, type =>
                {
                    propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                    return propertySymbol != null;
                });
            }
            return propertySymbol;
        }

        public void Build()
        {
            builder = new StringBuilder();

            builder.AppendLine("//");
            builder.AppendLine("// <auto-generated>");
            builder.AppendLine("//");
            builder.AppendLine();

            builder.AppendLine("#nullable enable");
            builder.AppendLine();

            GenerateClassNamespace();

            builder.AppendLine();
            builder.AppendLine("#nullable restore");

            context.AddSource($"{mainSymbol.ContainingNamespace.ToDisplayString()}.{Helpers.GetNormalizedFileName(mainSymbol)}.g.cs", builder.ToString());
        }

        void GenerateClassNamespace()
        {
            this.GenerateContainerUsingsIfNeeded();
            builder.AppendLine($@"
namespace {mainSymbol.ContainingNamespace.ToDisplayString()}
{{
	{Shared.GetUsingString(mainSymbol)}public partial class {fullSymbolName}{BaseString()}
	{{");
            GenerateClassBody();
            builder.AppendLine($@"
    }}
}}");
        }

        // ------- container usings -------

        void GenerateContainerUsingsIfNeeded()
        {
            if (containerOfTypeName != null)
                builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
");
        }

        // ------- base string -------

        string BaseString()
        {
            if (containerOfTypeName != null)
            {
                if (isSingleItemContainer)
                    return $" : IEnumerable";
                else
                    return $" : IList<{containerOfTypeName}>";
            }
            return "";
        }

        void GenerateClassBody()
        {
            GenerateConstructors();
            GenerateSingleItemContainer();
            GenerateCollectionContainer();
            GenerateContainerConfigureAddMethod();
            GenerateBindableProperties();
        }

        // ---------------------------------
        // ----- single item container -----
        // ---------------------------------

        void GenerateSingleItemContainer()
        {
            if (containerOfTypeName != null && isSingleItemContainer == true)
            {
                var newPrefix = isNewPropertyContainer ? " new" : "";

                builder.AppendLine($@"
        // ----- single item container -----

        public{newPrefix} IEnumerator GetEnumerator() {{ yield return this.{contentPropertyName}; }}
        public{newPrefix} void Add({containerOfTypeName} {contentPropertyName.ToLower()}) => this.{contentPropertyName} = {contentPropertyName.ToLower()};");
            }
        }

        // --------------------------------
        // ----- collection container -----    
        // --------------------------------

        void GenerateCollectionContainer()
        {

            if (containerOfTypeName != null && isSingleItemContainer == false && !isAlreadyContainerOfThis)
            {
                var prefix = $"this.{contentPropertyName}";

                builder.AppendLine($@"
        // ----- collection container -----

        public int Count => {prefix}.Count;
        public {containerOfTypeName} this[int index] {{ get => {prefix}[index]; set => {prefix}[index] = value; }}
        public bool IsReadOnly => false;
        public void Clear() => {prefix}.Clear();
        public bool Contains({containerOfTypeName} item) => {prefix}.Contains(item);
        public void CopyTo({containerOfTypeName}[] array, int arrayIndex) => {prefix}.CopyTo(array, arrayIndex);
        public IEnumerator<{containerOfTypeName}> GetEnumerator() => {prefix}.GetEnumerator();
        public int IndexOf({containerOfTypeName} item) => {prefix}.IndexOf(item);
        public void Insert(int index, {containerOfTypeName} item) => {prefix}.Insert(index, item);
        public bool Remove({containerOfTypeName} item) => {prefix}.Remove(item);
        public void RemoveAt(int index) => {prefix}.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => {prefix}.GetEnumerator();
        public void Add({containerOfTypeName} item) => {prefix}.Add(item);");

            }
        }

        // ---------------------------------
        // ----- configure add methods -----    
        // ---------------------------------

        void GenerateContainerConfigureAddMethod()
        {
            if (containerOfTypeName != null || isAlreadyContainerOfThis)
            {
                var typeName = mainSymbol.ToDisplayString();

                builder.AppendLine($@"
        public void Add(Func<{typeName}, {typeName}> configure) {{ configure(this); }}");

                if (containerOfTypeName != null && !isSingleItemContainer || isAlreadyContainerOfThis)
                {
                    var prefix = isAlreadyContainerOfThis ? "base" : $"this.{contentPropertyName}";

                    var itemTypeNameForEnumerable = containerOfTypeName == "Microsoft.Maui.IView" ? "Microsoft.Maui.Controls.View" : containerOfTypeName;
                    var shortName = Helpers.CamelCase(itemTypeNameForEnumerable.Split('.').Last());

                    builder.AppendLine($@"
        public void Add(Action<IList<{containerOfTypeName}>> builder)
        {{
            List<{containerOfTypeName}> items = new List<{containerOfTypeName}>();
            builder(items);
            foreach (var item in items)
                {prefix}.Add(item);
        }}");

                    if (containerOfTypeName == "Microsoft.Maui.IView")
                        builder.AppendLine($@"
        public void Add(Func<{containerOfTypeName}> builder)
        {{
            var item = builder();
            if (item != null)
                {prefix}.Add(item);
        }}

        public void Add(IEnumerable<{itemTypeNameForEnumerable}> items)
        {{
            foreach (var item in items)
                {prefix}.Add(item);
        }}");
                }
            }
        }

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
        public {mainSymbol.Name}({argsString}System.Action<{mainSymbol.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {mainSymbol.Name}({argsString}out {mainSymbol.Name} {camelCaseName}, System.Action<{mainSymbol.Name}> configure) {thisTail}
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

        // --------------------------------------
        // ---- generate bindable properties ----
        // --------------------------------------

        Dictionary<string, string> GetPropertyCallbacks(ISymbol symbol)
        {
            var data = new Dictionary<string, string>();
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(PropertyCallbackAttributeString, StringComparison.Ordinal));
            if (attributeData != null)
            {
                var arguments = attributeData.ConstructorArguments;
                if (arguments[0].Value != null)
                    data["propertyChanged"] = (string)arguments[0].Value;
                if (arguments[1].Value != null)
                    data["propertyChanging"] = (string)arguments[1].Value;
                if (arguments[2].Value != null)
                    data["validateValue"] = (string)arguments[2].Value;
                if (arguments[3].Value != null)
                    data["coerceValue"] = (string)arguments[3].Value;
                if (arguments[4].Value != null)
                    data["defaultValueCreator"] = (string)arguments[4].Value;
                if (data.Count() == 0)
                    throw new ArgumentException($"PropertyCallback attribute must have minmium one attribute defined, symbol: {symbol.ToDisplayString()}");
            }
            return data;
        }

        string GetDefaultValueString(ISymbol symbol, string typeName)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(DefaultValueAttributeString, StringComparison.Ordinal));
            if (attributeData != null)
            {

                var value = attributeData.ConstructorArguments[0].Value.ToString();
                if (typeName.Equals("string", StringComparison.Ordinal))
                    value = $"\"{value}\"";
                if (typeName.Equals("double", StringComparison.Ordinal) || typeName.Equals("float", StringComparison.Ordinal))
                    value = value.Replace(",", ".");
                return value;
            }
            return null;
        }

        IPropertySymbol GetPropertyFromInterface(string name)
        {
            if (Helpers.IsBindable(mainSymbol))
            {
                var bindableInterfaces = mainSymbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.BindablePropertiesAttributeString, StringComparison.Ordinal)) != null);

                if (bindableInterfaces.Count() > 0)

                    foreach (var inter in bindableInterfaces)
                    {
                        var properties = inter
                            .GetMembers()
                            .Where(e => e.Kind == SymbolKind.Property);

                        foreach (var prop in properties)
                            if (prop.Name.Equals(name, StringComparison.Ordinal))
                                return (IPropertySymbol)prop;
                    }
            }
            return null;
        }

        void GenerateBindableProperties()
        {
            if (Helpers.IsBindable(mainSymbol))
            {
                var bindableInterfaces = mainSymbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.BindablePropertiesAttributeString, StringComparison.Ordinal)) != null);

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
            var callbacks = GetPropertyCallbacks(propertySymbol);
            var defaultValueString = GetDefaultValueString(propertySymbol, typeName);
            var callbacksString = "";

            foreach (var callback in callbacks)
            {
                callbacksString = $@",
                {callback.Key}: {callback.Value}";
            }

            builder.Append($@"
        public static readonly Microsoft.Maui.Controls.BindableProperty {name}Property =
            Microsoft.Maui.Controls.BindableProperty.Create(
                nameof({name}),
                typeof({typeName}),
                typeof({mainSymbol.ToDisplayString()}),
                {(defaultValueString != null ? $"({typeName}){defaultValueString}" : $"default({typeName})")}{callbacksString});

        public {typeName} {name}
        {{
            get => ({typeName})GetValue({name}Property);
            set => SetValue({name}Property, value);
        }}
        ");
        }
    }
}