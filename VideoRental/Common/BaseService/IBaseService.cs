using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VideoRental.Common.BaseService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity GetById(string id);

        List<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity entity);

        TEntity Update(string id, TEntity newEntity);

        TEntity Delete(string id);
    }
}
