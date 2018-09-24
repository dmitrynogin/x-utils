using System;

namespace X.IoC
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : Attribute
    {
        public bool AsSelf { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : ServiceAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TransientAttribute : ServiceAttribute
    {
    }
}
