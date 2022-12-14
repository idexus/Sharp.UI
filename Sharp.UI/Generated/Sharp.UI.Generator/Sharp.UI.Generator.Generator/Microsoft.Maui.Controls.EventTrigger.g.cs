//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class EventTriggerGeneratedExtension
    {
        public static T Actions<T>(this T obj,
            System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction> actions)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.EventTrigger>(obj);
            foreach (var item in actions)
            {
                var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.TriggerAction>(item);
                mauiObject.Actions.Add(mauiItem);
            }
            return obj;
        }

        public static T Actions<T>(this T obj,
            params Microsoft.Maui.Controls.TriggerAction[] actions)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.EventTrigger>(obj);
            foreach (var item in actions)
            {
                var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.TriggerAction>(item);
                mauiObject.Actions.Add(mauiItem);
            }
            return obj;
        }

        public static T Actions<T>(this T obj,
            System.Func<LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction>>, LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction>>> buildValue)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.EventTrigger>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerAction>>());
            if (builder.ValueIsSet())
            {
                var items = builder.GetValue();
                foreach (var item in items) 
                {
                    var mauiItem = MauiWrapper.Value<Microsoft.Maui.Controls.TriggerAction>(item);
                    mauiObject.Actions.Add(mauiItem);
                }
            }
            return obj;
        }
        
        public static T Event<T>(this T obj,
            string @event)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.EventTrigger>(obj);
            mauiObject.Event = (string)@event;
            return obj;
        }
        
        public static T Event<T>(this T obj,
            System.Func<ValueBuilder<string>, ValueBuilder<string>> buildValue)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.EventTrigger>(obj);
            var builder = buildValue(new ValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Event = builder.GetValue();
            return obj;
        }
        
        public static T Event<T>(this T obj,
            System.Func<LazyValueBuilder<string>, LazyValueBuilder<string>> buildValue)
            where T : Sharp.UI.IEventTrigger
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.EventTrigger>(obj);
            var builder = buildValue(new LazyValueBuilder<string>());
            if (builder.ValueIsSet()) mauiObject.Event = builder.GetValue();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
