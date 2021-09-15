using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MTGCore.Repository.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> Filter<T>(this DbSet<T> set, IEnumerable<Expression<Func<T, bool>>> filters)
            where T : class
        {
            var query = set.AsQueryable();
            var filtersList = filters.ToList();
            return !filtersList.Any() ? 
                set : 
                filtersList.Aggregate(query, (current, filter) => current.Where(filter));
        }
    }
}