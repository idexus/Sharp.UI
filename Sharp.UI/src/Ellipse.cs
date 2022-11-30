using System;
namespace Sharp.UI
{
	public partial class Ellipse
	{
        public static implicit operator Microsoft.Maui.Controls.VisualElement(Ellipse obj) => obj.MauiObject;
    }
}

