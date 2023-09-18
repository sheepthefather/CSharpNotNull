using System.Reflection;

namespace NotNull
{
    public class NotNullable
    {
        public NotNullable()
        {
            Type type = GetType();
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public))
            {
                foreach(NotNull o in fieldInfo.GetCustomAttributes(typeof(NotNull),true))
                {
                    if (fieldInfo.GetValue(this) == null)
                    {
                        throw new Exception("This Property can't be null");
                    }
                }
            }
        }
    }


    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    sealed class NotNull : Attribute
    {
    }
}