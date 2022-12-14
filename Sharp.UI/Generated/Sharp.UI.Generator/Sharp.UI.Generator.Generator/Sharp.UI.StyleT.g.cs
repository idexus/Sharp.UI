//
// <auto-generated>
//

#pragma warning disable CS8669


namespace Sharp.UI
{  
    public partial class Style<T>
    {
        // ----- constructors -----

        public Style(out Style style) : this()
        {
            style = this;
        }

        public Style(System.Action<Style> configure) : this()
        {
            configure(this);
        }

        public Style(out Style style, System.Action<Style> configure) : this()
        {
            style = this;
            configure(this);
        }

        public Style(bool applyToDerivedTypes, out Style style) : this(applyToDerivedTypes)
        {
            style = this;
        }

        public Style(bool applyToDerivedTypes, System.Action<Style> configure) : this(applyToDerivedTypes)
        {
            configure(this);
        }

        public Style(bool applyToDerivedTypes, out Style style, System.Action<Style> configure) : this(applyToDerivedTypes)
        {
            style = this;
            configure(this);
        }

    }
}

#pragma warning restore CS8669
