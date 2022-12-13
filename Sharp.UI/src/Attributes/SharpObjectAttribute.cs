namespace Sharp.UI
{
    public class SharpObjectAttribute : Attribute
    {
        public SharpObjectAttribute(
            Type baseType = null,
            string[] constructorWithProperties = null,
            string containerPopertyName = "")
        {
        }
    }
}