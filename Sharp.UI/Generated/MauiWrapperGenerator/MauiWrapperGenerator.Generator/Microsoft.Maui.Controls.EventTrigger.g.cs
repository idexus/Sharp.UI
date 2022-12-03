﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class IEventTriggerGeneratedExtension
    {
        public static T Actions<T>(this T obj,
            System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction> actions)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.EventTrigger>(obj);
            foreach (var item in actions) mauiObject.Actions.Add(item);
            return obj;
        }

        public static T Actions<T>(this T obj,
            params Microsoft.Maui.Controls.TriggerAction[] actions)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.EventTrigger>(obj);
            foreach (var item in actions) mauiObject.Actions.Add(item);
            return obj;
        }

        public static T Actions<T>(this T obj,
            Func<Def<System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction>>, Def<System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction>>> definition)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.EventTrigger>(obj);
            var def = definition(new Def<System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction>>());
            if (def.ValueIsSet())
            {
                var items = def.GetValue();
                foreach (var item in items) mauiObject.Actions.Add(item);
            }
            return obj;
        }
        
        public static T Event<T>(this T obj,
            string? @event)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.EventTrigger>(obj);
            if (@event != null) mauiObject.Event = (string)@event;
            return obj;
        }
        
        public static T Event<T>(this T obj,
            string? @event,
            Func<ValueDef<string>, ValueDef<string>> definition)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.EventTrigger>(obj);
            if (@event != null) mauiObject.Event = (string)@event;
            var def = definition(new ValueDef<string>());
            if (def.ValueIsSet()) mauiObject.Event = def.GetValue();
            return obj;
        }
        
        public static T Event<T>(this T obj,
            Func<ValueDef<string>, ValueDef<string>> definition)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.EventTrigger>(obj);
            var def = definition(new ValueDef<string>());
            if (def.ValueIsSet()) mauiObject.Event = def.GetValue();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
