using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data.Context;
using MVC.DataAccess.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            //.Where(T=>T.IsDeleted !=true) soft delete نتاكد انه مش ممسوح
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(T=>T.IsDeleted !=true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).AsNoTracking().ToList();
            }
        }
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).Select(selector).ToList();
        }
        //public IEnumerable<TEntity> GetEnumerable()
        //{
        //    return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
        //}

        //public IQueryable<TEntity> GetQueryable()
        //{
        //    return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true);
        //}
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
