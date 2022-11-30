using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

namespace MauiWrapperGenerator;

public class MauiSymbolBuilder
{
    private readonly StringBuilder builder;

    private readonly INamedTypeSymbol sharpUIType;

    //------ attribute parameters ------
    private readonly INamedTypeSymbol mauiType;
    private readonly List<string> notGenerateList;
    private readonly List<string> constructorWithProperties;
    //private readonly bool wrapSealedType;
    private readonly INamedTypeSymbol containerOfType = null;
    private readonly bool singleItemContainer = false;
    private readonly INamedTypeSymbol typeConformance; 
    private readonly bool generateAdditionalConstructors = false;
    private readonly bool generateNoParamConstructor = false;

    private readonly string containerPropertyName = null;
    private readonly string containerOfTypeName = null;
    private readonly string typeConformanceName;
    //private readonly string shortTypeConformanceName;

    private List<string> bindablePropertiesNames = new List<string>();

    public MauiSymbolBuilder(INamedTypeSymbol symbol, AttributeData wrapperAttribute, StringBuilder builder)
    {
        this.builder = builder;

        this.sharpUIType = symbol;

        // ------- constructor arguments ------

        // [0] mauiType
        this.mauiType = (INamedTypeSymbol)wrapperAttribute.ConstructorArguments[0].Value;

        // [1] doNotGenerate
        var notGenerateValues = wrapperAttribute.ConstructorArguments[1].Values;
        if (!notGenerateValues.IsDefaultOrEmpty)
            this.notGenerateList = notGenerateValues.Select(e => (string)e.Value).ToList();
        else
            this.notGenerateList = new List<string>();

        // [2] constructorWithProperty
        var constructorWithPropertiesValues = wrapperAttribute.ConstructorArguments[2].Values;
        if (!constructorWithPropertiesValues.IsDefaultOrEmpty)
            this.constructorWithProperties = constructorWithPropertiesValues.Select(e => (string)e.Value).ToList();
        else
            this.constructorWithProperties = new List<string>();


        // [3] containerOfType
        this.containerOfType = (INamedTypeSymbol)wrapperAttribute.ConstructorArguments[3].Value;
        // [4] singleItemContainer
        this.singleItemContainer = (bool)(wrapperAttribute.ConstructorArguments[4].Value);
        // [5] containerPropertyName
        this.containerPropertyName = (string)(wrapperAttribute.ConstructorArguments[5].Value);
        // [6] typeConformance
        this.typeConformance = (INamedTypeSymbol)wrapperAttribute.ConstructorArguments[6].Value;
        // [7] generateConstructor
        this.generateAdditionalConstructors = (bool)(wrapperAttribute.ConstructorArguments[7].Value);
        // [8] generateNoParamConstructor
        this.generateNoParamConstructor = (bool)(wrapperAttribute.ConstructorArguments[8].Value);

        //----------------------------------

        notGenerateList.Add("this[]");
        notGenerateList.Add("Handler");
        notGenerateList.Add("LogicalChildren");
        notGenerateList.Add("BindingContext");

        //if (typeConformance != null)
        //    this.typeConformanceName = typeConformance.ToDisplayString();
        //else
        //    this.typeConformanceName = mauiType.IsSealed ? sharpUIType.ToDisplayString() : mauiType.ToDisplayString();

        // ------- content attribute -------

        var mauiContentAtribute = mauiType.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains("ContentProperty"));
        if (mauiContentAtribute != null && string.IsNullOrEmpty(this.containerPropertyName))
            this.containerPropertyName = mauiContentAtribute.ConstructorArguments[0].Value.ToString();

        if (!string.IsNullOrEmpty(this.containerPropertyName))
        {
            if (containerOfType != null)
            {
                this.containerOfTypeName = containerOfType.ToDisplayString();
            }
            else
            {
                var type = mauiType;
                IPropertySymbol propertySymbol = null;

                do
                {
                    var ps = (IPropertySymbol)(type.GetMembers(this.containerPropertyName).FirstOrDefault());
                    if (ps != null) propertySymbol = ps;
                    type = type.BaseType;
                }
                while (propertySymbol == null && !type.Name.Equals("Object"));

                if (propertySymbol == null) throw new Exception($"No content property for: {mauiType.Name} down to: {type.Name}");

                var mauiContainerType = (INamedTypeSymbol)((propertySymbol).Type);
                if (mauiContainerType.IsGenericType)
                {
                    this.containerOfTypeName = mauiContainerType.TypeArguments.FirstOrDefault().ToDisplayString();
                    this.singleItemContainer = false;
                }
                else
                {
                    this.containerOfTypeName = mauiContainerType.ToDisplayString();
                    this.singleItemContainer = true;
                }
            }
        }

        this.typeConformanceName = $"Sharp.UI.{WrapBuilder.GetInterfaceName(mauiType)}";

