namespace Micro.Framework.UseCase.Handlers
{    
    public record BaseRequestQuery<TEntity> where TEntity : BaseEntity<long>
    {
        public virtual Expression<Func<TEntity, bool>> GetExpression()
        {
            Expression<Func<TEntity, bool>> query = t => true;

            return query;
        }
    }
}
