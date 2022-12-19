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

            if (IsUserDefiniedType)
                this.GenerateUserDefinedNameSpace();
            else
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
            var infoText = IsWrappedType ? (WrappedType.IsSealed ?
                @$"
    /// <summary>
    /// A <c>Sharp.UI</c> class wrapping the sealed <c>{WrappedType.ToDisplayString()}</c> class.
    /// Use the <value>MauiObject</value> property to get the raw Maui object.
    /// </summary>" :
                @$"
    /// <summary>
    /// A <c>Sharp.UI</c> class inheriting from the <c>{WrappedType.ToDisplayString()}</c> class.
    /// </summary>") : "";
    
            this.GenerateContainerUsingsIfNeeded();
            builder.Append($@"
namespace {nameSpaceString}
{{  {infoText}
    public partial class {fullMainSymbolName}{BaseString()}
    {{");
            GenerateClass();
            builder.Append($@"
    }}
}}");
        }

        void GenerateUserDefinedNameSpace()
        {
            builder.Append($@"
namespace {nameSpaceString}
{{
    using Sharp.UI;

    public partial class {fullMainSymbolName}
    {{");
            GenerateClass();
            builder.Append($@"
    }}
}}");
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
            if (!IsWrappedType) return "";
            string baseString;
            if (WrappedType.IsSealed)
                baseString = $" : Sharp.UI.I{GetNormalizedName(WrappedType)}, IMauiWrapper";
            else
                baseString = $" : {WrappedType.ToDisplayString()}, Sharp.UI.I{GetNormalizedName(WrappedType)}, IMauiWrapper";

            if (WrappedType.IsSealed) baseString += $", ISealedMauiWrapper";
            if (containerOfTypeName != null && singleItemContainer) baseString += $", IEnumerable";
            if (containerOfTypeName != null && !singleItemContainer) baseString += $", IList<{containerOfTypeName}>";
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
                GenerateConstructorWithProperties();
                GenerateOperatorsForSealedType();
                GenerateBindableProperties();
                GenerateAttachedProperties();
                GenerateSingleItemContainer();
                GenerateCollectionContainer();
                GenerateParentBindablePropertiesForSealedType();
                GeneratePropertiesAndEventsForSealedType();
                GenerateSetValueMethod();
            }
            else
            {
                GenerateConstructors();
                GenerateConstructorWithProperties();
                if (IsBindable())
                {
                    GenerateBindableProperties();
                    GenerateAttachedProperties();
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
            else
                builder.AppendLine($@"
        // ----- maui object -----

        public {mainSymbol.ToDisplayString()} MauiObject {{ get => this; }}");
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
        }}

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

        // --------------------------------------
        // ----- constructors with property -----
        // --------------------------------------

        void GenerateConstructorWithProperties()
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

                    Helpers.LoopDownToObject(IsWrappedType ? WrappedType : mainSymbol, type =>
                    {
                        property = type
                            .GetMembers()
                            .Where(e => e.Kind == SymbolKind.Property && e.DeclaredAccessibility == Accessibility.Public && e.Name.Equals(constructorWithProperty))
                            .FirstOrDefault();
                        return property != null;
                    });

                    if (property == null) throw new ArgumentException($"No property name : {constructorWithProperty}, type: {mainSymbol.Name}");
                    var propertyTypeName = ((IPropertySymbol)property).Type.ToDisplayString();

                    definitionString += $"{propertyTypeName} {constructorWithProperty.ToLower()}";
                    if (count != constructorWithProperties.Count()) definitionString += ", ";

                    assignmentString += $@"
            this.{constructorWithProperty} = {constructorWithProperty.ToLower()};";
                }

                var thisTail = IsWrappedType && WrappedType.IsSealed ? ": this()" : "";

                builder.AppendLine($@"
        public {mainSymbol.Name}({definitionString}) {thisTail}
        {{  {assignmentString}
        }}

        public {mainSymbol.Name}({definitionString}, out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}) {thisTail}
        {{  {assignmentString};
            {Helpers.CamelCase(mainSymbol.Name)} = this;
        }}

        public {mainSymbol.Name}({definitionString}, System.Action<{mainSymbol.Name}> configure) {thisTail}
        {{  {assignmentString}
            configure(this);
        }}

        public {mainSymbol.Name}({definitionString}, out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}, System.Action<{mainSymbol.Name}> configure) {thisTail}
        {{  {assignmentString}
            {Helpers.CamelCase(mainSymbol.Name)} = this;
            configure(this);
        }}");
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
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(BindablePropertiesAttributeString)) != null);

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
        }

        void GeneratePropertyForField(IPropertySymbol symbol)
        {
            var name = symbol.Name;
            var typeName = symbol.Type.ToDisplayString();

            builder.Append($@"
        public static readonly Microsoft.Maui.Controls.BindableProperty {name}Property =
            BindableProperty.Create(
                nameof({name}),
                typeof({typeName}),
                typeof({mainSymbol.ToDisplayString()}),
                default({typeName}));

        public {typeName} {name}
        {{
            get => ({typeName})GetValue({name}Property);
            set => SetValue({name}Property, value);
        }}
        ");
        }

        // --------------------------------------
        // ---- generate attached properties ----
        // --------------------------------------

        void GenerateAttachedProperties()
        {
            var bindableInterfaces = mainSymbol
                .Interfaces
                .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(AttachedPropertiesAttributeString)) != null);

            if (bindableInterfaces.Count() > 0) builder.AppendLine($@"
        // ----- attached properties -----");

            foreach (var inter in bindableInterfaces)
            {
                var attribute = inter.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Contains(AttachedPropertiesAttributeString));
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
            if (containerOfTypeName != null && singleItemContainer == true) builder.AppendLine($@"
        // ----- single item container -----

        public IEnumerator GetEnumerator() {{ yield return this.{containerPropertyName}; }}

        public void Add({containerOfTypeName} {containerPropertyName.ToLower()}) => this.{containerPropertyName} = {containerPropertyName.ToLower()};");                
        }

        // --------------------------------
        // ----- collection container -----    
        // --------------------------------

        void GenerateCollectionContainer()
        {
            var prefix = $"this.{containerPropertyName}";
            if (WrappedType.IsSealed) prefix = containerPropertyName.Equals("this") ? "this.MauiObject" : $"this.MauiObject.{containerPropertyName}";

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

        static bool IsWrappedSealedType(INamedTypeSymbol symbol)
        {
            bool isWrappedSealedType = false;
            Helpers.LoopDownToObject(symbol, type =>
            {
                isWrappedSealedType = type.Interfaces.FirstOrDefault(e => e.Name.Equals("ISealedMauiWrapper")) != null;
                return isWrappedSealedType;
            });
            return isWrappedSealedType;
        }

        static void CheckIfIsWrappedSealedType(ITypeSymbol symbolType, out bool isWrappedSealedType, out bool isArrayOfWrappedSealedType, out bool isObjectType)
        {
            isWrappedSealedType = false;
            isArrayOfWrappedSealedType = false;
            isObjectType = false;
            if (symbolType is INamedTypeSymbol)
            {
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
                        isWrappedSealedType = SharpBuilder.SharpSealedTypesNameList.Contains(propertyType.Name) || IsWrappedSealedType(propertyType);
                    }
                }
            }
            else if (symbolType is IArrayTypeSymbol)
            {
                var arrayTypeSymbol = (IArrayTypeSymbol)symbolType;
                if (arrayTypeSymbol.ElementType is INamedTypeSymbol)
                {
                    var propertyType = arrayTypeSymbol.ElementType as INamedTypeSymbol;
                    isArrayOfWrappedSealedType = SharpBuilder.SharpSealedTypesNameList.Contains(propertyType.Name) || IsWrappedSealedType(propertyType);
                }
            }
        }

        void GenerateProperty(ISymbol property)
        {
            var propertySymbol = (IPropertySymbol)property;

            CheckIfIsWrappedSealedType(propertySymbol.Type, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType);

            var propertyName = property.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class") ? "@class" : propertyName;

            var accessedWith = propertySymbol.IsStatic ? WrappedType.ToDisplayString() : (WrappedType.IsSealed ? "MauiObject" : "base");
            var newKeyword = WrappedType.IsSealed ? "" : "new ";

            var propertyTypeName = isWrappedSealedType ? $"Sharp.UI.{propertySymbol.Type.Name}" : propertySymbol.Type.ToDisplayString();
            var getterString = isWrappedSealedType ? $"new Sharp.UI.{propertySymbol.Type.Name}({accessedWith}.{propertyName})" : $"{accessedWith}.{propertyName}";
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
        public event {eventHandler.ToDisplayString()} {eventSymbol.Name} {{ add => MauiObject.{eventSymbol.Name} += value; remove => MauiObject.{eventSymbol.Name} -= value; }}");
            }
        }

        // ---------------------------------------
        // ------ generate set value method ------
        // ---------------------------------------

        

        void GenerateSetValueMethod()
        {
            if (IsBindable())
            {
                CheckIfIsWrappedSealedType(mainSymbol, out var isWrappedSealedType, out var isArrayOfWrappedSealedType, out var isObjectType);

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