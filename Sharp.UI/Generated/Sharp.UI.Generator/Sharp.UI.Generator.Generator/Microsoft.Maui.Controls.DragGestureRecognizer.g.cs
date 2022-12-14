//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class DragGestureRecognizerGeneratedExtension
    {
        public static T CanDrag<T>(this T obj,
            bool canDrag)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.CanDrag = (bool)canDrag;
            return obj;
        }
        
        public static T CanDrag<T>(this T obj,
            System.Func<ValueBuilder<bool>, ValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.CanDrag = builder.GetValue();
            return obj;
        }
        
        public static T CanDrag<T>(this T obj,
            System.Func<LazyValueBuilder<bool>, LazyValueBuilder<bool>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<bool>());
            if (builder.ValueIsSet()) mauiObject.CanDrag = builder.GetValue();
            return obj;
        }
        
        public static T CanDrag<T>(this T obj,
            System.Func<BindingBuilder<bool>, BindingBuilder<bool>> buildBinding)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<bool>(mauiObject, Microsoft.Maui.Controls.DragGestureRecognizer.CanDragProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T DropCompletedCommand<T>(this T obj,
            System.Windows.Input.ICommand dropCompletedCommand)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DropCompletedCommand = (System.Windows.Input.ICommand)dropCompletedCommand;
            return obj;
        }
        
        public static T DropCompletedCommand<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.DropCompletedCommand = builder.GetValue();
            return obj;
        }
        
        public static T DropCompletedCommand<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.DropCompletedCommand = builder.GetValue();
            return obj;
        }
        
        public static T DropCompletedCommand<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.DragGestureRecognizer.DropCompletedCommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T DropCompletedCommandParameter<T>(this T obj,
            object dropCompletedCommandParameter)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DropCompletedCommandParameter = (object)dropCompletedCommandParameter;
            return obj;
        }
        
        public static T DropCompletedCommandParameter<T>(this T obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) mauiObject.DropCompletedCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T DropCompletedCommandParameter<T>(this T obj,
            System.Func<LazyValueBuilder<object>, LazyValueBuilder<object>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<object>());
            if (builder.ValueIsSet()) mauiObject.DropCompletedCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T DropCompletedCommandParameter<T>(this T obj,
            System.Func<BindingBuilder<object>, BindingBuilder<object>> buildBinding)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<object>(mauiObject, Microsoft.Maui.Controls.DragGestureRecognizer.DropCompletedCommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T DragStartingCommand<T>(this T obj,
            System.Windows.Input.ICommand dragStartingCommand)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DragStartingCommand = (System.Windows.Input.ICommand)dragStartingCommand;
            return obj;
        }
        
        public static T DragStartingCommand<T>(this T obj,
            System.Func<ValueBuilder<System.Windows.Input.ICommand>, ValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.DragStartingCommand = builder.GetValue();
            return obj;
        }
        
        public static T DragStartingCommand<T>(this T obj,
            System.Func<LazyValueBuilder<System.Windows.Input.ICommand>, LazyValueBuilder<System.Windows.Input.ICommand>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<System.Windows.Input.ICommand>());
            if (builder.ValueIsSet()) mauiObject.DragStartingCommand = builder.GetValue();
            return obj;
        }
        
        public static T DragStartingCommand<T>(this T obj,
            System.Func<BindingBuilder<System.Windows.Input.ICommand>, BindingBuilder<System.Windows.Input.ICommand>> buildBinding)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<System.Windows.Input.ICommand>(mauiObject, Microsoft.Maui.Controls.DragGestureRecognizer.DragStartingCommandProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T DragStartingCommandParameter<T>(this T obj,
            object dragStartingCommandParameter)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DragStartingCommandParameter = (object)dragStartingCommandParameter;
            return obj;
        }
        
        public static T DragStartingCommandParameter<T>(this T obj,
            System.Func<ValueBuilder<object>, ValueBuilder<object>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new ValueBuilder<object>());
            if (builder.ValueIsSet()) mauiObject.DragStartingCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T DragStartingCommandParameter<T>(this T obj,
            System.Func<LazyValueBuilder<object>, LazyValueBuilder<object>> buildValue)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildValue(new LazyValueBuilder<object>());
            if (builder.ValueIsSet()) mauiObject.DragStartingCommandParameter = builder.GetValue();
            return obj;
        }
        
        public static T DragStartingCommandParameter<T>(this T obj,
            System.Func<BindingBuilder<object>, BindingBuilder<object>> buildBinding)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            var builder = buildBinding(new BindingBuilder<object>(mauiObject, Microsoft.Maui.Controls.DragGestureRecognizer.DragStartingCommandParameterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T OnDropCompleted<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.DropCompletedEventArgs> handler)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DropCompleted += handler;
            return obj;
        }
        
        public static T OnDropCompleted<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DropCompleted += (o, arg) => action(obj);
            return obj;
        }
        
        public static T OnDragStarting<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.DragStartingEventArgs> handler)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DragStarting += handler;
            return obj;
        }
        
        public static T OnDragStarting<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IDragGestureRecognizer
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.DragGestureRecognizer>(obj);
            mauiObject.DragStarting += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
