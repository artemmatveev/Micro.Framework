namespace Micro.Framework.UseCase.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<long>
    {
        Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression, string orderByProperty, SortOrder sortOrder);
        Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression, int pageNumber, int pageSize, string orderByProperty, SortOrder sortOrder);
        Task<IReadOnlyList<TEntity>> FindAllAsync(string sql, params object[] parameters);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<IReadOnlyList<TEntity>> GetAllAsync(string sql, params object[] parameters);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> FindAsync(string sql, params object[] parameters);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(string sql, params object[] parameters);
        Task<TEntity> AddAsync(TEntity entity, Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(string sql, params object[] parameters);
        Task<IReadOnlyList<TEntity>> AddCollectionAsync(string sql, params object[] parameters);
        Task<int> UpdateAsync(long id, Action<TEntity> action);
        Task<int> UpdateAsync(long id, Action<TEntity> action, Expression<Func<TEntity, bool>> expression);
        Task<int> UpdateAsync(string sql, params object[] parameters);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteAsync(string sql, params object[] parameters);
        Task<int> GetTotalRecords(Expression<Func<TEntity, bool>> expression);
    }
}

