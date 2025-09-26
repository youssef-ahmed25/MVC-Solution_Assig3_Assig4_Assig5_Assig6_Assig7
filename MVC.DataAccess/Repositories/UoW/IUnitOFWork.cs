using MVC.DataAccess.Repositories.Departments;
using MVC.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.UoW
{
    public interface IUnitOFWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public int Savechanges();
    }
}
