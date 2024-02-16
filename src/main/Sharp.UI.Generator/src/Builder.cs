//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Sharp.UI.Generator.Classes;
using Sharp.UI.Generator.Extensions;

namespace Sharp.UI.Generator
{
    [Generator]
    public class Builder : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            // before debugging: pkill -f VBCSCompiler.dll

            //Helpers.WaitForDebugger(context.CancellationToken);

            BuildClasses(context);
            BuildExtensions(context);
        }


        void BuildClasses(GeneratorExecutionContext context)
        {
            var sharpObjectSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(SharpAttributes.SharpObjectAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            foreach (var symbol in sharpObjectSymbols)
            {
                new ClassGenerator(context, symbol).Build();
            }
        }

        void BuildExtensions(GeneratorExecutionContext context)
        {
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

            var SharpObjectSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => !e.ContainingNamespace.ToDisplayString().Equals("Sharp.UI") && !e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(SharpAttributes.SharpObjectAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            foreach (var symbol in SharpObjectSymbols)
            {
                new ExtensionGenerator(context, symbol).Build();
            }


            // [AttachedInterfaces] symbols

            var staticWithAttachedSymbols = context.Compilation.GetSymbolsWithName((s) => true, filter: SymbolFilter.Type)
                .Where(e => e.IsStatic && e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(SharpAttributes.AttachedInterfacesAttributeString)) != null)
                .Select(e => e as INamedTypeSymbol);

            foreach (var symbol in staticWithAttachedSymbols)
            {
                new ExtensionGenerator(context, symbol).Build();
            }
        }
        
    }
}
