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

    public class AttachedInterfacesAttribute : Attribute
    {
        public AttachedInterfacesAttribute(Type[] attachedInterfaces = null)
        {

        }
    }

    public class BindableAttribute : Attribute
    {
        public BindableAttribute()
        {

        }
    }

    public class AttachedPropertiesAttribute : Attribute
    {
        public AttachedPropertiesAttribute(Type attachedType)
        {

        }
    }
}