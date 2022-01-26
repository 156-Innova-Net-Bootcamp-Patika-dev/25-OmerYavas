using Infrastructure.Models;
using PatikaOdev3.Model.Common;

namespace PatikaOdev3.Business.Absract
{
    public interface IBaseService<TEntity>
        where TEntity : BaseEntity, new()
    {
        //List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);
        //TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);

        TEntity GetById(int id);
        
        EntityResult Insert(TEntity entity);
        EntityResult Update(TEntity entity);
        EntityResult Delete(TEntity entity);
        EntityResult Delete(int id);
    }
}
