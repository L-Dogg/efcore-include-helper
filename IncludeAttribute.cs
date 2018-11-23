using System;

namespace ef_includer
{
    /// <summary>
    /// All of entity's properties marked with this attribute will be automatically included during
    /// EF Core eager loading if user invoked <see cref="DbSet.IncludeMarkedProperties">
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IncludeAttribute : Attribute
    {
        public bool CascadeInclude { get; private set; }
        /// <summary>
        /// If this parameter is set to true, if entity's property marked with Include attribute
        /// contains properties with this attribute (and so on), they'll be automatically included during EF Core
        /// eager loading.
        /// </summary>
        /// <param name="cascadeInclude"></param>
        public IncludeAttribute(bool cascadeInclude = false)
        {
            this.CascadeInclude = cascadeInclude;
        }
    }
}
