using System; 
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace WinRT.ExampleAppGenericHelpers
{

    internal static class GlobalVtableLookup
    {

        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void InitializeGlobalVtableLookup()
        {
            ComWrappersSupport.RegisterTypeComInterfaceEntriesLookup(new Func<Type, ComWrappers.ComInterfaceEntry[]>(LookupVtableEntries));
            ComWrappersSupport.RegisterTypeRuntimeClassNameLookup(new Func<Type, string>(LookupRuntimeClassName));
        }

        private static ComWrappers.ComInterfaceEntry[] LookupVtableEntries(Type type)
        {
            string typeName = type.ToString();
            if (typeName == "Microsoft.Maui.Controls.Command`1[System.String]"
            || typeName == "Microsoft.Maui.Controls.Command"
            )
            {
                
        return new global::System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry[]
        {
            new global::System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry
            {
                IID = global::ABI.System.Windows.Input.ICommandMethods.IID,
                Vtable = global::ABI.System.Windows.Input.ICommandMethods.AbiToProjectionVftablePtr
            },
};

            }
            return default;
        }
private static string LookupRuntimeClassName(Type type)
{
    string typeName = type.ToString();
if (typeName == "Microsoft.Maui.Controls.Command`1[System.String]"
|| typeName == "Microsoft.Maui.Controls.Command"
)
{
    return "Microsoft.UI.Xaml.Input.ICommand";
}
            return default;
        }
    }
}
