//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator
{
    public partial class SharpSymbol
	{
        public void BuildClass(StringBuilder builder)
        {
            this.builder = builder;
            this.GenerateSharpUINameSpace();
        }

        void GenerateContainerUsingsIfNeeded()
        {
            if (containerOfTypeName != null)
                builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
");
        }

        private string fullMainSymbolName => mainSymbol.ToDisplayString().Split('.').Last();

        void GenerateSharpUINameSpace()
        {
            this.GenerateContainerUsingsIfNeeded();
            builder.Append($@"
namespace {nameSpaceString}
{{  
    {GetUsingString()}{GetInfoString()}{GetContentPropertyString()}public partial class {fullMainSymbolName}{BaseString()}
    {{");
            GenerateClass();
            builder.Append($@"
    }}
}}");
        }

        string GetInfoString()
        {
            return IsWrappedType ? (WrappedType.IsSealed ?
                @$"/// <summary>
    /// A <c>{nameSpaceString}</c> class wrapping the sealed <c>{WrappedType.ToDisplayString()}</c> class.
    /// Use the <value>MauiObject</value> property to get the raw Maui object.
    /// </summary>
    " :
                @$"/// <summary>
    /// A <c>{nameSpaceString}</c> class inheriting from the <c>{WrappedType.ToDisplayString()}</c> class.
    /// </summary>
    ") : "";
        }

        string GetContentPropertyString()
        {
            return IsWrappedType && containerPropertyName != null && singleItemContainer && GetContentPropertyName(mainSymbol) == null ?
                $@"[ContentProperty(""{containerPropertyName}"")]
    " : "";
        }

        // ----- class builder file name -------

        public string ClassBuilderSymbolFileNeme()
        {
            return $"{mainSymbol.ContainingNamespace}.{GetNormalizedName(mainSymbol)}.g.cs";
        }


        // ----- is bindable -------

        bool IsBindable()
        {
            var isBindable = false;

            Helpers.LoopDownToObject(IsWrappedType ? WrappedType : mainSymbol, type =>
            {
                if (type.Interfaces.FirstOrDefault(e => e.Name.Equals("IBindableObject")) != null) isBindable = true;
                if (type.Name.Equals("BindableObject")) isBindable = true;
                return isBindable;
            });

            return isBindable;
        }

        // ------- base string -------

        string BaseString()
        {
            string baseString = "";
            if (IsWrappedType)
            {
                if (WrappedType.IsSealed)
                    baseString = $" : {nameSpaceString}.I{GetNormalizedName(WrappedType)}, IMauiWrapper";
                else
                    baseString = $" : {WrappedType.ToDisplayString()}, {nameSpaceString}.I{GetNormalizedName(WrappedType)}, IMauiWrapper";

                if (WrappedType.IsSealed) baseString += $", ISealedMauiWrapper";
                if (containerOfTypeName != null && singleItemContainer) baseString += $", IEnumerable";
                if (containerOfTypeName != null && !singleItemContainer) baseString += $", IList<{containerOfTypeName}>";
            }
            else
            {
                if (containerOfTypeName != null && singleItemContainer) baseString += $" : IEnumerable";
                if (containerOfTypeName != null && !singleItemContainer && !isAlreadyContainerOfThis) baseString += $" : IList<{containerOfTypeName}>";
            }
            return baseString;
        }


        //----------------------------------------
        #region class generator
        //----------------------------------------

        void GenerateClass()
        {
            if (IsWrappedType)
            {
                GenerateMauiObjectPropertyForSealedType();
                GenerateConstructors();
                GenerateOperatorsForSealedType();
                GenerateSingleItemContainer();
                GenerateCollectionContainer();
                GenerateBindableProperties();
                GenerateAttachedProperties();
                GenerateConsumedAttachedProperties();
                GenerateParentBindablePropertiesForSealedType();
                GeneratePropertiesAndEventsForSealedType();
                GenerateSetValueMethod();
            }
            else
            {
                GenerateConstructors();
                GenerateSingleItemContainer();
                GenerateCollectionContainer();
                GenerateAttachedProperties();
                if (IsBindable())
                {
                    GenerateBindableProperties();
                    GenerateConsumedAttachedProperties();
                    GenerateSetValueMethod();
                }
            }
        }

        // ------------------------
        // ----- maui object ------
        // ------------------------

        void GenerateMauiObjectPropertyForSealedType()
        {
            if (WrappedType.IsSealed)
                builder.AppendLine($@"
        // ----- maui object -----

        public object _maui_RawObject {{ get; set; }}

        public {WrappedType.ToDisplayString()} MauiObject {{ get => ({WrappedType.ToDisplayString()})_maui_RawObject; protected set => _maui_RawObject = value; }}");
        }

        // ------------------------
        // ----- constructors -----
        // ------------------------

        void GenerateConstructors()
        {
            this.GenerateConstructorsHeader();

            if (IsWrappedType && WrappedType.IsSealed) GenerateConstructorForSealedType();
            if (generateNoParamConstructor) GenerateNoParamConstructor();
            if (this.generateAdditionalConstructors) GenerateAdditionalConstructors();
        }

        // generate constructor header

        void GenerateConstructorsHeader()
        {
            if (IsWrappedType && WrappedType.IsSealed || generateNoParamConstructor || generateAdditionalConstructors)
                builder.AppendLine($@"
        // ----- constructors -----");
        }

        // generate constructor for sealed type

        void GenerateConstructorForSealedType()
        {
            builder.AppendLine($@"
        public {mainSymbol.Name}({WrappedType.ToDisplayString()} {Helpers.CamelCase(mainSymbol.Name)})
        {{
            MauiObject = {Helpers.CamelCase(mainSymbol.Name)};
        }}");            
        }

        // no params constructor

        void GenerateNoParamConstructor()
        {
            if (IsWrappedType && WrappedType.IsSealed)
            {
                builder.AppendLine($@"
        public {mainSymbol.Name}()
        {{
            MauiObject = new {WrappedType.ToDisplayString()}();
        }}");
            }
            else
            {
                builder.AppendLine($@"
        public {mainSymbol.Name}() {{ }}");
            }
        }

        // additional constructors

        void GenerateAdditionalConstructors()
        {
            var argsString = "";
            var baseArgsString = "";
            var thisTail = "";

            var buildConstructors = () =>
            {
                builder.AppendLine($@"
        public {mainSymbol.Name}({argsString}out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}) {thisTail}
        {{
            {Helpers.CamelCase(mainSymbol.Name)} = this;
        }}");

                if (containerOfTypeName != null || isAlreadyContainerOfThis)
                    builder.AppendLine($@"
        public {mainSymbol.Name}({argsString}System.Action<{mainSymbol.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {mainSymbol.Name}({argsString}out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}, System.Action<{mainSymbol.Name}> configure) {thisTail}
        {{
            {Helpers.CamelCase(mainSymbol.Name)} = this;
            configure(this);
        }}");
            };

            if (generateNoParamConstructor)
            {
                thisTail = IsWrappedType && WrappedType.IsSealed ? $": this()" : "";
                buildConstructors();
            }

            var constructors = mainSymbol.Constructors.Where(e => !e.IsImplicitlyDeclared);

            foreach (var constructor in constructors)
            {
                argsString = "";
                baseArgsString = "";

                foreach (var argument in constructor.Parameters)
                {
                    var camelCaseName = Helpers.CamelCase(argument.Name);

                    argsString += $"{argument.Type.ToDisplayString()} {camelCaseName}, ";

                    if (!string.IsNullOrEmpty(baseArgsString)) baseArgsString += ", ";
                    baseArgsString += $"{camelCaseName}";
                }

                thisTail = $": this({baseArgsString})";
                buildConstructors();
            }
        }        

        // ------------------------
        // ------ operators -------
        // ------------------------

        void GenerateOperatorsForSealedType()
        {
            if (WrappedType.IsSealed) builder.AppendLine($@"
        // ----- operators -----

        public static implicit operator {mainSymbol.Name}({WrappedType.ToDisplayString()} mauiObject) => new {mainSymbol.Name}(mauiObject);
        public static implicit operator {WrappedType.ToDisplayString()}({mainSymbol.Name} obj) => obj.MauiObject;");
        }

        // --------------------------------------
        // ---- generate bindable properties ----
        // --------------------------------------

        void GenerateBindableProperties()
        {
            if (IsBindable())
            {
                var bindableInterfaces = mainSymbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(BindablePropertiesAttributeString)) != null);

                if (bindableInterfaces.Count() > 0) builder.AppendLine($@"
        // ----- bindable properties -----");

                foreach (var inter in bindableInterfaces)
                {
                    var properties = inter
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Property);

                    foreach (var prop in properties)
                    {
                        GeneratePropertyForField((IPropertySymbol)prop);
                    }
                }
            }
        }

        void GeneratePropertyForField(IPropertySymbol symbol)
        {
            var name = symbol.Name;
            var typeName = symbol.Type.ToDisplayString();
            var callbacks = GetPropertyCallbacks(symbol);
            var defaultValueString = GetDefaultValueString(symbol, typeName);
            var callbacksString = "";

            var implementedProperty = mainSymbol
                .GetMembers()
                .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public && e.Name.Equals(symbol.Name)).FirstOrDefault();

            foreach (var callback in callbacks)
            {
                callbacksString = $@",
                {callback.Key}: {callback.Value}";
            }

            builder.AppendLine($@"
        public static readonly Microsoft.Maui.Controls.BindableProperty {name}Property =
            BindableProperty.Create(
                nameof({name}),
                typeof({typeName}),
                typeof({mainSymbol.ToDisplayString()}),
                {(defaultValueString != null ? $"({typeName}){defaultValueString}" : $"default({typeName})")}{callbacksString});");

            if (implementedProperty is null)
                builder.AppendLine($@"
        public {typeName} {name}
        {{
            get => ({typeName})GetValue({name}Property);
            set => SetValue({name}Property, value);
        }}");
        }

        // ----------------------------------------
        // ---- generate attached properties ----
        // ----------------------------------------

        void GenerateAttachedProperties()
        {
            if (attachedInterfacesAttribute != null)
            {
                var attachedInterfaces = attachedInterfacesAttribute.ConstructorArguments[0].Values
                    .Select(e => (INamedTypeSymbol)e.Value)
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedPropertiesAttributeString)) != null).ToList();

                if (attachedInterfaces.Count() > 0) builder.AppendLine($@"
        // ----- attached properties -----");

                foreach (var inter in attachedInterfaces)
                {
                    var properties = inter
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Property);

                    foreach (var prop in properties)
                        GenerateAttachablePropertyForField((IPropertySymbol)prop);
                }
            }
        }

        void GenerateAttachablePropertyForField(IPropertySymbol symbol)
        {
            var name = GetAttachedName(symbol);
            var typeName = symbol.Type.ToDisplayString();
            var callbacks = GetPropertyCallbacks(symbol);
            var defaultValueString = GetDefaultValueString(symbol, typeName);
            var callbacksString = "";

            foreach (var callback in callbacks)
            {
                callbacksString = $@",
                {callback.Key}: {callback.Value}";
            }

            builder.Append($@"
        public static readonly Microsoft.Maui.Controls.BindableProperty {name}Property =
            BindableProperty.CreateAttached(
                ""{name}"",
                typeof({typeName}),
                typeof({mainSymbol.ToDisplayString()}),
                {(defaultValueString != null ? $"({typeName}){defaultValueString}" : $"default({typeName})")}{callbacksString});

        public static {typeName} Get{name}(BindableObject obj)
        {{
            return ({typeName})obj.GetValue({name}Property);
        }}

        public static void Set{name}(BindableObject obj, {typeName} value)
        {{
            obj.SetValue({name}Property, value);
        }}
        ");
        }

        // -----------------------------------------------
        // ---- generate consumed attached properties ----
        // -----------------------------------------------

        void GenerateConsumedAttachedProperties()
        {
            var bindableInterfaces = mainSymbol
                .Interfaces
                .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedPropertiesAttributeString)) != null);

            if (bindableInterfaces.Count() > 0) builder.AppendLine($@"
        // ----- consumed attached properties -----");

            foreach (var inter in bindableInterfaces)
            {
                var attribute = inter.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedPropertiesAttributeString));
                if (attribute != null)
                {
                    var attachedType = attribute.ConstructorArguments[0].Value as INamedTypeSymbol;

                    var properties = inter
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property);

                    foreach (var prop in properties)
                        GenerateAttachedPropertyForField(attachedType, (IPropertySymbol)prop);
                }
            }
        }

        void GenerateAttachedPropertyForField(INamedTypeSymbol attachedType, IPropertySymbol symbol)
        {
            var attachedPropName = symbol.Name.Replace(attachedType.Name, "");
            var typeName = symbol.Type.ToDisplayString();
            
            builder.Append($@"
        public {typeName} {symbol.Name}
        {{
            get => ({typeName})GetValue({attachedType.ToDisplayString()}.{attachedPropName}Property);
            set => SetValue({attachedType.ToDisplayString()}.{attachedPropName}Property, value);
        }}
        ");
        }

        // ---------------------------------
        // ----- single item container -----
        // ---------------------------------

        void GenerateSingleItemContainer()
        {
            if (containerOfTypeName != null && singleItemContainer == true)
            {
                var newPrefix = isNewContainer ? " new" : "";

                builder.AppendLine($@"
        // ----- single item container -----

        public{newPrefix} IEnumerator GetEnumerator() {{ yield return this.{containerPropertyName}; }}
        public{newPrefix} void Add({containerOfTypeName} {containerPropertyName.ToLower()}) => this.{containerPropertyName} = {containerPropertyName.ToLower()};");
            }
        }

        // --------------------------------
        // ----- collection container -----    
        // --------------------------------

        void GenerateCollectionContainer()
        {
            if (containerOfTypeName != null && singleItemContainer == false)
            {
                if (IsWrappedSealedType || !isAlreadyContainerOfThis)
                {
                    var newPrefix = isNewContainer ? " new" : "";

                    var prefix = IsWrappedSealedType ?
                        (isAlreadyContainerOfThis ? "this.MauiObject" : $"this.MauiObject.{containerPropertyName}") :
                        $"this.{containerPropertyName}";

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
        public{newPrefix} IEnumerator<{containerOfTypeName}> GetEnumerator() => {prefix}.GetEnumerator();
        public int IndexOf({containerOfTypeName} item) => {prefix}.IndexOf(item);
        public void Insert(int index, {containerOfTypeName} item) => {prefix}.Insert(index, item);
        public bool Remove({containerOfTypeName} item) => {prefix}.Remove(item);
        public void RemoveAt(int index) => {prefix}.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => {prefix}.GetEnumerator();");
                }
            }
        }

        // -------------------------------------------
        // ----- sealed type bindable properties -----    
        // -------------------------------------------

        private List<string> sealedBindablePropertiesNames = new List<string>();

        void GenerateParentBindablePropertiesForSealedType()
        {
            if (WrappedType.IsSealed && IsBindable())
            {
                builder.AppendLine($@"
        // ----- sealed bindable properties -----");

                Helpers.LoopDownToObject(WrappedType, type =>
                {
                    var properties = type
                        .GetMembers()
                        .Where(e => e.IsStatic && e.Name.EndsWith("Property") && e.DeclaredAccessibility == Accessibility.Public);

                    foreach (var prop in properties) GenerateBindableProperty(prop);

                    return false;
                });

                builder.AppendLine();
            }
        }

        // bindable property

        void GenerateBindableProperty(ISymbol property)
        {
            var name = property.Name.Substring(0, property.Name.Length - "Property".Length);
            if (!notGenerateList.Contains(property.Name) && !sealedBindablePropertiesNames.Contains(property.Name))
            {
                sealedBindablePropertiesNames.Add(property.Name);
                builder.Append($@"
        public static Microsoft.Maui.Controls.BindableProperty {property.Name} => {property.ToDisplayString()};");
            }
        }

        // ------------------------------------------
        // ----- generate properties and events -----
        // ------------------------------------------

        void GeneratePropertiesAndEventsForSealedType()
        {
            List<string> doneList = new List<string>();

            builder.AppendLine($@"
        // ----- properties / events -----");

            Helpers.LoopDownToObject(WrappedType, type =>
            {
                var properties = type
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public);

                foreach (var prop in properties)
                {
                    if (!doneList.Contains(prop.Name))
                    {
                        GenerateProperty(prop);
                        doneList.Add(prop.Name);
                    }
                }
                return false;
            });

            if (WrappedType.IsSealed)
            {
                Helpers.LoopDownToObject(WrappedType, type =>
                {
                    var events = type
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Event && e.DeclaredAccessibility == Accessibility.Public);

                    foreach (var @event in events)
                    {
                        if (!doneList.Contains(@event.Name))
                        {
                            GenerateEvent(@event);
                            doneList.Add(@event.Name);
                        }
                    }
                    return false;
                });
            }

            builder.AppendLine();
        }

        static void CheckIfIsWrappedSealedType(ITypeSymbol symbolType, out bool isWrappedSealedType, out bool isArrayOfWrappedSealedType, out bool isObjectType, out string symbolNamespace)
        {
            isWrappedSealedType = false;
            isArrayOfWrappedSealedType = false;
            isObjectType = false;
            symbolNamespace = null;
            if (symbolType is INamedTypeSymbol)
            {
                symbolNamespace = symbolType.ContainingNamespace.ToDisplayString();
                if (symbolType.Name.Equals("Object"))
                    isObjectType = true;
                else
                {
                    var propertyType = symbolType as INamedTypeSymbol;
                    if (propertyType.IsGenericType && Helpers.IsGenericIList(propertyType, out var itemTypeName))
                    {

                    }
                    else if (propertyType.TypeKind != TypeKind.Interface)
                    {
                        var existInSealed = SharpBuilder.SharpSealedTypeDict.Keys.Contains(propertyType.Name);
                        if (existInSealed) symbolNamespace = SharpBuilder.SharpSealedTypeDict[propertyType.Name].ContainingNamespace.ToDisplayString();
                        isWrappedSealedType = existInSealed || IsISealedMauiWrapper(propertyType);
                    }
                }
            }
            else if (symbolType is IArrayTypeSymbol)
            {
                var arrayTypeSymbol = (IArrayTypeSymbol)symbolType;
                if (arrayTypeSymbol.ElementType is INamedTypeSymbol)
                {
                    symbolNamespace = arrayTypeSymbol.ElementType.ContainingNamespace.ToDisplayString();

                    var propertyType = arrayTypeSymbol.ElementType as INamedTypeSymbol;
                    var existInSealed = SharpBuilder.SharpSealedTypeDict.Keys.Contains(propertyType.Name);
                    if (existInSealed) symbolNamespace = SharpBuilder.SharpSealedTypeDict[propertyType.Name].ContainingNamespace.ToDisplayString();
                    isArrayOfWrappedSealedType = existInSealed || IsISealedMauiWrapper(propertyType);
                }
            }
        }

        void GenerateProperty(ISymbol property)
        {
            var propertySymbol = (IPropertySymbol)property;

            CheckIfIsWrappedSealedType(propertySymbol.Type, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType, out var symbolNamespace);

            var propertyName = property.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class") ? "@class" : propertyName;

            var accessedWith = propertySymbol.IsStatic ? WrappedType.ToDisplayString() : (WrappedType.IsSealed ? "MauiObject" : "base");
            var newKeyword = WrappedType.IsSealed ? "" : "new ";

            var propertyTypeName = isWrappedSealedType ? $"{nameSpaceString}.{propertySymbol.Type.Name}" : propertySymbol.Type.ToDisplayString();
            var getterString = isWrappedSealedType ? $"new {nameSpaceString}.{propertySymbol.Type.Name}({accessedWith}.{propertyName})" : $"{accessedWith}.{propertyName}";
            var setterString = isObjectType ? $"MauiWrapper.Value<object>(value)" : (isWrappedSealedType ? "value.MauiObject" : "value");

            var doGenerate = WrappedType.IsSealed || (propertySymbol.SetMethod != null && isWrappedSealedType) || isObjectType;

            if (!notGenerateList.Contains(propertyName) && doGenerate)
            {
                builder.Append($@"
        public {newKeyword}{propertyTypeName} {propertyName} {{ ");

                if (propertySymbol.GetMethod != null) builder.Append($"get => {getterString}; ");
                if (propertySymbol.SetMethod != null && propertySymbol.SetMethod.DeclaredAccessibility == Accessibility.Public) builder.Append($"set => {accessedWith}.{propertyName} = {setterString}; ");
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
        public event {eventHandler.Type.ToDisplayString()} {eventSymbol.Name} {{ add => MauiObject.{eventSymbol.Name} += value; remove => MauiObject.{eventSymbol.Name} -= value; }}");
            }
        }

        // ---------------------------------------
        // ------ generate set value method ------
        // ---------------------------------------

        

        void GenerateSetValueMethod()
        {
            if (IsBindable())
            {
                CheckIfIsWrappedSealedType(mainSymbol, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType, out var symbolNamespace);

                builder.Append($@"
        // ----- set value method -----
");
                if (isWrappedSealedType)
                    builder.Append($@"
        public void SetValue(Microsoft.Maui.Controls.BindableProperty property, object value)
        {{
            var mauiValue = MauiWrapper.Value<object>(value);
            MauiObject.SetValue(property, mauiValue);
        }}

        public void SetValue(Microsoft.Maui.Controls.BindablePropertyKey propertyKey, object value)
        {{
            var mauiValue = MauiWrapper.Value<object>(value);
            MauiObject.SetValue(propertyKey, mauiValue);
        }}");
                else
                    builder.Append($@"
        public new void SetValue(Microsoft.Maui.Controls.BindableProperty property, object value)
        {{
            var mauiValue = MauiWrapper.Value<object>(value);
            ((Microsoft.Maui.Controls.BindableObject)this).SetValue(property, mauiValue);
        }}

        public new void SetValue(Microsoft.Maui.Controls.BindablePropertyKey propertyKey, object value)
        {{
            var mauiValue = MauiWrapper.Value<object>(value);
            ((Microsoft.Maui.Controls.BindableObject)this).SetValue(propertyKey, mauiValue);
        }}");
            }
        }

        #endregion
    }
}