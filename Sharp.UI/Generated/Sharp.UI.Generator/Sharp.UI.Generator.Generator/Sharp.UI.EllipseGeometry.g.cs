﻿//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{
    public partial class EllipseGeometry : Microsoft.Maui.Controls.Shapes.EllipseGeometry, Sharp.UI.IEllipseGeometry, IWrappedBindableObject
    {
        // ----- constructors -----

        public EllipseGeometry() { }

        public EllipseGeometry(out EllipseGeometry ellipseGeometry) 
        {
            ellipseGeometry = this;
        }

        public EllipseGeometry(Action<EllipseGeometry> configure) 
        {
            configure(this);
        }

        public EllipseGeometry(out EllipseGeometry ellipseGeometry, Action<EllipseGeometry> configure) 
        {
            ellipseGeometry = this;
            configure(this);
        }

        public EllipseGeometry(double radiusx, double radiusy, Microsoft.Maui.Graphics.Point center) 
        {  
            this.RadiusX = radiusx;
            this.RadiusY = radiusy;
            this.Center = center;
        }

        public EllipseGeometry(double radiusx, double radiusy, Microsoft.Maui.Graphics.Point center, out EllipseGeometry ellipseGeometry) 
        {  
            this.RadiusX = radiusx;
            this.RadiusY = radiusy;
            this.Center = center;;
            ellipseGeometry = this;
        }

        public EllipseGeometry(double radiusx, double radiusy, Microsoft.Maui.Graphics.Point center, Action<EllipseGeometry> configure) 
        {  
            this.RadiusX = radiusx;
            this.RadiusY = radiusy;
            this.Center = center;
            configure(this);
        }

        public EllipseGeometry(double radiusx, double radiusy, Microsoft.Maui.Graphics.Point center, out EllipseGeometry ellipseGeometry, Action<EllipseGeometry> configure) 
        {  
            this.RadiusX = radiusx;
            this.RadiusY = radiusy;
            this.Center = center;
            ellipseGeometry = this;
            configure(this);
        }

        // ----- binding context -----

        public new object BindingContext
        {
            get => base.BindingContext;
            set
            {
                var mauiObject = MauiWrapper.GetObject<object>(value);
                base.BindingContext = mauiObject;
            }
        }
        

    }
}

#pragma warning restore CS8669