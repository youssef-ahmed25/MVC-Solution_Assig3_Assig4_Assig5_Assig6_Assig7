using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data.Context;
using MVC.DataAccess.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity? GetbyId(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }
        public IEnumerable<TEntity> GetAll(bool withTracking = true)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            }

        }
        public int Add(TEntity entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

    }
}
