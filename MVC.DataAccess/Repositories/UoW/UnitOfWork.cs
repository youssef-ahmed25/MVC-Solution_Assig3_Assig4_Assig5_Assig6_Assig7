using MVC.DataAccess.Data.Context;
using MVC.DataAccess.Repositories.Departments;
using MVC.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.UoW
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_dbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbContext));


        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public int Savechanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
