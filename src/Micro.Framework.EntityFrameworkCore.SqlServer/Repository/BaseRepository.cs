namespace Micro.Framework.EntityFrameworkCore.SqlServer.Repository
{
    using Extensions;

    public abstract class BaseRepository<TEntity, TContext> where TEntity : BaseEntity<long> where TContext : DbContext
    {
        protected TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
            => await _context.Set<TEntity>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
   
        public virtual async Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression,
                string orderByProperty, SortOrder sortOrder) 
           => await _context.Set<TEntity>()
               .Where(expression)
               .OrderByEx(orderByProperty, sortOrder == SortOrder.Desc)
               .AsNoTracking()
               .ToListAsync();
        
        public virtual async Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression,
                 int pageNumber, int pageSize, string orderByProperty, SortOrder sortOrder)
           => await _context.Set<TEntity>()
               .Where(expression)
               .OrderByEx(orderByProperty, sortOrder == SortOrder.Desc)
               .Skip(pageNumber * pageSize)
               .Take(pageSize)
               .AsNoTracking()
               .ToListAsync();
        
        public virtual async Task<IReadOnlyList<TEntity>> FindAllAsync(string sql, params object[] parameters)
            => await _context.Set<TEntity>()
                .FromSqlRaw(sql, parameters)
                .AsNoTracking()
                .ToListAsync();

        public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _context.Set<TEntity>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();

            if (entities.Any())
            {
                return entities;
            }
            else
            {
                throw new InvalidParameterException("Entites not found by speciffied parameters");
            }
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(string sql, params object[] parameters)
        {
            var entities = await _context.Set<TEntity>()
                .FromSqlRaw(sql, parameters)
                .AsNoTracking()
                .ToListAsync();

            if (entities.Any())
            {
                return entities;
            }
            else
            {
                throw new InvalidParameterException("Entites not found by speciffied parameters");
            }
        }

        public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression)
            => await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

        public virtual async Task<TEntity?> FindAsync(string sql, params object[] parameters)
            => (await _context.Set<TEntity>()
                .FromSqlRaw(sql, parameters)
                .AsNoTracking().ToListAsync())
                .FirstOrDefault();

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            if (entity is null)
            {
                throw new InvalidParameterException("Entity not found by speciffied parameters");
            }
            else
            {
                return entity;
            }
        }

        public virtual async Task<TEntity> GetAsync(string sql, params object[] parameters)
        {
            var entity = (await _context.Set<TEntity>()
                .FromSqlRaw(sql, parameters)
                .AsNoTracking().ToListAsync())
                .FirstOrDefault();

            if (entity is null)
            {
                throw new InvalidParameterException("Entity not found by speciffied parameters");
            }
            else
            {
                return entity;
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, Expression<Func<TEntity, bool>> expression)
        {
            var isExisting = _context.Set<TEntity>().All(expression);
            if (isExisting is false)
            {
                throw new ConflictException("Entity already added");
            }
            else
            {
                var addEntity = _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();

                return addEntity.Entity;
            }
        }

        public virtual async Task<TEntity> AddAsync(string sql, params object[] parameters)
            => (await _context.Set<TEntity>().FromSqlRaw(sql, parameters).ToListAsync()).First();

        public virtual async Task<IReadOnlyList<TEntity>> AddCollectionAsync(string sql, params object[] parameters)
            => (await _context.Set<TEntity>().FromSqlRaw(sql, parameters).ToListAsync());

        public virtual async Task<int> UpdateAsync(long id, Action<TEntity> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity is null)
            {
                throw new InvalidParameterException($"Entity not found by id {id}");
            }

            action.Invoke(entity);

            _context.Set<TEntity>().Update(entity);

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Обновление сущности, если выполняется условие expression
        /// </summary>
        /// <param name="id">Идентификатор обновляемой сущности</param>
        /// <param name="action">Действие, по обновлению, которое необходимо выполнить</param>
        /// <param name="expression">Условие обновления</param>
        /// <returns></returns>
        /// <exception cref="InvalidParameterException"></exception>
        /// <exception cref="ConflictException"></exception>
        public virtual async Task<int> UpdateAsync(long id, Action<TEntity> action, Expression<Func<TEntity, bool>> expression)
        {
            ArgumentNullException.ThrowIfNull(action);

            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity is null)
            {
                throw new InvalidParameterException($"Entity not found by id {id}");
            }

            var isExisting = _context.Set<TEntity>().All(expression);
            if (isExisting is false)
            {
                throw new ConflictException("Entity already added");
            }
            else
            {
                action.Invoke(entity);

                _context.Set<TEntity>().Update(entity);

                return await _context.SaveChangesAsync();
            }            
        }

        public virtual async Task<int> UpdateAsync(string sql, params object[] parameters)
            => await _context.Database.ExecuteSqlRawAsync(sql, parameters);

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(long id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity is null)
            {
                throw new ConflictException("Entity already removed");
            }
            else
            {                
                return await DeleteAsync(entity);
            }
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(string sql, params object[] parameters)
            => await _context.Database.ExecuteSqlRawAsync(sql, parameters);

        public virtual async Task<int> GetTotalRecords(Expression<Func<TEntity, bool>> expression)
                => await _context.Set<TEntity>().Where(expression).CountAsync();
    }
}
