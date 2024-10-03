using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MinimalBankAPI_OnionArch.Domain.Common;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract.Base;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Pagination;
using System.Linq.Expressions;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> __table { get => _dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await __table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await __table.AddRangeAsync(entities);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = __table;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = __table;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<IPaginate<T>> GetListIPaginateAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool isAll = false, bool withDeleted = false, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = __table;
            if (index == 0 && size == 0)
                size = int.MaxValue;
            if (isAll)
                size = int.MaxValue;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();
            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, from: 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, from: 0, cancellationToken);
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => { __table.RemoveRange(entity); });
        }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => { __table.Remove(entity); });
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { __table.Update(entity); });
            return entity;
        }

        public async Task<IList<T>> UpdateRangeAsync(IList<T> entity)
        {
            await Task.Run(() =>
            {
                __table.UpdateRange(entity);
            });
            return entity;
        }
    }
}
