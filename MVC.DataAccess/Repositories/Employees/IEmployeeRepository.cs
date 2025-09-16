using MVC.DataAccess.model.Employees;
using MVC.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //int Add(Employee employee);

        //IEnumerable<Employee> GetAll(bool withTracking = true);
        //Employee? GetbyId(int id);
        //int Delete(Employee employee);
        //int Update(Employee employee);
        //IEnumerable<Employee> GetAll(object withTracking);
    }
}
