﻿//
// <auto-generated> Sharp.UI.Generator.Classes.Builder
//

#nullable enable


using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace Sharp.UI
{
	using Sharp.UI;

    public partial class MenuFlyout : IList<Microsoft.Maui.IMenuElement>
	{

        // ----- constructors -----

        public MenuFlyout() { }

        public MenuFlyout(out MenuFlyout menuFlyout) 
        {
            menuFlyout = this;
        }

        public MenuFlyout(System.Func<MenuFlyout, MenuFlyout> configure) 
        {
            configure(this);
        }

        public MenuFlyout(out MenuFlyout menuFlyout, System.Func<MenuFlyout, MenuFlyout> configure) 
        {
            menuFlyout = this;
            configure(this);
        }

    }
}

#nullable restore
