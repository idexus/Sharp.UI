//
// MIT License
// Copyright Pawel Krzywdzinski
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Classes
{
    /// <summary>
    /// All the semantic analysis that used to live inside ClassGenerator.
    /// Runs in the pipeline's 'transform' stage and yields nothing but a ClassModel.
    /// </summary>
    internal static class ClassModelBuilder
    {
        // ----- diagnostics (replacing the former throw new ArgumentException) -----

        public static readonly DiagnosticDescriptor ContentPropertyOnIList = new DiagnosticDescriptor(
            id: "SHARPUI001",
            title: "Invalid ContentProperty usage",
            messageFormat: "Type '{0}' implements IList<T>, you cannot use the ContentProperty attribute",
            category: "Sharp.UI",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor MissingContentProperty = new DiagnosticDescriptor(
            id: "SHARPUI002",
            title: "Missing content property",
            messageFormat: "No content property '{1}' found for type '{0}'",
            category: "Sharp.UI",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor EmptyPropertyCallbacks = new DiagnosticDescriptor(
            id: "SHARPUI003",
            title: "Empty PropertyCallbacks attribute",
            messageFormat: "PropertyCallbacks attribute on '{0}' must define at least one callback",
            category: "Sharp.UI",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor UnexpectedError = new DiagnosticDescriptor(
            id: "SHARPUI004",
            title: "Sharp.UI generator error",
            messageFormat: "Error while processing '{0}': {1}",
            category: "Sharp.UI",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        const string DefaultValueAttributeString = "DefaultValueAttribute";
        const string PropertyCallbackAttributeString = "PropertyCallbacksAttribute";

        // -----------------------------------------------------------------

        public static ClassModelResult Build(INamedTypeSymbol symbol, CancellationToken ct)
        {
            try
            {
                return BuildCore(symbol, ct);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return Error(UnexpectedError, symbol, symbol.ToDisplayString(), ex.Message);
            }
        }

        static ClassModelResult BuildCore(INamedTypeSymbol symbol, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var isShell = Shared.IsShell(symbol);
            var isTopContentSymbol = symbol.IsSealed && (Shared.IsContentPage(symbol) || isShell);
            var isSharpObject = symbol.GetAttributes()
                .Any(e => e.AttributeClass != null && e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString));

            // ---------- container (former SetupContainerIfNeeded) ----------

            var contentPropertyName = GetContentPropertyNameFor(symbol);
            var isNewPropertyContainer = IsNewPropertyContainer(symbol);
            var isAlreadyContainerOfThis = Shared.IsGenericIList(symbol, out var containerOfType);

            string containerOfTypeName = null;
            var isSingleItemContainer = false;

            if (contentPropertyName != null && isAlreadyContainerOfThis)
                return Error(ContentPropertyOnIList, symbol, symbol.ToDisplayString());

            if (isAlreadyContainerOfThis)
            {
                containerOfTypeName = containerOfType.ToDisplayString();
                contentPropertyName = "this";
                isSingleItemContainer = false;
            }
            else
            {
                if (!isNewPropertyContainer && symbol.ContainingNamespace.ToDisplayString().Equals("Sharp.UI"))
                    contentPropertyName = FindContentPropertyName(symbol);

                if (!string.IsNullOrEmpty(contentPropertyName))
                {
                    var contentPropertySymbol = FindPropertySymbolWithName(symbol, contentPropertyName);
                    if (contentPropertySymbol == null)
                        return Error(MissingContentProperty, symbol, symbol.ToDisplayString(), contentPropertyName);

                    var contentPropertyType = contentPropertySymbol.Type as INamedTypeSymbol;

                    if (Shared.IsGenericIList(contentPropertyType, out var ofType))
                    {
                        containerOfTypeName = ofType.ToDisplayString();
                        isSingleItemContainer = false;
                    }
                    else
                    {
                        containerOfTypeName = contentPropertyType.ToDisplayString();
                        isSingleItemContainer = true;
                    }
                }
            }

            ct.ThrowIfCancellationRequested();

            // ---------- constructors ----------

            var publicCtors = symbol.Constructors
                .Where(e => e.DeclaredAccessibility == Accessibility.Public)
                .ToList();

            var hasImplicitParameterlessCtor = publicCtors.Any(e => e.Parameters.Length == 0 && e.IsImplicitlyDeclared);
            var hasExplicitParameterlessCtor = publicCtors.Any(e => e.Parameters.Length == 0 && !e.IsImplicitlyDeclared);
            var hasAnyExplicitPublicCtor = publicCtors.Any(e => !e.IsImplicitlyDeclared);

            var baseHasParameterlessCtor = symbol.BaseType != null && symbol.BaseType.Constructors
                .Any(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Length == 0);

            var constructors = publicCtors
                .Where(e => e.Parameters.Length > 0 && !e.IsImplicitlyDeclared)
                .Select(e => new ConstructorModel(new EquatableArray<ParameterModel>(
                    e.Parameters
                        .Select(p => new ParameterModel(p.Type.ToDisplayString(), Shared.CamelCase(p.Name)))
                        .ToArray())))
                .ToArray();

            ct.ThrowIfCancellationRequested();

            // ---------- bindable properties ----------

            var diagnostics = new List<DiagnosticInfo>();
            var bindableProperties = BuildBindableProperties(symbol, diagnostics, ct);

            // ---------- model ----------

            var model = new ClassModel(
                Namespace: symbol.ContainingNamespace.ToDisplayString(),
                ClassName: symbol.Name,
                FullSymbolName: symbol.ToDisplayString().Split('.').Last(),
                FullyQualifiedName: symbol.ToDisplayString(),
                FileName: Shared.GetNormalizedFileName(symbol),
                IsSealed: symbol.IsSealed,
                IsSharpObject: isSharpObject,
                IsShell: isShell,
                IsTopContentSymbol: isTopContentSymbol,
                ContentPropertyName: contentPropertyName,
                ContainerOfTypeName: containerOfTypeName,
                IsSingleItemContainer: isSingleItemContainer,
                IsNewPropertyContainer: isNewPropertyContainer,
                IsAlreadyContainerOfThis: isAlreadyContainerOfThis,
                HasImplicitParameterlessCtor: hasImplicitParameterlessCtor,
                HasExplicitParameterlessCtor: hasExplicitParameterlessCtor,
                HasAnyExplicitPublicCtor: hasAnyExplicitPublicCtor,
                BaseHasParameterlessCtor: baseHasParameterlessCtor,
                Constructors: new EquatableArray<ConstructorModel>(constructors),
                BindableProperties: bindableProperties);

            return new ClassModelResult(model, new EquatableArray<DiagnosticInfo>(diagnostics.ToArray()));
        }

        // -----------------------------------------------------------------
        // bindable properties
        // -----------------------------------------------------------------

        static EquatableArray<BindablePropertyModel> BuildBindableProperties(
            INamedTypeSymbol symbol, List<DiagnosticInfo> diagnostics, CancellationToken ct)
        {
            if (!Shared.IsBindableObject(symbol))
                return EquatableArray<BindablePropertyModel>.Empty;

            var bindableInterfaces = symbol.Interfaces
                .Where(e => e.GetAttributes().Any(a => a.AttributeClass != null &&
                    a.AttributeClass.Name.Equals(Shared.BindablePropertiesAttributeString, StringComparison.Ordinal)));

            var result = new List<BindablePropertyModel>();

            foreach (var inter in bindableInterfaces)
            {
                ct.ThrowIfCancellationRequested();

                var properties = inter.GetMembers()
                    .Where(e => e.Kind == SymbolKind.Property)
                    .Cast<IPropertySymbol>();

                foreach (var prop in properties)
                {
                    var typeName = prop.Type.ToDisplayString();
                    var callbacks = GetPropertyCallbacks(prop, diagnostics);
                    var defaultValueString = GetDefaultValueString(prop, typeName);
                    var isNew = FindInBasePropertySymbolWithName(symbol, prop.Name) != null;

                    result.Add(new BindablePropertyModel(
                        Name: prop.Name,
                        TypeName: typeName,
                        IsNew: isNew,
                        DefaultValueString: defaultValueString,
                        Callbacks: new EquatableArray<CallbackModel>(callbacks)));
                }
            }

            return new EquatableArray<BindablePropertyModel>(result.ToArray());
        }

        static CallbackModel[] GetPropertyCallbacks(ISymbol symbol, List<DiagnosticInfo> diagnostics)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass != null &&
                e.AttributeClass.Name.Equals(PropertyCallbackAttributeString, StringComparison.Ordinal));

            if (attributeData == null)
                return new CallbackModel[0];

            var arguments = attributeData.ConstructorArguments;
            var names = new[] { "propertyChanged", "propertyChanging", "validateValue", "coerceValue", "defaultValueCreator" };

            var list = new List<CallbackModel>();
            for (int i = 0; i < names.Length && i < arguments.Length; i++)
                if (arguments[i].Value != null)
                    list.Add(new CallbackModel(names[i], (string)arguments[i].Value));

            if (list.Count == 0)
                diagnostics.Add(new DiagnosticInfo(
                    EmptyPropertyCallbacks,
                    LocationInfo.CreateFrom(symbol),
                    new EquatableArray<string>(new[] { symbol.ToDisplayString() })));

            return list.ToArray();
        }

        static string GetDefaultValueString(ISymbol symbol, string typeName)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass != null &&
                e.AttributeClass.Name.Equals(DefaultValueAttributeString, StringComparison.Ordinal));

            if (attributeData == null || attributeData.ConstructorArguments.Length == 0)
                return null;

            var raw = attributeData.ConstructorArguments[0].Value;
            if (raw == null) return null;

            var value = raw.ToString();

            if (typeName.Equals("string", StringComparison.Ordinal))
                value = $"\"{value}\"";

            if (typeName.Equals("double", StringComparison.Ordinal) || typeName.Equals("float", StringComparison.Ordinal))
                value = value.Replace(",", ".");

            return value;
        }

        // -----------------------------------------------------------------
        // content property helpers (moved over 1:1 from ClassGenerator)
        // -----------------------------------------------------------------

        static string GetContentPropertyNameFor(INamedTypeSymbol symbol)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass != null &&
                e.AttributeClass.Name.Equals(Shared.ContentPropertyAttributeString));

            return attributeData != null && attributeData.ConstructorArguments.Length > 0
                ? (string)attributeData.ConstructorArguments[0].Value
                : null;
        }

        static bool IsNewPropertyContainer(INamedTypeSymbol symbol)
        {
            if (!symbol.GetAttributes().Any(e => e.AttributeClass != null &&
                e.AttributeClass.Name.Equals(Shared.ContentPropertyAttributeString)))
                return false;

            var isNewContainer = false;
            Shared.LoopDownToObject(symbol.BaseType, type =>
            {
                isNewContainer = type.GetAttributes().Any(e => e.AttributeClass != null &&
                    e.AttributeClass.Name.Equals(Shared.ContentPropertyAttributeString));
                return isNewContainer;
            });

            return isNewContainer;
        }

        static string FindContentPropertyName(INamedTypeSymbol symbol)
        {
            string name = null;
            Shared.LoopDownToObject(symbol, type =>
            {
                name = GetContentPropertyNameFor(type);
                return name != null;
            });
            return name;
        }

        static IPropertySymbol FindPropertySymbolWithName(INamedTypeSymbol symbol, string propertyName)
        {
            var propertySymbol = GetPropertyFromInterface(symbol, propertyName);

            if (propertySymbol == null)
            {
                Shared.LoopDownToObject(symbol, type =>
                {
                    propertySymbol = type.GetMembers(propertyName).OfType<IPropertySymbol>().FirstOrDefault();
                    return propertySymbol != null;
                });
            }

            return propertySymbol;
        }

        static IPropertySymbol GetPropertyFromInterface(INamedTypeSymbol symbol, string name)
        {
            if (!Shared.IsBindableObject(symbol))
                return null;

            var bindableInterfaces = symbol.Interfaces
                .Where(e => e.GetAttributes().Any(a => a.AttributeClass != null &&
                    a.AttributeClass.Name.Equals(Shared.BindablePropertiesAttributeString, StringComparison.Ordinal)));

            foreach (var inter in bindableInterfaces)
                foreach (var prop in inter.GetMembers().Where(e => e.Kind == SymbolKind.Property))
                    if (prop.Name.Equals(name, StringComparison.Ordinal))
                        return (IPropertySymbol)prop;

            return null;
        }

        static IPropertySymbol FindInBasePropertySymbolWithName(INamedTypeSymbol symbol, string propertyName)
        {
            IPropertySymbol propertySymbol = null;
            Shared.LoopDownToObject(symbol.BaseType, type =>
            {
                propertySymbol = type.GetMembers(propertyName).OfType<IPropertySymbol>().FirstOrDefault();
                return propertySymbol != null;
            });
            return propertySymbol;
        }

        // -----------------------------------------------------------------

        static ClassModelResult Error(DiagnosticDescriptor descriptor, ISymbol symbol, params string[] args)
            => new ClassModelResult(
                null,
                new EquatableArray<DiagnosticInfo>(new[]
                {
                    new DiagnosticInfo(descriptor, LocationInfo.CreateFrom(symbol), new EquatableArray<string>(args))
                }));
    }
}
