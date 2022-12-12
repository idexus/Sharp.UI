using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

namespace MauiWrapperGenerator;

public class MauiClassBuilder
{
    private readonly StringBuilder builder;
    private readonly INamedTypeSymbol mainType;

    //------ attribute parameters ------
    private readonly INamedTypeSymbol baseType;
    private readonly List<string> notGenerateList;
    private readonly List<string> constructorWithProperties;
    private readonly string containerPropertyName = null;

    //--- find out
    private readonly bool generateAdditionalConstructors = false;
    private readonly bool generateNoParamConstructor = false;
    private readonly bool singleItemContainer = false;
    private readonly string containerOfTypeName = null;

    private List<string> bindablePropertiesNames = new List<string>();

    private bool noBaseType = false;

    public MauiClassBuilder(INamedTypeSymbol symbol, AttributeData wrapperAttribute, StringBuilder builder)
    {
        this.builder = builder;
        this.mainType = symbol;

        this.notGenerateList = new List<string>();
        notGenerateList.Add("this[]");
        notGenerateList.Add("Handler");
        notGenerateList.Add("LogicalChildren");
        notGenerateList.Add("BindingContext");

        // ------- constructor arguments ------

        // [0] baseType
        this.baseType = wrapperAttribute.ConstructorArguments[0].Value as INamedTypeSymbol;

        // [1] constructorWithProperty
        var constructorWithPropertiesValues = wrapperAttribute.ConstructorArguments[1].Values;
        if (!constructorWithPropertiesValues.IsDefaultOrEmpty)
            this.constructorWithProperties = constructorWithPropertiesValues.Select(e => (string)e.Value).ToList();
        else
            this.constructorWithProperties = new List<string>();

        this.generateNoParamConstructor = true;
        if (mainType.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null)
            this.generateNoParamConstructor = false;

        if (baseType == null)
        {
            baseType = symbol;
            noBaseType = true;
        }
        else
        {
            if (baseType.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0) == null)
                this.generateNoParamConstructor = false;

            // [2] containerPropertyName
            this.containerPropertyName = (string)(wrapperAttribute.ConstructorArguments[2].Value);

            // ------- content attribute -------

            var isContainerThis = WrapBuilder.IsGenericIList(baseType, out var containerType);
            if (isContainerThis && baseType.IsSealed)
            {
                this.containerOfTypeName = containerType;
                this.containerPropertyName = "this";
                this.singleItemContainer = false;
            }
            else if (!isContainerThis)
            {
                // if is null try to find
                if (string.IsNullOrEmpty(this.containerPropertyName))
                {
                    AttributeData mauiContentAtribute = FindContentPropertyAttribute();
                    if (mauiContentAtribute != null && string.IsNullOrEmpty(this.containerPropertyName))
                        this.containerPropertyName = mauiContentAtribute.ConstructorArguments[0].Value.ToString();
                }

                if (!string.IsNullOrEmpty(this.containerPropertyName))
                {
                    IPropertySymbol propertySymbol = FindPropertySymbolWithName(this.containerPropertyName);

                    if (propertySymbol == null) throw new Exception($"No content property for: {baseType.Name}");

                    var mauiContainerType = (INamedTypeSymbol)((propertySymbol).Type);
                    if (WrapBuilder.IsGenericIList(mauiContainerType, out var ofTypeName))
                    {
                        this.containerOfTypeName = ofTypeName;
                        this.singleItemContainer = false;
                    }
                    else
                    {
                        this.containerOfTypeName = mauiContainerType.ToDisplayString();
                        this.singleItemContainer = true;
                    }
                }
            }
        }

        this.generateAdditionalConstructors =
                mainType.Constructors.FirstOrDefault(e => e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null ||
                this.generateNoParamConstructor;
    }

