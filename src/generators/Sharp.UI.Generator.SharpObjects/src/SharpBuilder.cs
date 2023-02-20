//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.SharpObjects
{
    [Generator]
    public class SharpBuilder : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            // Helpers.WaitForDebugger(context.CancellationToken);

            var sharpSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);            

            foreach (var symbol in sharpSymbols)
            {
                new ClassGenerator(context, symbol).Build();
            }
        }
    }
}