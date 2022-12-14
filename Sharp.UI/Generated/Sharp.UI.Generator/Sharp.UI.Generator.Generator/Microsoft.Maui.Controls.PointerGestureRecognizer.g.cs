//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class PointerGestureRecognizerGeneratedExtension
    {
        public static T PointerEnteredCommand<T>(this T obj,
            System.Windows.Input.ICommand pointerEnteredCommand)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerEnteredCommand = (System.Windows.Input.ICommand)pointerEnteredCommand;
            return obj;
        }
        
        public static T PointerEnteredCommand<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerEnteredCommand = builder.GetValue();
            return obj;
        }
        
        public static T PointerEnteredCommand<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerEnteredCommand = builder.GetValue();
            return obj;
        }
        
        public static T PointerEnteredCommand<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.PointerGestureRecognizer.PointerEnteredCommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T PointerEnteredCommandParameter<T>(this T obj,
            System.Windows.Input.ICommand pointerEnteredCommandParameter)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerEnteredCommandParameter = (System.Windows.Input.ICommand)pointerEnteredCommandParameter;
            return obj;
        }
        
        public static T PointerEnteredCommandParameter<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerEnteredCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T PointerEnteredCommandParameter<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerEnteredCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T PointerEnteredCommandParameter<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.PointerGestureRecognizer.PointerEnteredCommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T PointerExitedCommand<T>(this T obj,
            System.Windows.Input.ICommand pointerExitedCommand)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerExitedCommand = (System.Windows.Input.ICommand)pointerExitedCommand;
            return obj;
        }
        
        public static T PointerExitedCommand<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerExitedCommand = builder.GetValue();
            return obj;
        }
        
        public static T PointerExitedCommand<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerExitedCommand = builder.GetValue();
            return obj;
        }
        
        public static T PointerExitedCommand<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.PointerGestureRecognizer.PointerExitedCommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T PointerExitedCommandParameter<T>(this T obj,
            System.Windows.Input.ICommand pointerExitedCommandParameter)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerExitedCommandParameter = (System.Windows.Input.ICommand)pointerExitedCommandParameter;
            return obj;
        }
        
        public static T PointerExitedCommandParameter<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerExitedCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T PointerExitedCommandParameter<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerExitedCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T PointerExitedCommandParameter<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.PointerGestureRecognizer.PointerExitedCommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T PointerMovedCommand<T>(this T obj,
            System.Windows.Input.ICommand pointerMovedCommand)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerMovedCommand = (System.Windows.Input.ICommand)pointerMovedCommand;
            return obj;
        }
        
        public static T PointerMovedCommand<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerMovedCommand = builder.GetValue();
            return obj;
        }
        
        public static T PointerMovedCommand<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerMovedCommand = builder.GetValue();
            return obj;
        }
        
        public static T PointerMovedCommand<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.PointerGestureRecognizer.PointerMovedCommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T PointerMovedCommandParameter<T>(this T obj,
            System.Windows.Input.ICommand pointerMovedCommandParameter)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerMovedCommandParameter = (System.Windows.Input.ICommand)pointerMovedCommandParameter;
            return obj;
        }
        
        public static T PointerMovedCommandParameter<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerMovedCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T PointerMovedCommandParameter<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.PointerMovedCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T PointerMovedCommandParameter<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.PointerGestureRecognizer.PointerMovedCommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T OnPointerEntered<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.PointerEventArgs>? handler)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerEntered += handler;
            return obj;
        }
        
        public static T OnPointerEntered<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerEntered += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnPointerExited<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.PointerEventArgs>? handler)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerExited += handler;
            return obj;
        }
        
        public static T OnPointerExited<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerExited += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnPointerMoved<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.PointerEventArgs>? handler)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerMoved += handler;
            return obj;
        }
        
        public static T OnPointerMoved<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IPointerGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.PointerGestureRecognizer>(obj);
            mauiObject.PointerMoved += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
