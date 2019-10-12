using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfIncluder
{
    public static class DbSetExtensions
    {
        public static IQueryable<TEntity> IncludeMarkedProperties<TEntity>(this DbSet<TEntity> dbSet)
            where TEntity : class
        {
            var properties = IncludeAttributeFinder.FindPropertiesWithIncludeAttribute(typeof(TEntity));
            IQueryable<TEntity> retVal = dbSet;
            foreach (var property in properties)
            {
                retVal = retVal.Include(property.Name);
            }

            return retVal;
        }
    }
}