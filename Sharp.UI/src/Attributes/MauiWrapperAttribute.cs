namespace Sharp.UI
{
    public class MauiWrapperAttribute : Attribute
    {
        public MauiWrapperAttribute(
            Type baseType = null,
            string[] constructorWithProperties = null,
            string containerPopertyName = "")
        {
        }
    }
}