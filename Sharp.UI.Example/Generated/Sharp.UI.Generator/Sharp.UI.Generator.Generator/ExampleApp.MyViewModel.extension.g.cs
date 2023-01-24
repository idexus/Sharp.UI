﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace ExampleApp
{
    using Sharp.UI;

    public static class MyViewModelGeneratedSharpObjectExtension
    {
        public static T Counter<T>(this T obj,
            int counter)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            mauiObject.SetValue(ExampleApp.MyViewModel.CounterProperty, (int)counter);
            return obj;
        }
        
        public static T Counter<T>(this T obj,
            System.Func<ValueBuilder<int>, ValueBuilder<int>> buildValue)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            var builder = buildValue(new ValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.MyViewModel.CounterProperty, builder.GetValue());
            return obj;
        }
        
        public static T Counter<T>(this T obj,
            System.Func<LazyValueBuilder<int>, LazyValueBuilder<int>> buildValue)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            var builder = buildValue(new LazyValueBuilder<int>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.MyViewModel.CounterProperty, builder.GetValue());
            return obj;
        }
        
        public static T Counter<T>(this T obj,
            System.Func<BindingBuilder<int>, BindingBuilder<int>> buildBinding)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            var builder = buildBinding(new BindingBuilder<int>(mauiObject, ExampleApp.MyViewModel.CounterProperty));
            builder.BindProperty();
            return obj;
        }
        
        public static T SliderValue<T>(this T obj,
            double sliderValue)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            mauiObject.SetValue(ExampleApp.MyViewModel.SliderValueProperty, (double)sliderValue);
            return obj;
        }
        
        public static T SliderValue<T>(this T obj,
            System.Func<ValueBuilder<double>, ValueBuilder<double>> buildValue)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            var builder = buildValue(new ValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.MyViewModel.SliderValueProperty, builder.GetValue());
            return obj;
        }
        
        public static T SliderValue<T>(this T obj,
            System.Func<LazyValueBuilder<double>, LazyValueBuilder<double>> buildValue)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            var builder = buildValue(new LazyValueBuilder<double>());
            if (builder.ValueIsSet()) mauiObject.SetValue(ExampleApp.MyViewModel.SliderValueProperty, builder.GetValue());
            return obj;
        }
        
        public static T SliderValue<T>(this T obj,
            System.Func<BindingBuilder<double>, BindingBuilder<double>> buildBinding)
            where T : ExampleApp.MyViewModel
        {
            var mauiObject = MauiWrapper.Value<ExampleApp.MyViewModel>(obj);
            var builder = buildBinding(new BindingBuilder<double>(mauiObject, ExampleApp.MyViewModel.SliderValueProperty));
            builder.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669