//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharp.UI.Generator.Classes
{
    [Generator]
    public class Builder : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            // Helpers.WaitForDebugger(context.CancellationToken);

            var sharpObjectSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);            

            foreach (var symbol in sharpObjectSymbols)
            {
                new ClassGenerator(context, symbol).Build();
            }
        }
    }
}