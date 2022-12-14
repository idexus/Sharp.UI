//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class StateTriggerBaseGeneratedExtension
    {
        public static T OnIsActiveChanged<T>(this T obj, System.EventHandler handler)
            where T : Sharp.UI.IStateTriggerBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.StateTriggerBase>(obj);
            mauiObject.IsActiveChanged += handler;
            return obj;
        }
        
        public static T OnIsActiveChanged<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IStateTriggerBase
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.StateTriggerBase>(obj);
            mauiObject.IsActiveChanged += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
