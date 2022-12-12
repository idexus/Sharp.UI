﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI.Example
{
    using Sharp.UI;

    public static class EmptyCardViewGeneratedExtension
    {
        public static T CardTitle<T>(this T obj,
            string? cardTitle)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (cardTitle != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardTitleProperty, (string)cardTitle);
            return obj;
        }
        
        public static T CardTitle<T>(this T obj,
            string? cardTitle,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (cardTitle != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardTitleProperty, (string)cardTitle);
            var def = definition(new BindableDef<string>(mauiObject, Sharp.UI.Example.EmptyCardView.CardTitleProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardTitleProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T CardTitle<T>(this T obj,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            var def = definition(new BindableDef<string>(mauiObject, Sharp.UI.Example.EmptyCardView.CardTitleProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardTitleProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T CardDescription<T>(this T obj,
            string? cardDescription)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (cardDescription != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardDescriptionProperty, (string)cardDescription);
            return obj;
        }
        
        public static T CardDescription<T>(this T obj,
            string? cardDescription,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (cardDescription != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardDescriptionProperty, (string)cardDescription);
            var def = definition(new BindableDef<string>(mauiObject, Sharp.UI.Example.EmptyCardView.CardDescriptionProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardDescriptionProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T CardDescription<T>(this T obj,
            Func<BindableDef<string>, BindableDef<string>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            var def = definition(new BindableDef<string>(mauiObject, Sharp.UI.Example.EmptyCardView.CardDescriptionProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardDescriptionProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T CardColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? cardColor)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (cardColor != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardColorProperty, (Microsoft.Maui.Graphics.Color)cardColor);
            return obj;
        }
        
        public static T CardColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? cardColor,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (cardColor != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardColorProperty, (Microsoft.Maui.Graphics.Color)cardColor);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Sharp.UI.Example.EmptyCardView.CardColorProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardColorProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T CardColor<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Sharp.UI.Example.EmptyCardView.CardColorProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.CardColorProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? borderColor)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (borderColor != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.BorderColorProperty, (Microsoft.Maui.Graphics.Color)borderColor);
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Microsoft.Maui.Graphics.Color? borderColor,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            if (borderColor != null) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.BorderColorProperty, (Microsoft.Maui.Graphics.Color)borderColor);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Sharp.UI.Example.EmptyCardView.BorderColorProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.BorderColorProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
        public static T BorderColor<T>(this T obj,
            Func<BindableDef<Microsoft.Maui.Graphics.Color>, BindableDef<Microsoft.Maui.Graphics.Color>> definition)
            where T : Sharp.UI.Example.EmptyCardView
        {
            var mauiObject = MauiWrapper.GetObject<Sharp.UI.Example.EmptyCardView>(obj);
            var def = definition(new BindableDef<Microsoft.Maui.Graphics.Color>(mauiObject, Sharp.UI.Example.EmptyCardView.BorderColorProperty));
            if (def.ValueIsSet()) mauiObject.SetValue(Sharp.UI.Example.EmptyCardView.BorderColorProperty, def.GetValue());
            def.BindProperty();
            return obj;
        }
        
    }
}


#pragma warning restore CS8669
