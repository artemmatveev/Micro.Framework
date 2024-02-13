﻿namespace Micro.Framework.EntityFrameworkCore.SqlServer.Extensions
{    
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> OrderByEx<TEntity>(this IQueryable<TEntity> source,
            string orderByProperty, bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);

            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            var resultExpression = Expression.Call(typeof(Queryable), command,
                            new Type[] { type, property.PropertyType },
                            source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
