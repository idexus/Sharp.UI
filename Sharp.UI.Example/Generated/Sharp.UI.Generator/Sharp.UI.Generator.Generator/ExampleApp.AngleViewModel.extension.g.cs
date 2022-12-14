//
// <auto-generated>
//

#pragma warning disable CS8669


namespace ExampleApp
{
    using Sharp.UI;

    public static class AngleViewModelGeneratedSharpObjectExtension
    {
        public static T RawAngle<T>(this T obj,
            double rawAngle)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            mauiObject.SetValue(ExampleApp.AngleViewModel.RawAngleProperty, (double)rawAngle);
            return obj;
        }
        
        public static T RawAngle<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.AngleViewModel.RawAngleProperty, builder.GetValue());
            return obj;
        }
        
        public static T RawAngle<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.AngleViewModel.RawAngleProperty, builder.GetValue());
            return obj;
        }
        
        public static T RawAngle<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, ExampleApp.AngleViewModel.RawAngleProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T Angle<T>(this T obj,
            double angle)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            mauiObject.SetValue(ExampleApp.AngleViewModel.AngleProperty, (double)angle);
            return obj;
        }
        
        public static T Angle<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.AngleViewModel.AngleProperty, builder.GetValue());
            return obj;
        }
        
        public static T Angle<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.AngleViewModel.AngleProperty, builder.GetValue());
            return obj;
        }
        
        public static T Angle<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, ExampleApp.AngleViewModel.AngleProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T MaximumAngle<T>(this T obj,
            double maximumAngle)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            mauiObject.SetValue(ExampleApp.AngleViewModel.MaximumAngleProperty, (double)maximumAngle);
            return obj;
        }
        
        public static T MaximumAngle<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.AngleViewModel.MaximumAngleProperty, builder.GetValue());
            return obj;
        }
        
        public static T MaximumAngle<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.AngleViewModel.MaximumAngleProperty, builder.GetValue());
            return obj;
        }
        
        public static T MaximumAngle<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : ExampleApp.AngleViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.AngleViewModel>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, ExampleApp.AngleViewModel.MaximumAngleProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
