using System;
namespace Sharp.UI
{
	public partial class Ellipse
	{
        public static implicit operator Microsoft.Maui.Controls.View(Ellipse obj) => obj.MauiObject;
    }

    public static class Test
    {
        public static void Tescik()
        {
            //System.Collections.Generic.IList<Microsoft.Maui.Controls.TriggerBase> test;
        }

        //public static T StrokeDashPattern<T>(this T obj,
        //    float[] strokeDashPattern)
        //    where T : Sharp.UI.IShape
        //{
        //    var mauiObject = MauiWrapper.GetObject<Microsoft.Maui.Controls.Shapes.Shape>(obj);
        //    foreach (var item in strokeDashPattern) mauiObject.StrokeDashPattern.;
        //    return obj;
        //}
    }
}

