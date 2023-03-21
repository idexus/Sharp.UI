using System;
namespace CodeMarkup.Maui
{
	public class PropertyCallbacksAttribute : Attribute
	{
		public PropertyCallbacksAttribute(
			string propertyChanged = null,
			string propertyChanging = null,
            string validateValue = null,
			string coerceValue = null,
            string defaultValueCreator = null)
		{
		}
	}
}

