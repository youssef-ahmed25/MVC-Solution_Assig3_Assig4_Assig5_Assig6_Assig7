using MVC.Businesslogic.DataTransferObject;

namespace MVC.Businesslogic.Services
{
    public interface IDepartmentServices
    {
        int addDepartment(CreateDepartmindDto departmindDto);
        bool deleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int updateDepartment(UpdatedDepartmentDto departmentDto);
    }
}