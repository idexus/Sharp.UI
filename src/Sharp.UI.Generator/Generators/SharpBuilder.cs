using System;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace Sharp.UI.Generator
{
	public class SharpBuilder
	{
        GeneratorExecutionContext context;

        public SharpBuilder(GeneratorExecutionContext context)
        {
            this.context = context;
        }

        public void Generate()
        {
            // sharp symbols

            var sharpSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            var topSymbols = sharpSymbols.Select(e => e.BaseType).ToList();

            // maui symbols

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

                topSymbols.AddRange(mauiSymbols);

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

            foreach (var symbol in sharpSymbols)
            {
                new ClassGenerator(context, symbol).Build();
                new ExtensionGenerator(context, symbol).Build();
            }
        }
    }
}

