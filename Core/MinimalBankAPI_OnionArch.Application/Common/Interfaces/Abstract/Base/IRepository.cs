using Microsoft.EntityFrameworkCore.Query;
using MinimalBankAPI_OnionArch.Domain.Common;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Pagination;
using System.Linq.Expressions;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract.Base
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           bool enableTracking = false);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false);

        Task<IPaginate<T>> GetListIPaginateAsync(
                Expression<Func<T, bool>>? predicate = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                int index = 0,
                int size = 10,
                bool isAll = false,
                bool withDeleted = false,
                bool enableTracking = false,
                CancellationToken cancellationToken = default);

        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<IList<T>> UpdateRangeAsync(IList<T> entity);
        Task HardDeleteRangeAsync(IList<T> entity);
        Task HardDeleteAsync(T entity);
    }
}
