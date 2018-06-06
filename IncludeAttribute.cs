using System;

namespace ef_includer
{
    /// <summary>
    /// All of entity's properties marked with this attributes will be automatically included during
    /// EF Core eager loading if user invoked <see cref="DbSet.IncludeMarkedProperties">
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IncludeAttribute : Attribute
    {
        public bool CascadeInclude { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cascadeInclude"></param>
        public IncludeAttribute(bool cascadeInclude = false)
        {
            this.CascadeInclude = cascadeInclude;
        }
    }
}
