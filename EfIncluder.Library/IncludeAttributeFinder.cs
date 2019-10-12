using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EfIncluder
{
    internal static class IncludeAttributeFinder
    {
        private static readonly Dictionary<Type, IEnumerable<PropertyInfo>> Cache =
            new Dictionary<Type, IEnumerable<PropertyInfo>>();

        internal static IEnumerable<PropertyInfo> FindPropertiesWithIncludeAttribute(Type type)
        {
            if (Cache.ContainsKey(type))
                return Cache[type];

            Cache[type] = type
                .GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(IncludeAttribute)));

            return Cache[type];
        }
    }
}