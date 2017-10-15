using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VideoRental.Common.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(string id);

        List<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);
    }
}
