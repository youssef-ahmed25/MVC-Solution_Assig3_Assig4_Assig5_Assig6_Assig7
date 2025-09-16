using MVC.DataAccess.model;
using MVC.DataAccess.model.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = true);
        TEntity? GetbyId(int id);
        int Update(TEntity entity);
    }
}
