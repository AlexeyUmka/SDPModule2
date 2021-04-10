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
                _typeImplementationDependencies.LastOrDefault(serviceDescriptor => serviceDescriptor.Key == typeof(T) || serviceDescriptor.Value == typeof(T));
            
            var constructorParameters = implementationType.Value.GetConstructors()[0].GetParameters();
            
            var importedProperties = implementationType.Value.GetProperties()
                .Where(prop => prop.GetCustomAttribute<ImportAttribute>() != null).ToList();
            
            if (constructorParameters.Length > 0)
            {
                return GetImplementationForTypeWithConstructor<T>(implementationType, constructorParameters);
            }
            
            if (importedProperties.Any())
            {
                return GetImplementationForTypeWithImportedProperties<T>(implementationType, importedProperties);
            }

            return (T) Activator.CreateInstance(implementationType.Value);
        }

        private T GetImplementationForTypeWithImportedProperties<T>(KeyValuePair<Type, Type> implementationType, IEnumerable<PropertyInfo> propertyInfos)
        {
            var implementation = Activator.CreateInstance(implementationType.Value);
            
            foreach (var property in implementationType.Value.GetProperties().Where(prop => prop.GetCustomAttribute<ImportAttribute>() != null))
            {
                var parameterType = property.PropertyType;
                
                var method = typeof(Container).GetMethod(nameof(Get));
                
                var generic = method.MakeGenericMethod(parameterType);
                
                object propertyImplementation = null;
                
                propertyImplementation = generic.Invoke(this, null);
                
                property.SetValue(implementation, propertyImplementation);
            }

            return (T) implementation;
        }

        private T GetImplementationForTypeWithConstructor<T>(KeyValuePair<Type, Type> implementationType, ParameterInfo[] constructorParameters)
        {
            var exportAttribute = implementationType.Value.GetCustomAttribute<ExportAttribute>();
            
            var importConstructorAttribute =
                implementationType.Key.GetCustomAttribute<ImportConstructorAttribute>();
            
            if (exportAttribute != null)
            {
                _typeImplementationDependencies.Add(
                    exportAttribute.Contract == null ? implementationType.Value : exportAttribute.Contract,
                    implementationType.Value);
                
                var method = typeof(Container).GetMethod(nameof(Get));
                
                var generic = method.MakeGenericMethod(implementationType.Key);
                
                return (T) generic.Invoke(this, null);
            }

            if (importConstructorAttribute == null) return (T) Activator.CreateInstance(implementationType.Value);
            {
                var parameters = new List<object>();
                
                foreach (var parameter in constructorParameters)
                {
                    object implementationParameter = null;
                    
                    var parameterType = parameter.ParameterType;
                    
                    var method = typeof(Container).GetMethod(nameof(Get));
                    
                    var generic = method.MakeGenericMethod(parameterType);
                    
                    implementationParameter = generic.Invoke(this, null);
                    
                    parameters.Add(implementationParameter);
                }

                return (T) Activator.CreateInstance(implementationType.Value, parameters.ToArray());
            }
        }
    }
}