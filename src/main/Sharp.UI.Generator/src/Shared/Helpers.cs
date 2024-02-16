//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharp.UI.Generator
{
    public static class Helpers
    {
        static readonly string[] keywords = { "class", "switch", "event" };

        public static void WaitForDebugger(CancellationToken cancellationToken)
        {
#if DEBUG
            while (!Debugger.IsAttached && !cancellationToken.IsCancellationRequested)
                Task.Delay(10).Wait(cancellationToken);
#endif
        }

        public static string CamelCase(string str)
        {
            var camelCaseName = $"{str.Substring(0, 1).ToLower()}{str.Substring(1)}";
            if (keywords.Contains(camelCaseName)) camelCaseName = $"@{camelCaseName}";
            return camelCaseName;
        }

        public static void LoopDownToObject(INamedTypeSymbol symbol, Func<INamedTypeSymbol, bool> func)
        {
            var type = symbol;
            var endLoop = false;
            while (!endLoop && type != null && !type.Name.Equals("Object", StringComparison.Ordinal))
            {
                endLoop = func(type);
                type = type.BaseType;
            }
        }

        public static bool IsGenericIList(ISymbol symbol, out ITypeSymbol elementType)
        {
            elementType = null;
            var namedTypeSymbol = symbol as INamedTypeSymbol;
            if (namedTypeSymbol == null) return false;

            if (namedTypeSymbol.Name.Equals("IList", StringComparison.Ordinal) && namedTypeSymbol.IsGenericType)
            {
                elementType = namedTypeSymbol.TypeArguments.First();
                return true;
            }

            ITypeSymbol _elementType = null;
            LoopDownToObject(namedTypeSymbol, type =>
            {
                foreach (var inter in type.AllInterfaces)
                    if (inter.Name.Equals("IList", StringComparison.Ordinal) && inter.IsGenericType)
                    {

                        _elementType = inter.TypeArguments.First();
                        return true;
                    }
                return false;
            });

            elementType = _elementType;
            return _elementType != null;
        }

        public static bool IsIEnumerable(INamedTypeSymbol symbol)
        {
            //bool isIEnumerable = false;
            //LoopDownToObject(symbol, type =>
            //{
                foreach (var inter in symbol.AllInterfaces)
                    if (inter.Name.Equals("IEnumerable", StringComparison.Ordinal) && !inter.IsGenericType)
                    {
                        //isIEnumerable = true;
                        return true;
                    }
                return false;
            //});
            //return isIEnumerable;
        }

        public static bool IsVisualElement(INamedTypeSymbol symbol)
        {
            var isNavigableElement = false;

            LoopDownToObject(symbol, type =>
            {
                if (type.ToDisplayString().Equals("Microsoft.Maui.Controls.VisualElement")) isNavigableElement = true;
                return isNavigableElement;
            });

            return isNavigableElement;
        }

        public static bool IsBaseImplementationOfInterface(INamedTypeSymbol symbol, string name)
        {
            var count = 0;
            LoopDownToObject(symbol, type =>
            {
                if (type.Interfaces.Any(e => e.Name.Equals(name))) count++;
                return false;
            });

            return count == 1;
        }

        public static string GetNormalizedFileName(INamedTypeSymbol type)
        {
            var tail = type.IsGenericType ? $".{type.TypeArguments.FirstOrDefault().Name}" : "";
            return $"{type.Name}{tail}";
        }

        public static string GetNormalizedClassName(INamedTypeSymbol type)
        {
            var tail = type.IsGenericType ? $"Of{type.TypeArguments.FirstOrDefault().Name}" : "";
            var prefix = type.ToDisplayString().Contains(".Shapes.") ? "Shapes" : "";
            prefix += type.ToDisplayString().Contains(".Compatibility.") ? "Compatibility" : "";
            return $"{prefix}{type.Name}{tail}";
        }

        public static bool IsBindableObject(INamedTypeSymbol symbol)
        {
            var isBindable = false;

            LoopDownToObject(symbol, type =>
            {
                if (type.ToDisplayString().Equals("Microsoft.Maui.Controls.BindableObject", StringComparison.Ordinal)) isBindable = true;
                return isBindable;
            });

            return isBindable;
        }

        public static bool IsSymbolDeprecated(ISymbol symbol)
        {
            foreach (var attribute in symbol.GetAttributes())
            {
                if (attribute.AttributeClass.Name == "ObsoleteAttribute" || attribute.AttributeClass.Name == "Obsolete")
                    return true;
            }
            return false;
        }
    }
}

