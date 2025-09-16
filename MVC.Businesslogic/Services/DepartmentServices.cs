using MVC.Businesslogic.DataTransferObject.Department;
using MVC.Businesslogic.Factories;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.model;
using MVC.DataAccess.Repositories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();

            return departments.Select(d => d.toDepartmentDto());
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetbyId(id);

            return department == null ? null : department.toDepartmentDetailsDto();


        }
        public int addDepartment(CreateDepartmindDto departmindDto)
        {
            var result = _departmentRepository.Add(departmindDto.ToEentity());
            return result;
        }
        public int updateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEentity());
        }
        public bool deleteDepartment(int id)
        {
            var department = _departmentRepository.GetbyId(id);
            if (department == null)
            {
                return false;
            }
            else
            {
                var result = _departmentRepository.Delete(department);
                return result > 0 ? true : false;
            }
        }
    }
}
