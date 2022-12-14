//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public static class StepperGeneratedExtension
    {
        public static T Increment<T>(this T obj,
            double increment)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            mauiObject.Increment = (double)increment;
            return obj;
        }
        
        public static T Increment<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Increment = builder.GetValue();
            return obj;
        }
        
        public static T Increment<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Increment = builder.GetValue();
            return obj;
        }
        
        public static T Increment<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.Stepper.IncrementProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Maximum<T>(this T obj,
            double maximum)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            mauiObject.Maximum = (double)maximum;
            return obj;
        }
        
        public static T Maximum<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Maximum = builder.GetValue();
            return obj;
        }
        
        public static T Maximum<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Maximum = builder.GetValue();
            return obj;
        }
        
        public static T Maximum<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.Stepper.MaximumProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Minimum<T>(this T obj,
            double minimum)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            mauiObject.Minimum = (double)minimum;
            return obj;
        }
        
        public static T Minimum<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Minimum = builder.GetValue();
            return obj;
        }
        
        public static T Minimum<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Minimum = builder.GetValue();
            return obj;
        }
        
        public static T Minimum<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.Stepper.MinimumProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Value<T>(this T obj,
            double value)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            mauiObject.Value = (double)value;
            return obj;
        }
        
        public static T Value<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Value = builder.GetValue();
            return obj;
        }
        
        public static T Value<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.Value = builder.GetValue();
            return obj;
        }
        
        public static T Value<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, Microsoft.Maui.Controls.Stepper.ValueProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T OnValueChanged<T>(this T obj, System.EventHandler<Microsoft.Maui.Controls.ValueChangedEventArgs> handler)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            mauiObject.ValueChanged += handler;
            return obj;
        }
        
        public static T OnValueChanged<T>(this T obj, OnEventAction<T> action)
            where T : Sharp.UI.IStepper
        {
            var mauiObject = MauiWrapper.Value<Microsoft.Maui.Controls.Stepper>(obj);
            mauiObject.ValueChanged += (o, arg) => action(obj);
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
