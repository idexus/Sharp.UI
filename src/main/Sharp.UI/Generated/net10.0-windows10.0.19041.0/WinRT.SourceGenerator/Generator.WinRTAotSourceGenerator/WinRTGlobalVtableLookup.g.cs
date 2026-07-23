using System; 
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace WinRT.Sharp_UIGenericHelpers
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
            if (typeName == "System.Collections.ObjectModel.ReadOnlyCollection`1[Microsoft.Maui.IView]"
            || typeName == "System.Collections.ObjectModel.ReadOnlyCollection`1[Microsoft.Maui.IMenuElement]"
            )
            {
                
        return new global::System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry[]
        {
            new global::System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry
            {
                IID = global::ABI.System.Collections.IListMethods.IID,
                Vtable = global::ABI.System.Collections.IListMethods.AbiToProjectionVftablePtr
            },
            new global::System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry
            {
                IID = global::ABI.System.Collections.IEnumerableMethods.IID,
                Vtable = global::ABI.System.Collections.IEnumerableMethods.AbiToProjectionVftablePtr
            },
};

            }
            return default;
        }
private static string LookupRuntimeClassName(Type type)
{
    string typeName = type.ToString();
if (typeName == "System.Collections.ObjectModel.ReadOnlyCollection`1[Microsoft.Maui.IView]"
|| typeName == "System.Collections.ObjectModel.ReadOnlyCollection`1[Microsoft.Maui.IMenuElement]"
)
{
    return "Microsoft.UI.Xaml.Interop.IBindableVector";
}
            return default;
        }
    }
}
