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

            this.GenerateContainerUsingsIfNeeded();
            this.GenerateNameSpace();
        }

        void GenerateContainerUsingsIfNeeded()
        {
            if (containerOfTypeName != null)
                builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
");
        }

        void GenerateNameSpace()
        {
            builder.Append($@"
namespace {nameSpaceString}
{{
    public partial class {mainSymbol.Name}{BaseString()}
    {{");
            GenerateClass();
            builder.Append($@"
    }}
}}");
        }

        // ----- class builder file name -------

        public string ClassBuilderSymbolFileNeme()
        {
            return $"{mainSymbol.ContainingNamespace}.{mainSymbol.Name}.g.cs";
        }


        // ----- is bindable -------

        bool IsBindable()
        {
            var isBindable = false;

            Helpers.LoopDownToObject(IsWrappedType ? WrappedType : mainSymbol, type =>
            {
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
                baseString = $" : Sharp.UI.I{GetNormalizedName(WrappedType)}";
            else
                baseString = $" : {WrappedType.ToDisplayString()}, Sharp.UI.I{GetNormalizedName(WrappedType)}";

            if (WrappedType.IsSealed) baseString += $", ISealedMauiWrapper";
            if (containerOfTypeName != null && singleItemContainer) baseString += $", IEnumerable";
            if (containerOfTypeName != null && !singleItemContainer) baseString += $", IList<{containerOfTypeName}>";
            if (IsBindable()) baseString += ", IWrappedBindableObject";
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
                GenerateBindingContext();
            }
            else
            {
                GenerateConstructors();
                GenerateConstructorWithProperties();
                GenerateBindableProperties();
                GenerateAttachedProperties();
                GenerateBindingContext();
            }
        }

        // ------------------------
        // ----- maui object ------
        // ------------------------

        void GenerateMauiObjectPropertyForSealedType()
        {
            if (WrappedType.IsSealed) builder.AppendLine($@"
        // ----- maui object -----

        public object _maui_RawObject {{ get; set; }}

        public {WrappedType.ToDisplayString()} MauiObject {{ get => ({WrappedType.ToDisplayString()})_maui_RawObject; set => _maui_RawObject = value; }}");
        }

        // ------------------------
        // ----- constructors -----
        // ------------------------

        void GenerateConstructors()
        {
            this.GenerateConstructorsHeader();

            if (IsWrappedType && WrappedType.IsSealed) GenerateConstructorForSealedType();
            if (generateNoParamConstructor) GenerateNoParamConstructor();
            if (generateAdditionalConstructors) GenerateAdditionalConstructors();
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
        protected {mainSymbol.Name}({WrappedType.ToDisplayString()} {Helpers.CamelCase(mainSymbol.Name)})
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
            var thisTail = IsWrappedType && WrappedType.IsSealed || !generateNoParamConstructor ? ": this()" : "";
            builder.AppendLine($@"
        public {mainSymbol.Name}(out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}) {thisTail}
        {{
            {Helpers.CamelCase(mainSymbol.Name)} = this;
        }}

        public {mainSymbol.Name}(Action<{mainSymbol.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {mainSymbol.Name}(out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}, Action<{mainSymbol.Name}> configure) {thisTail}
        {{
            {Helpers.CamelCase(mainSymbol.Name)} = this;
            configure(this);
        }}");
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

        public {mainSymbol.Name}({definitionString}, Action<{mainSymbol.Name}> configure) {thisTail}
        {{  {assignmentString}
            configure(this);
        }}

        public {mainSymbol.Name}({definitionString}, out {mainSymbol.Name} {Helpers.CamelCase(mainSymbol.Name)}, Action<{mainSymbol.Name}> configure) {thisTail}
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

        void GeneratePropertyForField(IPropertySymbol symbol)
        {
            var name = symbol.Name;
            var typeName = symbol.Type.Name;

            builder.Append($@"
        public static readonly BindableProperty {name}Property = BindableProperty.Create(nameof({name}), typeof({typeName}), typeof({mainSymbol.ToDisplayString()}), default({typeName}));

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
            var typeName = symbol.Type.Name;

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
            if (WrappedType.IsSealed)
            {
                builder.AppendLine($@"
        // ----- bindable properties -----");

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
            if (WrappedType.IsSealed)
            {
                builder.AppendLine($@"
        // ----- properties / events -----");

                List<string> doneList = new List<string>();

                Helpers.LoopDownToObject(WrappedType, type =>
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
                    return false;
                });
            }
        }

        void GenerateProperty(ISymbol property)
        {
            var propertySymbol = (IPropertySymbol)property;
            var propertyTypeName = propertySymbol.Type.ToDisplayString();

            var propertyName = property.Name.Split(new[] { "." }, StringSplitOptions.None).Last();
            propertyName = propertyName.Equals("class") ? "@class" : propertyName;

            var accessedWith = propertySymbol.IsStatic ? WrappedType.ToDisplayString() : "MauiObject";

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

        // ------------------------------------
        // ----- generate binding context -----
        // ------------------------------------

        void GenerateBindingContext()
        {
            if (IsBindable())
            {
                var newKeyword = IsWrappedType && WrappedType.IsSealed ? " " : " new ";
                var accessedWith = IsWrappedType && WrappedType.IsSealed ? "MauiObject" : "base";
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

        #endregion
    }
}