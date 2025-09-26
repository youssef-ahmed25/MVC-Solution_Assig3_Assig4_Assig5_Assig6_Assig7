using MVC.Businesslogic.DataTransferObject.Department;
using MVC.Businesslogic.Factories;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.model;
using MVC.DataAccess.Repositories.Departments;
using MVC.DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOFWork _unitOFWork;
        public DepartmentServices(IUnitOFWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOFWork.DepartmentRepository.GetAll();

            return departments.Select(d => d.toDepartmentDto());
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitOFWork.DepartmentRepository.GetbyId(id);

            return department == null ? null : department.toDepartmentDetailsDto();


        }
        public int addDepartment(CreateDepartmindDto departmindDto)
        {
            _unitOFWork.DepartmentRepository.Add(departmindDto.ToEentity());
            return _unitOFWork.Savechanges();
        }
        public int updateDepartment(UpdatedDepartmentDto departmentDto)
        {
            _unitOFWork.DepartmentRepository.Update(departmentDto.ToEentity());
            return _unitOFWork.Savechanges();
        }
        public bool deleteDepartment(int id)
        {
            var department = _unitOFWork.DepartmentRepository.GetbyId(id);
            if (department == null)
            {
                return false;
            }
            else
            {
                 _unitOFWork.DepartmentRepository.Delete(department);
                var result = _unitOFWork.Savechanges();
                return result > 0 ? true : false;
            }
        }
    }
}
