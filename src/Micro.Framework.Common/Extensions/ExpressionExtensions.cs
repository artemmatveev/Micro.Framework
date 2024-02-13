namespace Micro.Framework.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndExpression<T>(this Expression<Func<T, bool>> query,
          Expression<Func<T, bool>> exp)
        {
            return query != null ? query.And(exp) : exp;
        }
    }
}
