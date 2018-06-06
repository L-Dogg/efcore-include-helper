using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ef_includer
{
    public static class IncludeAttributeFinder
    {
        //TODO: how to handle cascade option
        public static IEnumerable<PropertyInfo> FindPropertiesWithIncludeAttribute(Type type) => 
            type
                .GetProperties()
                .Where(prop => 
                    Attribute.IsDefined(prop, typeof(IncludeAttribute)));
    }
}