using MVC.DataAccess.model;

namespace MVC.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        int Delete(Department department);
        IEnumerable<Department> GetAll(bool withTracking = true);
        Department? GetbyId(int id);
        int Update(Department department);
    }
}