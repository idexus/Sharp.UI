using System;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Sharp.UI.Generator
{
	public static class Helpers
	{
        public static void WaitForDebugger(CancellationToken cancellationToken)
        {
#if DEBUG
            while (!Debugger.IsAttached && !cancellationToken.IsCancellationRequested) Task.Delay(1000).Wait(cancellationToken);
#endif
        }

        public static string CamelCase(string str)
        {
            var camelCaseName = $"{str.Substring(0, 1).ToLower()}{str.Substring(1)}";
            camelCaseName = camelCaseName.Equals("class") ? "@class" : camelCaseName;
            camelCaseName = camelCaseName.Equals("switch") ? "@switch" : camelCaseName;
            camelCaseName = camelCaseName.Equals("event") ? "@event" : camelCaseName;
            return camelCaseName;
        }

        public static string GetTypeName(INamedTypeSymbol type)
        {
            var tail = type.IsGenericType ? $"{type.TypeArguments.FirstOrDefault().Name}" : "";
            var prefix = type.ContainingNamespace.ToDisplayString().Contains("Compatibility") ? "Compatibility" : "";
            return $"{prefix}{type.Name}{tail}";
        }

        public static string GetInterfaceName(INamedTypeSymbol type)
        {
            return $"I{GetTypeName(type)}";
        }

        public static bool IsGenericIList(INamedTypeSymbol symbol, out string typeName)
        {
            if (symbol.Name.Equals("IList") && symbol.IsGenericType)
            {
                typeName = symbol.TypeArguments.First().ToDisplayString();
                return true;
            }

            var type = symbol;
            do
            {
                foreach (var inter in type.Interfaces)
                    if (inter.Name.Equals("IList") && inter.IsGenericType)
                    {
                        typeName = inter.TypeArguments.First().ToDisplayString();
                        return true;
                    }

                type = type.BaseType;
            }
            while (type != null && !type.Name.Equals("Object"));

            typeName = null;
            return false;
        }

        public static void LoopDownToObject(INamedTypeSymbol symbol, Func<INamedTypeSymbol, bool> func)
        {
            var type = symbol;
            var endLoop = false;
            while (!endLoop && !type.Name.Equals("Object"))
            {
                endLoop = func(type);
                type = type.BaseType;
            }
        }
    }
}

