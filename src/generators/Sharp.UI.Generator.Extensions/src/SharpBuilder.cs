//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Extensions
{
    [Generator]
    public class SharpBuilder : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            // Helpers.WaitForDebugger(context.CancellationToken);

            // .Net MAUI symbols

            var mauiSymbolsType = context.Compilation.GetSymbolsWithName(s => true, filter: SymbolFilter.Type)
                .Where(e => e.ToDisplayString().Equals("Sharp.UI.Internal.MauiSymbols"))
                .ToList()
                .FirstOrDefault() as INamedTypeSymbol;

            if (mauiSymbolsType != null)
            {
                var mauiSymbols = mauiSymbolsType
                    .GetMembers()
                    .Where(e => e.Kind == SymbolKind.Field)
                    .Select(e => (e as IFieldSymbol).Type as INamedTypeSymbol)
                    .ToList();

                var baseSymbols = new List<INamedTypeSymbol>();
                foreach (var symbol in mauiSymbols)
                    Helpers.LoopDownToObject(symbol.BaseType, type =>
                    {
                        if (!baseSymbols.Contains(type) && !mauiSymbols.Contains(type)) baseSymbols.Add(type);
                        return false;
                    });

                var allSymbols = mauiSymbols.ToList();
                allSymbols.AddRange(baseSymbols);

                foreach (var symbol in allSymbols)
                {
                    new ExtensionGenerator(context, symbol).Build();
                }
            }

            // [SharpObject] symbols

            var sharpSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            foreach (var symbol in sharpSymbols)
            {
                new ExtensionGenerator(context, symbol).Build();
            }
        }
    }
}