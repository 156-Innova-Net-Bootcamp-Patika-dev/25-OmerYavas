using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Abstract
{
    public interface IBaseDAL<TEntity>
        where TEntity : BaseEntity, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);
        TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);

        TEntity GetById(int id, params string[] includeList);

        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(int id);
    }
}
