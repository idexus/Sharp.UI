namespace Sharp.UI
{
    public class MauiWrapperAttribute : Attribute
    {
        public MauiWrapperAttribute(
            Type baseType = null,
            string[] doNotGenerateList = null,
            string[] constructorWithProperties = null,
            string containerPopertyName = "",
            string[] attachedProperties = null,
            Type[] attachedPropertiesTypes = null)
        {
            
        }
    }

    public class BindableAttribute : Attribute
    {
        public BindableAttribute()
        {

        }
    }
}