        //var tail = mauiType.IsGenericType ? $"{mauiType.TypeArguments.FirstOrDefault().Name}" : "";
        //this.shortTypeConformanceName = typeConformanceName.Split(new[] { '<' }).First().Split(new[] { '.' }).Last();
        //if (typeConformanceName.Contains("Compatibility")) shortTypeConformanceName = $"Compatibility{shortTypeConformanceName}{tail}";
    }

    //----------------------------------------
    #region namespace buider
    //----------------------------------------

    public void Buid()
    {
        if (containerOfTypeName != null)
            builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
");
        builder.Append($@"
namespace Sharp.UI
{{
    public partial class {sharpUIType.Name} {BaseString()}
    {{");
        GenerateClass();
        builder.Append($@"
    }}
    ");
        GenerateExtensionCollectionMethod();
        builder.Append($@"
}}");
    }

    // ----- Strings -----

    bool IsBindable()
    {
        var isBindable = false;
        var type = mauiType;

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
        if (mauiType.IsSealed)
            baseString = $": Sharp.UI.{WrapBuilder.GetInterfaceName(mauiType)}";
        else
            baseString = $": {mauiType.ToDisplayString()}, Sharp.UI.{WrapBuilder.GetInterfaceName(mauiType)}";

        if (mauiType.IsSealed) baseString += $", ISealedMauiWrapper";
        if (containerOfTypeName != null && singleItemContainer) baseString += $", IEnumerable";
        if (containerOfTypeName != null && !singleItemContainer) baseString += $", IList<{containerOfTypeName}>";
        if (IsBindable()) baseString += ", IWrappedBindableObject";
        return baseString;
    }

    #endregion

    //----------------------------------------
    #region bindable class generator
    //----------------------------------------

    void GenerateBindable()
    {
        if (mauiType.IsSealed)
        {
            builder.AppendLine($@"
        // ----- bindable properties -----");

            var type = mauiType;
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
        GenerateSingleItemContainer();
        GenerateCollectionDeclaration();
        GenerateBindable();
        GeneratePropertiesAndEvents();
        GenerateBindingContext();
    }

    // ----- single item container -----

    void GenerateSingleItemContainer()
    {
        if (containerOfTypeName != null && singleItemContainer == true) builder.AppendLine($@"
        // ----- single item container -----

        public IEnumerator GetEnumerator() {{ throw new NotImplementedException(); }}

        public void Add({containerOfTypeName} {containerPropertyName.ToLower()}) => this.{containerPropertyName} = {containerPropertyName.ToLower()};");
    }

    // ----- collection -----

    bool IsIList(INamedTypeSymbol symbol)
    {
        var isIList = false;
        var type = symbol;
        do
        {
            foreach (var inter in type.Interfaces)
                if (inter.Name.Contains("IList")) isIList = true;
            type = type.BaseType;
        }
        while (!type.Name.Equals("Object") && !isIList);
        return isIList;
    }

    void GenerateCollectionDeclaration()
    {
        var prefix = $"this.{containerPropertyName}";
        if (mauiType.IsSealed) prefix = containerPropertyName.Equals("this") ? "this.MauiObject" : $"this.MauiObject.{containerPropertyName}";

        if (containerOfTypeName != null && singleItemContainer == false && (mauiType.IsSealed || !IsIList(mauiType)))
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
            var newKeyword = mauiType.IsSealed ? " " : " new ";
            var accessedWith = mauiType.IsSealed ? "MauiObject" : "base";
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
        if (mauiType.IsSealed) builder.AppendLine($@"
        // ----- maui object -----

        public object _maui_RawObject {{ get; set; }}

        public {mauiType.ToDisplayString()} MauiObject {{ get => ({mauiType.ToDisplayString()})_maui_RawObject; set => _maui_RawObject = value; }}");
    }

    // ------ generate properties and events in class

    void GeneratePropertiesAndEvents()
    {
        if (mauiType.IsSealed)
        {
            builder.AppendLine($@"
        // ----- properties / events -----");

            var type = mauiType;
            do
            {
                var properties = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public);

                var events = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Event && e.DeclaredAccessibility == Accessibility.Public);

                foreach (var prop in properties) GenerateProperty(prop);
                foreach (var @event in events) GenerateEvent(@event);

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

        var accessedWith = propertySymbol.IsStatic ? mauiType.ToDisplayString() : "MauiObject";

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
        if (mauiType.IsSealed || generateNoParamConstructor || generateAdditionalConstructors)
            builder.AppendLine($@"
        // ----- constructors -----
        ");

        // generate base constructors

        if (mauiType.IsSealed)
        {
            builder.AppendLine($@"
        public {sharpUIType.Name}({mauiType.ToDisplayString()} {WrapBuilder.CamelCase(sharpUIType.Name)})
        {{
            MauiObject = {WrapBuilder.CamelCase(sharpUIType.Name)};
        }}");
            if (generateNoParamConstructor)
            {
                builder.AppendLine($@"
        public {sharpUIType.Name}()
        {{
            MauiObject = new {mauiType.ToDisplayString()}();
        }}");
            }
        }
        else if (generateNoParamConstructor)
            builder.AppendLine($@"
        public {sharpUIType.Name}() {{ }}");

        // generate additional constructors (out/action)

        var thisTail = mauiType.IsSealed || !generateNoParamConstructor ? ": this()" : "";
        if (generateAdditionalConstructors) builder.AppendLine($@"

        public {sharpUIType.Name}(out {sharpUIType.Name} {WrapBuilder.CamelCase(sharpUIType.Name)}) {thisTail}
        {{
            {WrapBuilder.CamelCase(sharpUIType.Name)} = this;
        }}

        public {sharpUIType.Name}(Action<{sharpUIType.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {sharpUIType.Name}(out {sharpUIType.Name} {WrapBuilder.CamelCase(sharpUIType.Name)}, Action<{sharpUIType.Name}> configure) {thisTail}
        {{
            {WrapBuilder.CamelCase(sharpUIType.Name)} = this;
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

                var type = mauiType;
                do
                {
                    property = type
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public && e.Name.Equals(constructorWithProperty))
                        .FirstOrDefault();
                    type = type.BaseType;
                }
                while (property == null && !type.BaseType.Name.Equals("Object"));

                if (property == null) throw new ArgumentException($"No property name : {constructorWithProperty}, type: {sharpUIType.Name}");
                var propertyTypeName = ((IPropertySymbol)property).Type.ToDisplayString();

                definitionString += $"{propertyTypeName} {constructorWithProperty.ToLower()}";
                if (count != constructorWithProperties.Count()) definitionString += ", ";

                assignmentString += $@"
            this.{constructorWithProperty} = {constructorWithProperty.ToLower()};";
            }

            var thisTail = mauiType.IsSealed ? ": this()" : "";

            builder.AppendLine($@"
        public {sharpUIType.Name}({definitionString}) {thisTail}
        {{  {assignmentString}
        }}

        public {sharpUIType.Name}({definitionString}, out {sharpUIType.Name} {WrapBuilder.CamelCase(sharpUIType.Name)}) {thisTail}
        {{  {assignmentString};
            {WrapBuilder.CamelCase(sharpUIType.Name)} = this;
        }}

        public {sharpUIType.Name}({definitionString}, Action<{sharpUIType.Name}> configure) {thisTail}
        {{  {assignmentString}
            configure(this);
        }}

        public {sharpUIType.Name}({definitionString}, out {sharpUIType.Name} {WrapBuilder.CamelCase(sharpUIType.Name)}, Action<{sharpUIType.Name}> configure) {thisTail}
        {{  {assignmentString}
            {WrapBuilder.CamelCase(sharpUIType.Name)} = this;
            configure(this);
        }}");
        }
    }

    // ----- operators -----

    void GenerateOperators()
    {
        if (mauiType.IsSealed) builder.AppendLine($@"
        // ----- operators -----

        public static implicit operator {sharpUIType.Name}({mauiType.ToDisplayString()} mauiObject) => new {sharpUIType.Name}(mauiObject);
        public static implicit operator {mauiType.ToDisplayString()}({sharpUIType.Name} obj) => obj.MauiObject;");
    }

    #endregion


    void GenerateExtensionCollectionMethod()
    {
        if (containerOfTypeName != null && singleItemContainer == false && !containerPropertyName.Equals("this"))
        {
            var tail = mauiType.IsGenericType ? $"{mauiType.TypeArguments.FirstOrDefault().Name}" : "";
            var startWith = mauiType.ContainingNamespace.Name.Contains("Compatibility") ? "Compatibility" : "";

            builder.AppendLine($@"
    public static class I{startWith}{mauiType.Name}{tail}GeneratedContainerExtension
    {{
        // ----- collection container extension -----
        public static T {containerPropertyName}<T>(this T obj, params {containerOfTypeName}[] {WrapBuilder.CamelCase(containerPropertyName)}) where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            foreach (var item in {WrapBuilder.CamelCase(containerPropertyName)}) mauiObject.{containerPropertyName}.Add(item);
            return obj;
        }}

        public static T {containerPropertyName}<T>(this T obj,
            Func<CollectionDef<{containerOfTypeName}>, CollectionDef<{containerOfTypeName}>> definition)
            where T : {typeConformanceName}
        {{
            var mauiObject = MauiWrapper.GetObject<{mauiType.ToDisplayString()}>(obj);
            var def = definition(new CollectionDef<{containerOfTypeName}>());
            if (def.ValueIsSet())
            {{
                var items = def.GetValue();
                foreach (var item in items) mauiObject.{containerPropertyName}.Add(item);
            }}
            return obj;
        }}
    }}");
        }
    }
}
