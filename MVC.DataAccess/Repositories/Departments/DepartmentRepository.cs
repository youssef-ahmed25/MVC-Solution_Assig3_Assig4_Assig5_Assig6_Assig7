using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data.Context;
using MVC.DataAccess.model.Departments;
using MVC.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVC.DataAccess.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;

        }
        #region before genericRepository
        //public Department? GetbyId(int id)
        //{
        //    var department = _dbContext.Departments.Find(id);
        //    return department;
        //}
        //public IEnumerable<Department> GetAll(bool withTracking = true)
        //{
        //    if (withTracking)
        //    {
        //        return _dbContext.Departments.ToList();
        //    }
        //    else
        //    {
        //        return _dbContext.Departments.AsNoTracking().ToList();
        //    }

        //}
        //public int Add(Department department)
        //{
        //    _dbContext.Add(department);
        //    return _dbContext.SaveChanges();
        //}
        //public int Update(Department department)
        //{
        //    _dbContext.Update(department);
        //    return _dbContext.SaveChanges();
        //}
        //public int Delete(Department department)
        //{
        //    _dbContext.Remove(department);
        //    return _dbContext.SaveChanges();
        //} 
        #endregion
    }
}
