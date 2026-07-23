using System;
using System.Collections.Generic;
using System.Text;

namespace Sharp.UI
{
    public static partial class EntryExtension
    {
        public static Entry SetFocus(this Entry entry)
        {
            if (entry.IsLoaded)
            {
                entry.Focus();
                entry.CursorPosition = 0;
                entry.SelectionLength = 100;
            }
            else
            {
                entry.Loaded += (o, arg) => {
                    entry?.Focus();
                    entry?.CursorPosition = 0;
                    entry?.SelectionLength = 100;
                };
            }

            return entry;
        }
    }
}
