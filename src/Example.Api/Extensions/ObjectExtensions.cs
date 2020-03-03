using System;
using System.Dynamic;
using System.Reflection;
using System.Collections.Generic;

namespace Example.Api.Extensions
{
    internal static class ObjectExtensions
    {
        internal static ExpandoObject ToResponse<TObject>(this TObject instance)
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var expandoObject = new ExpandoObject() as IDictionary<string, object>;

            var propertyInfos = typeof(TObject).GetProperties(
                                        BindingFlags.IgnoreCase | 
                                        BindingFlags.Public | 
                                        BindingFlags.Instance);

            foreach (var propertyInfo in propertyInfos)
            {
                var propertyValue = propertyInfo.GetValue(instance);

                expandoObject.Add(propertyInfo.Name, propertyValue);
            }

            return (ExpandoObject)expandoObject;
        }

        internal static ExpandoObject ToResponse<TObject>(this TObject instance, string[] requestedValues)
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var expandoObject = new ExpandoObject() as IDictionary<string, object>;

            foreach (var value in requestedValues)
            {
                var propertyInfo = typeof(TObject).GetProperty(value,
                                            BindingFlags.IgnoreCase |
                                            BindingFlags.Public | 
                                            BindingFlags.Instance);

                if (propertyInfo is null)
                {
                    throw new Exception($"Property {value} wasn't found on {typeof(TObject)}.");
                }

                var propertyValue = propertyInfo.GetValue(instance);

                // add the field to the ExpandoObject
                expandoObject.Add(propertyInfo.Name, propertyValue);
            }

            return (ExpandoObject)expandoObject;
        }
    }    
}