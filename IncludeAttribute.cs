using System;

namespace ef_includer
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IncludeAttribute : Attribute
    {
        //TODO: find out what constructor parameters do we need
        
        // probably something like cascade import for given property:
        // cascade = true => include property and all of property's marked properties
    }
}
