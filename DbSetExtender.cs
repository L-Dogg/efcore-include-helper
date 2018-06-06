using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ef_includer
{
    //TODO: naming
    public static class DbSetExtender
    {
        public static IQueryable<TEntity> IncludeMarkedProperties<TEntity>(this DbSet<TEntity> DbSet) where TEntity : class
        {
            //TODO: implement and test and handle incoming cascade option
            var properties = IncludeAttributeFinder.FindPropertiesWithIncludeAttribute(typeof(TEntity));
            IQueryable<TEntity> retVal = DbSet;
            foreach (var property in properties)
            {
                retVal = retVal.Include(property.Name);
            }
            return retVal;
        }
    }
}