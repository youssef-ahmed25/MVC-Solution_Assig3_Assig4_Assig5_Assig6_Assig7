using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data.Context;
using MVC.DataAccess.model.Employees;
using MVC.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Employees
{
    public class EmployeeRepository:GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        #region befor genericRepository
        //public Employee? GetbyId(int id)
        //{
        //    var employee = _dbContext.Employees.Find(id);
        //    return employee;
        //}
        //public IEnumerable<Employee> GetAll(bool withTracking = true)
        //{
        //    if (withTracking)
        //    {
        //        return _dbContext.Employees.ToList();
        //    }
        //    else
        //    {
        //        return _dbContext.Employees.AsNoTracking().ToList();
        //    }

        //}
        //public int Add(Employee employee)
        //{
        //    _dbContext.Add(employee);
        //    return _dbContext.SaveChanges();
        //}
        //public int Update(Employee employee)
        //{
        //    _dbContext.Update(employee);
        //    return _dbContext.SaveChanges();
        //}
        //public int Delete(Employee employee)
        //{
        //    _dbContext.Remove(employee);
        //    return _dbContext.SaveChanges();
        //} 
        #endregion
    }
}
