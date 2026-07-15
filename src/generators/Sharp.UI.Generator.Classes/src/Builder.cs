//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Collections.Immutable;
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
            //Helpers.WaitForDebugger(context.CancellationToken);

            var objectSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Select(e => e as INamedTypeSymbol)
                .Where(e => !e.IsStatic &&
                    (e.GetAttributes().Any(e => e.AttributeClass.Name.Equals(Shared.SharpObjectAttributeString)) || (e.IsSealed && Helpers.IsContentPage(e))));

            foreach (var symbol in objectSymbols)
            {
                new ClassGenerator(context, symbol).Build();
            }
        }
    }
}