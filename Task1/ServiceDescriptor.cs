using System;

namespace Task1
{
    public class ServiceDescriptor
    {
        public Type Type { get; }
        public object Implementation { get; }

        public ServiceDescriptor(Type type, object implementation)
        {
            Type = type;
            Implementation = implementation;
        }
    }
}