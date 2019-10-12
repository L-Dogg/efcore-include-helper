using System;

namespace EfIncluder
{
    /// <summary>
    /// All of entity's properties marked with this attribute will be automatically included during
    /// EF Core eager loading if user invoked <see cref="DbSet.IncludeMarkedProperties">
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IncludeAttribute : Attribute
    {
    }
}
