using MVC.DataAccess.model.Departments;
using MVC.DataAccess.Repositories.Generic;

namespace MVC.DataAccess.Repositories.Departments
{
    public interface IDepartmentRepository: IGenericRepository<Department>
    {
        //int Add(Department department);
        //int Delete(Department department);
        //IEnumerable<Department> GetAll(bool withTracking = true);
        //Department? GetbyId(int id);
        //int Update(Department department);
    }
}