    AttributeData FindContentPropertyAttribute()
    {
        AttributeData attributeData = null;
        var type = baseType;
        do
        {
            attributeData = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains("ContentProperty"));
            type = type.BaseType;
        }
        while (attributeData == null && !type.Name.Equals("Object"));
        return attributeData;
    }

    IPropertySymbol FindPropertySymbolWithName(string propertyName)
    {
        IPropertySymbol propertySymbol = null;
        var type = baseType;
        do
        {
            propertySymbol = (IPropertySymbol)(type.GetMembers(this.containerPropertyName).FirstOrDefault());
            type = type.BaseType;
        }
        while (propertySymbol == null && !type.Name.Equals("Object"));
        return propertySymbol;
    }

    //----------------------------------------
    #region namespace buider
    //----------------------------------------

    public void Build()
    {
        if (containerOfTypeName != null)
            builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
");
        if (noBaseType)
            builder.Append($@"
namespace {baseType.ContainingNamespace}
{{
    public partial class {baseType.Name}
    {{");
        else
        builder.Append($@"
namespace Sharp.UI
{{
    public partial class {mainType.Name} {BaseString()}
    {{");
        GenerateClass();
        builder.Append($@"
    }}
}}");
    }

    // ----- Strings -----

    bool IsBindable()
    {
        var isBindable = false;
        var type = baseType;

        do
        {
            if (type.Name.Equals("BindableObject")) isBindable = true;
            type = type.BaseType;
        }
        while (!type.Name.Equals("Object") && !isBindable);

        return isBindable;
    }

    string BaseString()
    {
        string baseString;
        if (baseType.IsSealed)
            baseString = $": Sharp.UI.{WrapBuilder.GetInterfaceName(baseType)}";
        else
            baseString = $": {baseType.ToDisplayString()}, Sharp.UI.{WrapBuilder.GetInterfaceName(baseType)}";

        if (baseType.IsSealed) baseString += $", ISealedMauiWrapper";
        if (containerOfTypeName != null && singleItemContainer) baseString += $", IEnumerable";
        if (containerOfTypeName != null && !singleItemContainer) baseString += $", IList<{containerOfTypeName}>";
        if (IsBindable()) baseString += ", IWrappedBindableObject";
        return baseString;
    }

    #endregion

    //----------------------------------------
    #region parent bindable class generator
    //----------------------------------------

    void GenerateSealedParentBindable()
    {
        if (baseType.IsSealed)
        {
            builder.AppendLine($@"
        // ----- bindable properties -----");

            var type = baseType;
            do
            {
                var properties = type
                    .GetMembers()
                    .Where(e => e.IsStatic && e.Name.EndsWith("Property") && e.DeclaredAccessibility == Accessibility.Public);

                foreach (var prop in properties) GenerateBindableProperty(prop);

                type = type.BaseType;
            }
            while (!type.Name.Equals("Object"));

            builder.AppendLine();
        }
    }

    // ----- bindable property -----

    void GenerateBindableProperty(ISymbol property)
    {
        var name = property.Name.Substring(0, property.Name.Length - "Property".Length);
        if (!notGenerateList.Contains(property.Name) && !bindablePropertiesNames.Contains(property.Name))
        {
            bindablePropertiesNames.Add(property.Name);
            builder.Append($@"
        public static Microsoft.Maui.Controls.BindableProperty {property.Name} => {property.ToDisplayString()};");
        }
    }

    #endregion

    //----------------------------------------
    #region class generator
    //----------------------------------------

    void GenerateClass()
    {
        GenerateMauiObjectProperty();
        GenerateConstructor();
        GenerateConstructorWithProperty();
        GenerateOperators();
        GenerateBindable();
        GenerateSingleItemContainer();
        GenerateCollectionDeclaration();
        GenerateSealedParentBindable();
        GeneratePropertiesAndEvents();
        GenerateBindingContext();
    }

    // ----- single item container -----

    void GenerateSingleItemContainer()
    {
        if (containerOfTypeName != null && singleItemContainer == true) builder.AppendLine($@"
        // ----- single item container -----

        public IEnumerator GetEnumerator() {{ yield return this.{containerPropertyName}; }}

        public void Add({containerOfTypeName} {containerPropertyName.ToLower()}) => this.{containerPropertyName} = {containerPropertyName.ToLower()};");
    }

    // ----- collection -----    

    void GenerateCollectionDeclaration()
    {
        var prefix = $"this.{containerPropertyName}";
        if (baseType.IsSealed) prefix = containerPropertyName.Equals("this") ? "this.MauiObject" : $"this.MauiObject.{containerPropertyName}";

        if (containerOfTypeName != null && singleItemContainer == false)
        {
            notGenerateList.Add("Count");

            builder.AppendLine($@"
        // ----- collection container -----

        public int Count => {prefix}.Count;
        public {containerOfTypeName} this[int index] {{ get => {prefix}[index]; set => {prefix}[index] = value; }}
        public bool IsReadOnly => false;
        public void Add({containerOfTypeName} item) => {prefix}.Add(item);
        public void Clear() => {prefix}.Clear();
        public bool Contains({containerOfTypeName} item) => {prefix}.Contains(item);
        public void CopyTo({containerOfTypeName}[] array, int arrayIndex) => {prefix}.CopyTo(array, arrayIndex);
        public IEnumerator<{containerOfTypeName}> GetEnumerator() => {prefix}.GetEnumerator();
        public int IndexOf({containerOfTypeName} item) => {prefix}.IndexOf(item);
        public void Insert(int index, {containerOfTypeName} item) => {prefix}.Insert(index, item);
        public bool Remove({containerOfTypeName} item) => {prefix}.Remove(item);
        public void RemoveAt(int index) => {prefix}.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => {prefix}.GetEnumerator();");
        }
    }

    void GenerateBindingContext()
    {
        if (IsBindable())
        {
            var newKeyword = baseType.IsSealed ? " " : " new ";
            var accessedWith = baseType.IsSealed ? "MauiObject" : "base";
            builder.AppendLine($@"
        // ----- binding context -----

        public{newKeyword}object BindingContext
        {{
            get => {accessedWith}.BindingContext;
            set
            {{
                var mauiObject = MauiWrapper.GetObject<object>(value);
                {accessedWith}.BindingContext = mauiObject;
            }}
        }}
        ");
        }
    }

    // ----- maui object -----

    void GenerateMauiObjectProperty()
    {
        if (baseType.IsSealed) builder.AppendLine($@"
        // ----- maui object -----

        public object _maui_RawObject {{ get; set; }}

        public {baseType.ToDisplayString()} MauiObject {{ get => ({baseType.ToDisplayString()})_maui_RawObject; set => _maui_RawObject = value; }}");
    }

    // ------ generate bindable properties

    void GenerateBindable()
    {
        var bindableInterfaces = mainType
            .Interfaces
            .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains("Bindable")) != null);

        if (bindableInterfaces.Count() > 0) builder.AppendLine($@"
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

    void GeneratePropertyForField(IPropertySymbol symbol)
    {
        var name = symbol.Name;
        var typeName = symbol.Type.Name;

        builder.Append($@"
        public static readonly BindableProperty {name}Property = BindableProperty.Create(nameof({name}), typeof({typeName}), typeof({mainType.ToDisplayString()}), default({typeName}));

        public {typeName} {name}
        {{
            get => ({typeName})GetValue({name}Property);
            set => SetValue({name}Property, value);
        }}
        ");
    }

    // ------ generate properties and events in class

    void GeneratePropertiesAndEvents()
    {
        if (baseType.IsSealed)
        {
            builder.AppendLine($@"
        // ----- properties / events -----");
            List<string> doneList = new List<string>();

            var type = baseType;
            do
            {
                var properties = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public);

                var events = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Event && e.DeclaredAccessibility == Accessibility.Public);

                foreach (var prop in properties)
                {
                    if (!doneList.Contains(prop.Name))
                    {
                        GenerateProperty(prop);
                        doneList.Add(prop.Name);
                    }
                }
                foreach (var @event in events)
                {
                    if (!doneList.Contains(@event.Name))
                    {
                        GenerateEvent(@event);
                        doneList.Add(@event.Name);
                    }
                }

                type = type.BaseType;
            }
            while (!type.Name.Equals("Object"));
        }
    }

    void GenerateProperty(ISymbol property)
    {
        var propertySymbol = (IPropertySymbol)property;
        var propertyTypeName = propertySymbol.Type.ToDisplayString();

        var propertyName = property.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
        propertyName = propertyName.Equals("class") ? "@class" : propertyName;

        var accessedWith = propertySymbol.IsStatic ? baseType.ToDisplayString() : "MauiObject";

        if (!notGenerateList.Contains(propertyName))
        {
            builder.Append($@"
        public {propertyTypeName} {propertyName} {{ ");

            if (propertySymbol.GetMethod != null) builder.Append($"get => {accessedWith}.{propertyName}; ");
            if (propertySymbol.SetMethod != null && propertySymbol.SetMethod.DeclaredAccessibility == Accessibility.Public) builder.Append($"set => {accessedWith}.{propertyName} = value; ");
            builder.Append($"}}");

        }
    }

    void GenerateEvent(ISymbol @event)
    {
        var eventSymbol = (IEventSymbol)@event;
        var eventHandler = eventSymbol.AddMethod.Parameters.First();

        if (!notGenerateList.Contains(eventSymbol.Name))
        {
            builder.Append($@"
        public event {eventHandler.ToDisplayString()} {eventSymbol.Name} {{ add => MauiObject.{eventSymbol.Name} += value; remove => MauiObject.{eventSymbol.Name} -= value; }}");
        }
    }

    // ----- constructor -----

    void GenerateConstructor()
    {
        if (baseType.IsSealed || generateNoParamConstructor || generateAdditionalConstructors)
            builder.AppendLine($@"
        // ----- constructors -----");

        // generate base constructors

        if (baseType.IsSealed)
        {
            builder.AppendLine($@"
        protected {mainType.Name}({baseType.ToDisplayString()} {WrapBuilder.CamelCase(mainType.Name)})
        {{
            MauiObject = {WrapBuilder.CamelCase(mainType.Name)};
        }}");
            if (generateNoParamConstructor)
            {
                builder.AppendLine($@"
        public {mainType.Name}()
        {{
            MauiObject = new {baseType.ToDisplayString()}();
        }}");
            }
        }
        else if (generateNoParamConstructor)
            builder.AppendLine($@"
        public {mainType.Name}() {{ }}");

        // generate additional constructors (out/action)

        var thisTail = baseType.IsSealed || !generateNoParamConstructor ? ": this()" : "";
        if (generateAdditionalConstructors) builder.AppendLine($@"
        public {mainType.Name}(out {mainType.Name} {WrapBuilder.CamelCase(mainType.Name)}) {thisTail}
        {{
            {WrapBuilder.CamelCase(mainType.Name)} = this;
        }}

        public {mainType.Name}(Action<{mainType.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {mainType.Name}(out {mainType.Name} {WrapBuilder.CamelCase(mainType.Name)}, Action<{mainType.Name}> configure) {thisTail}
        {{
            {WrapBuilder.CamelCase(mainType.Name)} = this;
            configure(this);
        }}");
    }


    void GenerateConstructorWithProperty()
    {
        if (constructorWithProperties.Count() > 0)
        {
            string definitionString = "";
            string assignmentString = "";
            var count = 0;
            foreach (var constructorWithProperty in constructorWithProperties)
            {
                count++;
                ISymbol property = null;

                var type = baseType;
                do
                {
                    property = type
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public && e.Name.Equals(constructorWithProperty))
                        .FirstOrDefault();
                    type = type.BaseType;
                }
                while (property == null && !type.BaseType.Name.Equals("Object"));

                if (property == null) throw new ArgumentException($"No property name : {constructorWithProperty}, type: {mainType.Name}");
                var propertyTypeName = ((IPropertySymbol)property).Type.ToDisplayString();

                definitionString += $"{propertyTypeName} {constructorWithProperty.ToLower()}";
                if (count != constructorWithProperties.Count()) definitionString += ", ";

                assignmentString += $@"
            this.{constructorWithProperty} = {constructorWithProperty.ToLower()};";
            }

            var thisTail = baseType.IsSealed ? ": this()" : "";

            builder.AppendLine($@"
        public {mainType.Name}({definitionString}) {thisTail}
        {{  {assignmentString}
        }}

        public {mainType.Name}({definitionString}, out {mainType.Name} {WrapBuilder.CamelCase(mainType.Name)}) {thisTail}
        {{  {assignmentString};
            {WrapBuilder.CamelCase(mainType.Name)} = this;
        }}

        public {mainType.Name}({definitionString}, Action<{mainType.Name}> configure) {thisTail}
        {{  {assignmentString}
            configure(this);
        }}

        public {mainType.Name}({definitionString}, out {mainType.Name} {WrapBuilder.CamelCase(mainType.Name)}, Action<{mainType.Name}> configure) {thisTail}
        {{  {assignmentString}
            {WrapBuilder.CamelCase(mainType.Name)} = this;
            configure(this);
        }}");
        }
    }

    // ----- operators -----

    void GenerateOperators()
    {
        if (baseType.IsSealed) builder.AppendLine($@"
        // ----- operators -----

        public static implicit operator {mainType.Name}({baseType.ToDisplayString()} mauiObject) => new {mainType.Name}(mauiObject);
        public static implicit operator {baseType.ToDisplayString()}({mainType.Name} obj) => obj.MauiObject;");
    }

    #endregion

}
