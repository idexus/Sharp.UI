//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Extensions
{
    public partial class ExtensionGenerator
    {
        // ----- event fluent methods -----    

        void GenerateEventMethod(ISymbol @event)
        {
            var eventSymbol = (IEventSymbol)@event;
            var eventHandler = eventSymbol.AddMethod.Parameters.First();
            var eventHandlerType = ((INamedTypeSymbol)eventHandler.Type);

            var existInBases = false;
            Helpers.LoopDownToObject(mainSymbol.BaseType, type =>
            {
                existInBases = (type
                    .GetMembers()
                    .FirstOrDefault(e =>
                        e.Kind == SymbolKind.Event &&
                        e.DeclaredAccessibility == Accessibility.Public &&
                        e.Name.Equals(eventSymbol.Name, StringComparison.Ordinal)) != null);

                return existInBases;
            });

            if (!existInBases && !Helpers.NotGenerateList.Contains(eventSymbol.Name))
            {
                if (mainSymbol.IsSealed)
                {
                    GenerateEventMethodHandler_Sealed(eventSymbol, eventHandlerType);
                    GenerateEventMethodNoArgs_Sealed(eventSymbol);
                }
                else
                {
                    GenerateEventMethodHandler_Normal(eventSymbol, eventHandlerType);
                    GenerateEventMethodNoArgs_Normal(eventSymbol);
                }
            }
        }

        void GenerateEventMethodHandler_Sealed(IEventSymbol eventSymbol, INamedTypeSymbol namedType)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {mainSymbol.ToDisplayString()} On{eventSymbol.Name}(this {mainSymbol.ToDisplayString()} self, {namedType.ToDisplayString()} handler)
        {{
            self.{eventSymbol.Name} += handler;
            return self;
        }}
        ");
        }

        void GenerateEventMethodHandler_Normal(IEventSymbol eventSymbol, INamedTypeSymbol namedType)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T self, {namedType.ToDisplayString()} handler)
            where T : {mainSymbol.ToDisplayString()}
        {{
            self.{eventSymbol.Name} += handler;
            return self;
        }}
        ");
        }

        void GenerateEventMethodNoArgs_Sealed(IEventSymbol eventSymbol)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static {mainSymbol.ToDisplayString()} On{eventSymbol.Name}(this {mainSymbol.ToDisplayString()} self, System.Action<{mainSymbol.ToDisplayString()}> action)
        {{
            self.{eventSymbol.Name} += (o, arg) => action(self);
            return self;
        }}
        ");
        }

        void GenerateEventMethodNoArgs_Normal(IEventSymbol eventSymbol)
        {
            isExtensionMethodsGenerated = true;
            builder.Append($@"
        public static T On{eventSymbol.Name}<T>(this T self, System.Action<T> action)
            where T : {mainSymbol.ToDisplayString()}
        {{
            self.{eventSymbol.Name} += (o, arg) => action(self);
            return self;
        }}
        ");
        }
    }
}