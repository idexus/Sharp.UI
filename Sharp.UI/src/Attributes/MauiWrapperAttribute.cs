namespace Sharp.UI
{
    public class MauiWrapperAttribute : Attribute
    {
        public MauiWrapperAttribute(
            Type mauiType,
            string[] doNotGenerateList = null,
            string[] constructorWithProperties = null,
            string containerPopertyName = "",
            bool generateAdditionalConstructors = true,
            bool generateNoParamConstructor = true,
            string[] attachedProperties = null,
            Type[] attachedPropertiesTypes = null)
        {
            
        }
    }
}