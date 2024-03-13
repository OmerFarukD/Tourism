using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IRepository<TEntity,TEntityId> : IQuery<TEntity>
    where TEntity : Entity<TEntityId>
{
   Paginate<TEntity> GetListByPaginate(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy=null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true
    );
    
  List<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy=null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        bool enableTracking = true
    );

    
    
   TEntity Get(
        Expression<Func<TEntity,bool>> predicate,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        bool enableTracking = true
    );

   bool Any(
        Expression<Func<TEntity,bool>>? predicate = null,
        bool enableTracking = true
    );
   
   
    TEntity Add(TEntity entity);
    
    ICollection<TEntity> AddRange(ICollection<TEntity> entities);
    
    TEntity Update(TEntity entity);   
    
    TEntity Delete(TEntity entity);
    
    ICollection<TEntity> DeleteRange(ICollection<TEntity> entities);
}