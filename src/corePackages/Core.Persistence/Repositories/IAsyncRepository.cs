using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity,TEntityId> : IQuery<TEntity>
    where TEntity : Entity<TEntityId>
{
    Task<Paginate<TEntity>> GetListByPaginateAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy=null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        
    );
    
    Task<List<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy=null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    
    
    Task<TEntity> GetAsync(
        Expression<Func<TEntity,bool>> predicate,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<TEntity,bool>>? predicate = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

 

    Task<TEntity> AddAsync(TEntity entity);
    
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);
    
    Task<TEntity> UpdateAsync(TEntity entity);
    
    Task<TEntity> DeleteAsync(TEntity entity);
    
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities);
}