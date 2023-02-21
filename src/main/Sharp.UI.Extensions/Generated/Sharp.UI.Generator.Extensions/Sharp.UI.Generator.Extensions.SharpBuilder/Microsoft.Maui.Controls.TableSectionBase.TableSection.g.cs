﻿//
// <auto-generated> Sharp.UI.Generator.Extensions.SharpBuilder
//

#nullable enable
#pragma warning disable CS8601


namespace Sharp.UI
{
    using Sharp.UI;

    using Sharp.UI.Internal;

    public static partial class TableSectionBaseOfTableSectionExtension
    {
        public static T OnCollectionChanged<T>(this T obj, System.Collections.Specialized.NotifyCollectionChangedEventHandler handler)
            where T : Microsoft.Maui.Controls.TableSectionBase<Microsoft.Maui.Controls.TableSection>
        {
            obj.CollectionChanged += handler;
            return obj;
        }
        
        public static T OnCollectionChanged<T>(this T obj, System.Action<T> action)
            where T : Microsoft.Maui.Controls.TableSectionBase<Microsoft.Maui.Controls.TableSection>
        {
            obj.CollectionChanged += (o, arg) => action(obj);
            return obj;
        }
        
    }
}

#pragma warning restore CS8601
#nullable restore