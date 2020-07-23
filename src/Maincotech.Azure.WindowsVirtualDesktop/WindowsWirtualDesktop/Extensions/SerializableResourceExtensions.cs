using System.Collections.Generic;
using System.Reflection;

namespace Azure.WindowsWirtualDesktop.Models
{
    internal static class SerializableResourceExtensions
    {
        public static List<PropertyInfo> GetRequiredProperties<TModel>(this TModel model, CRUDOperationsTypes operation) where TModel : SerializableResource<TModel>
        {
            var result = new List<PropertyInfo>();
            var modelType = model.GetType();
            foreach (var propInfo in modelType.GetProperties())
            {
                var propAttribute = propInfo.GetCustomAttribute<CRUDRequiredAttribute>();
                if (propAttribute != null)
                {
                    if ((propAttribute.Value & operation) == operation)
                    {
                        result.Add(propInfo);
                    }
                }
            }
            return result;
        }
    }
}