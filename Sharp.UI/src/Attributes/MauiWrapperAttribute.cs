namespace Sharp.UI
{
    public class MauiWrapperAttribute : Attribute
    {
        public MauiWrapperAttribute(
            Type mauiType,
            string[] doNotGenerateList = null,
            string[] constructorWithProperties = null,
            Type containerOfType = null,
            bool singleItemContainer = false,
            string containerPopertyName = "",
            Type typeConformanceName = null,
            bool generateAdditionalConstructors = true,
            bool generateNoParamConstructor = true)
        {

        }
    }
}