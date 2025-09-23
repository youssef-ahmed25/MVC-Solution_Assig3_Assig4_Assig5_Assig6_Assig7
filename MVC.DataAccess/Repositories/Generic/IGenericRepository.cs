using MVC.DataAccess.model;
using MVC.DataAccess.model.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = true);

        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>>selector);
        //فلتر عند الداتابيس) فهبعته الحاجه اللى عاوز افلتر بيها عند داتابيس)
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>>predicate);
        TEntity? GetbyId(int id);
        int Update(TEntity entity);

        //IEnumerable<TEntity> GetEnumerable();
        //IQueryable<TEntity> GetQueryable();
    }
}
