using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using Task1.DoNotChange;

namespace Task1
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _typeImplementationDependencies = new Dictionary<Type, Type>();

        public void AddAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            
            foreach (var type in types)
            {
                var exportAttribute = type.GetCustomAttribute<ExportAttribute>();
                var importAttribute = type.GetCustomAttribute<ImportConstructorAttribute>();
                var importProperties = type.GetProperties().Where(prop => prop.GetCustomAttribute<ImportAttribute>() != null);
                
                if (importAttribute != null)
                {
                    _typeImplementationDependencies.Add(type, type);
                }
                else if (exportAttribute != null)
                {
                    _typeImplementationDependencies.Add(
                        exportAttribute.Contract == null ? type : exportAttribute.Contract, type);
                }
                else if(importProperties.Any())
                {
                    _typeImplementationDependencies.Add(type, type);
                }
            }
        }

        public void AddType(Type type)
        {
            _typeImplementationDependencies.Add(type, type);
        }

        public void AddType(Type type, Type baseType)
        {
            _typeImplementationDependencies.Add(baseType, type);
        }

        public T Get<T>()
        {
            var implementationType =
                _typeImplementationDependencies.LastOrDefault(serviceDescriptor => serviceDescriptor.Key == typeof(T) || serviceDescriptor.Value == typeof(T)).Value;

            if (implementationType == null)
            {
                throw new Exception($"The implementation for the {typeof(T)} wasn't found");
            }
            
            var constructorParameters = implementationType.GetConstructors()[0].GetParameters();
            var importedProperties = implementationType.GetProperties()
                .Where(prop => prop.GetCustomAttribute<ImportAttribute>() != null).ToList();
            
            if (constructorParameters.Length > 0)
            {
                return GetImplementationForTypeWithConstructor<T>(implementationType, constructorParameters);
            }
            
            if (importedProperties.Any())
            {
                return GetImplementationForTypeWithImportedProperties<T>(implementationType, importedProperties);
            }

            return (T) Activator.CreateInstance(implementationType);
        }

        private T GetImplementationForTypeWithImportedProperties<T>(Type implementationType, IEnumerable<PropertyInfo> propertyInfos)
        {
            var implementation = Activator.CreateInstance(implementationType);
            
            foreach (var property in implementationType.GetProperties().Where(prop => prop.GetCustomAttribute<ImportAttribute>() != null))
            {
                var parameterType = property.PropertyType;
                var method = typeof(Container).GetMethod(nameof(Get));
                var generic = method.MakeGenericMethod(parameterType);
                var propertyImplementation = generic.Invoke(this, null);
                
                property.SetValue(implementation, propertyImplementation);
            }

            return (T) implementation;
        }

        private T GetImplementationForTypeWithConstructor<T>(Type implementationType, ParameterInfo[] constructorParameters)
        {
            var importConstructorAttribute =
                implementationType.GetCustomAttribute<ImportConstructorAttribute>();

            if (importConstructorAttribute == null) return (T) Activator.CreateInstance(implementationType);
            {
                var parameters = new List<object>();
                
                foreach (var parameter in constructorParameters)
                {
                    var parameterType = parameter.ParameterType;
                    var method = typeof(Container).GetMethod(nameof(Get));
                    var generic = method.MakeGenericMethod(parameterType);
                    var implementationParameter = generic.Invoke(this, null);
                    parameters.Add(implementationParameter);
                }

                return (T) Activator.CreateInstance(implementationType, parameters.ToArray());
            }
        }
    }
}