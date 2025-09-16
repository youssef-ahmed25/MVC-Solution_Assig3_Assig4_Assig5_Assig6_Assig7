using MVC.Businesslogic.DataTransferObject.Department;

namespace MVC.Businesslogic.Services.Interface
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